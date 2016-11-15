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
    /// Lógica de interacción para ValidaDatos.xaml
    /// </summary>
    public partial class ValidaDatos : UserControl
    {
        private bool opcion;

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

        public ValidaDatos(string nombre, string numIdentificacion)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtIdentificacion.Text = numIdentificacion;
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
