﻿using System;
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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnPedido_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SolicitaIngreso());
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Registro());
        }
    }
}
