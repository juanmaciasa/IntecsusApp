using IntecsusApplication.Logica;
using IntecsusApplication.Persistencia;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntecsusApplication.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : UserControl
    {
        public Registro()
        {
            InitializeComponent();
            txtNombres.Focus();
        }

        public Registro(string numidentificacion)
        {
            InitializeComponent();
            txtIdentificacion.Text = numidentificacion;
            txtNombres.Focus();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Home());
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            tecladoAlfa.TxtFoco = (TextBox)sender;
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombres.Text.Length > 0 && txtApellidos.Text.Length > 0 && txtIdentificacion.Text.Length > 0 && txtEmail.Text.Length > 0)
            {
                PersonasDAO pdao = new PersonasDAO();
                List<Persona> personasRegistradas = pdao.consultaPersonas();
                IEnumerable<Persona> personasLinq = from Persona in personasRegistradas
                                                    where Persona.NumIdentificacion == txtIdentificacion.Text
                                                    select Persona;
                if (personasLinq.Count<Persona>() > 0)
                {
                    Mensaje m = new Presentacion.Mensaje("USUARIO YA REGISTRADO", "Usted ya se encuentra registrado. ¿Desea reclamar su Golf Card?, recuerde que una vez usted confirme la emisión de su tarjeta, se hará responsable de la misma");
                    var result = await DialogHost.Show(m, "RootDialog", cierraMensaje);
                }
                else
                {
                    if (pdao.creaPersona(txtNombres.Text, txtApellidos.Text, txtIdentificacion.Text, txtEmail.Text))
                    {
                        Mensaje m = new Presentacion.Mensaje("REGISTRO EXITOSO", "Usted se ha registrado exitosamente. ¿Desea reclamar su Golf Card?, recuerde que una vez usted confirme la emisión de su tarjeta, se hará responsable de la misma");
                        var result = await DialogHost.Show(m, "RootDialog", cierraMensaje);
                    }
                }
            }
            else
            {
                Mensaje m = new Presentacion.Mensaje("INFORMACIÓN INCOMPLETA", "Por favor ingrese toda la información solicitada", false);
                var result = await DialogHost.Show(m, "RootDialog");
            }
        }

        private async void cierraMensaje(object sender, DialogClosingEventArgs eventArgs)
        {
            if (((Mensaje)eventArgs.Session.Content).Opcion)
            {
                await Task.Delay(500);
                Imprimiendo i = new Imprimiendo(txtNombres.Text + " " + txtApellidos.Text, "CC.: " + txtIdentificacion.Text);
                var result = await DialogHost.Show(i, "RootDialog", cierraImprimiendo);
            }
            else
            {
                Switcher.Switch(new Gracias(false));
            }
        }

        private void cierraImprimiendo(object sender, DialogClosingEventArgs eventArgs)
        {
            Switcher.Switch(new Gracias(true));
        }
    }
}
