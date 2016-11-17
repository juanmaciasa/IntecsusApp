using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IntecsusApplication.Controladores
{
    public static class ImprimeCanvas
    {
        public static void imprime(Canvas c)
        {
            PrintDialog p = new PrintDialog();
            Size pageSize = new Size(321, 208);
            c.Measure(pageSize);
            c.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));
            p.PrintVisual(c, "Printing Canvas");
        }
    }
}
