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
    }
}
