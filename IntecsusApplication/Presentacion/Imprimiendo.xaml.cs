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
    /// Lógica de interacción para Imprimiendo.xaml
    /// </summary>
    public partial class Imprimiendo : UserControl
    {
        public Imprimiendo()
        {
            InitializeComponent();
            imprime();
        }

        private async void imprime()
        {
            await Task.Delay(2000);
            btn.Command.Execute(null);
        }
    }
}
