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

namespace IntecsusApplication.Resources
{
    /// <summary>
    /// Lógica de interacción para TecladoNumerico.xaml
    /// </summary>
    public partial class TecladoNumerico : UserControl
    {
        private TextBox txtFoco;
        public TecladoNumerico()
        {
            InitializeComponent();
        }

        public TextBox TxtFoco
        {
            get
            {
                return txtFoco;
            }

            set
            {
                txtFoco = value;
            }
        }

        private void Send(string tecla)
        {
            try
            {
                var text = tecla;
                var target = txtFoco;
                var routedEvent = TextCompositionManager.TextInputEvent;

                target.RaiseEvent(
                  new TextCompositionEventArgs(
                    InputManager.Current.PrimaryKeyboardDevice,
                    new TextComposition(InputManager.Current, target, text))
                  { RoutedEvent = routedEvent }
                );
            }
            catch
            { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtFoco.Focus();
            Send(((Button)sender).Content.ToString());
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtFoco.Focus();
                if (txtFoco.IsFocused)
                {
                    if (txtFoco.Text.Length > 0)
                    {
                        var focusedControl = Keyboard.FocusedElement;
                        PresentationSource source = PresentationSource.FromDependencyObject((DependencyObject)focusedControl);
                        KeyEventArgs ke = new KeyEventArgs(Keyboard.PrimaryDevice, source, 0, Key.Back)
                        {
                            RoutedEvent = UIElement.KeyDownEvent
                        };
                        System.Windows.Input.InputManager.Current.ProcessInput(ke);
                    }
                }
            }
            catch
            {}
        }
    }
}
