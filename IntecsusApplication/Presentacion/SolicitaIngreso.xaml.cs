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
    /// Lógica de interacción para SolicitaIngreso.xaml
    /// </summary>
    public partial class SolicitaIngreso : UserControl
    {
        Persona personaConsultada;
        public SolicitaIngreso()
        {
            InitializeComponent();
            tNumerico.TxtFoco = txtCedula;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Home());
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCedula.Text.Length > 0)
            {
                PersonasDAO pdao = new PersonasDAO();
                List<Persona> personas = pdao.consultaPersonas();
                IEnumerable<Persona> personasLinq = from Persona in personas
                                                    where Persona.NumIdentificacion == txtCedula.Text
                                                    select Persona;
                foreach (Persona per in personasLinq)
                {
                    personaConsultada = per;
                }
                if (personaConsultada != null)
                {
                    ValidaDatos v = new ValidaDatos(personaConsultada.Nombre + " " + personaConsultada.Apellido, "CC.: " + personaConsultada.NumIdentificacion);
                    var result = await DialogHost.Show(v, "RootDialog", cierraValidaDatos);
                }
                else
                {
                    Mensaje m = new Presentacion.Mensaje("INFORMACION NO ENCONTRADA", "El documento con número de identificacion " + txtCedula.Text + " no se encuentra registrado, ¿Desea registrarse?");
                    var result = await DialogHost.Show(m, "RootDialog", cierraMensajeNoEncontrado);
                }
            }
        }

        private void cierraMensajeNoEncontrado(object sender, DialogClosingEventArgs eventArgs)
        {
            if (((Mensaje)eventArgs.Session.Content).Opcion)
            {
                Switcher.Switch(new Registro(txtCedula.Text));
            }
            else
            {
                Switcher.Switch(new Home());
            }
        }

        private async void cierraValidaDatos(object sender, DialogClosingEventArgs eventArgs)
        {
            if (((ValidaDatos)eventArgs.Session.Content).Opcion)
            {
                await Task.Delay(500);
                Mensaje m = new Mensaje("¿Desea reclamar su Golf Card?", "Recuerde que una vez usted confirme la emisión de su tarjeta, se hará responsable de la misma");
                var result = await DialogHost.Show(m, "RootDialog", cierraMensaje);
            }
            else
            {
                txtCedula.Clear();
            }
        }

        private async void cierraMensaje(object sender, DialogClosingEventArgs eventArgs)
        {
            if (((Mensaje)eventArgs.Session.Content).Opcion)
            {
                await Task.Delay(500);
                Imprimiendo i = new Imprimiendo(personaConsultada.Nombre + " " + personaConsultada.Apellido, "CC.: " + personaConsultada.NumIdentificacion);
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
