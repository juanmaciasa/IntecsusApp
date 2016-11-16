using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE870;

namespace IntecsusApplication.Controladores
{
    public static class DataCard
    {
        private static CE870.Class1 printer;

        public static string printCard()
        {
            printer = new Class1();
            string response = printer.Impresion("JUAN SEBASTIAN MACIAS", "528209", "16/11", "0", 0);
            return response;
        }

        public static Class1 Printer
        {
            get
            {
                return printer;
            }

            set
            {
                printer = value;
            }
        }
    }
}
