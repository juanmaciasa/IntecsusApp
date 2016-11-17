using IntecsusApplication.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
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
        private string Nombre, Cedula;
        public Imprimiendo(string nombre, string cedula)
        {
            InitializeComponent();
            Nombre = nombre;
            Cedula = cedula;
            imprime();
        }

        private void imprime()
        {
            Impresion i = new Impresion(Nombre, Cedula);
            ImprimeCanvas.imprime(i.printCanvas);
            BackgroundWorker bw = new BackgroundWorker();
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int numberOfJobs = 1;
            LocalPrintServer server = new LocalPrintServer();
            PrintQueueCollection queueCollection;
            PrintQueue printQueue = null;
            while (numberOfJobs != 0)
            {
                queueCollection = server.GetPrintQueues();
                foreach (PrintQueue pq in queueCollection)
                {
                    if (pq.FullName == "XPS Card Printer")
                        printQueue = pq;
                }

                if (printQueue != null)
                    numberOfJobs = printQueue.NumberOfJobs;
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn.Command.Execute(null);
        }
    }
}

