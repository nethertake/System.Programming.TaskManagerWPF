using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();

        }
        public List<ProcessClass> processClasses = new List<ProcessClass>();
        public void GetData()
        {
         
            List<Process> listProcesses = Process.GetProcesses(".").ToList();
            foreach (var item in listProcesses)
            {
                ProcessClass pc = new ProcessClass();
                pc.id = item.Id;
                pc.name = item.ProcessName;
                pc.threadcount = item.Threads.Count;
                pc.memory = item.WorkingSet64;
                processClasses.Add(pc);
               
            }

            ListViewTaskManager.ItemsSource = processClasses;
            

        }

        public class ProcessClass
        {
            public int id { get; set; }
            public string name { get; set; }
            public int threadcount { get; set; }
            public long memory { get; set; }

            public override string ToString()
            {
                return $"{memory} - {name}";
            }
        }

  



    }

       
    

}

