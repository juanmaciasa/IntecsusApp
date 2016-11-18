using System;
using System.Collections;
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
    public partial class TecladoAlfa : UserControl
    {
        private TextBox txtFoco;
        private bool mayus;
        public TecladoAlfa()
        {
            InitializeComponent();
            mayus = false;
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
            if (txtFoco != null)
            {
                txtFoco.Focus();
                Send(((Button)sender).Tag.ToString());
            }
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
            { }
        }

        private void btnMayus_Click(object sender, RoutedEventArgs e)
        {
            string texto = "";
            foreach (Button b in GetLogicalChildCollection<Button>(this))
            {
                if (b.Tag != null)
                {
                    if ((string)b.Tag != "")
                    {
                        if (!mayus)
                        {
                            texto = ((string)b.Tag).ToUpper();
                        }
                        else
                        {
                            texto = ((string)b.Tag).ToLower();
                        }
                        b.Tag = texto;
                        if (b.Content is Viewbox)
                            if (((Viewbox)b.Content).Child is TextBlock)
                                ((TextBlock)((Viewbox)b.Content).Child).Text = texto;
                    }
                }
            }
            if (!mayus)
            {
                mayus = true;
            }
            else
            {
                mayus = false;
            }
        }

        private List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
    }
}
