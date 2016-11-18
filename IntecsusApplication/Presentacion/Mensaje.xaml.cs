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
    /// Lógica de interacción para Mensaje.xaml
    /// </summary>
    public partial class Mensaje : UserControl
    {
        private bool opcion;
        public Mensaje(string titulo, string texto, bool siNo = true)
        {
            InitializeComponent();
            txtTitulo.Text = titulo;
            txtMensaje.Text = texto;
            if (!siNo)
            {
                btnSi.Visibility = btnNo.Visibility = Visibility.Collapsed;
                btnAceptar.Visibility = Visibility.Visible;
            }
        }

        public bool Opcion
        {
            get
            {
                return opcion;
            }

            set
            {
                opcion = value;
            }
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            opcion = true;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            opcion = false;
        }
    }
}
