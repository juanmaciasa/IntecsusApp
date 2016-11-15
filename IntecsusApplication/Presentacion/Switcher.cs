using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace IntecsusApplication.Presentacion
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;
        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
            InicioOpacity(newPage);
        }
        public static void InicioOpacity(UserControl c)
        {
            Storyboard storyBoard = new Storyboard();
            DoubleAnimation d = new DoubleAnimation();
            d.From = 0;
            d.To = 100;
            d.Duration = new Duration(TimeSpan.FromSeconds(50));

            Storyboard.SetTargetName(d, c.Name);
            Storyboard.SetTargetProperty(d, new PropertyPath("Opacity", 0));

            storyBoard.Children.Add(d);
            storyBoard.Begin(c);
        }
    }
}
