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
            ValidaDatos v = new ValidaDatos("Juan Sebastian Macias Arias", "CC.: 1030603765");
            var result = await DialogHost.Show(v, "RootDialog", cierraValidaDatos);
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
                Imprimiendo i = new Imprimiendo("Juan Sebastián Macías Arias", "CC.: 1030603765");
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
