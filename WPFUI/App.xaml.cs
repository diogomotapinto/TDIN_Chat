using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClientFram;
using System.Threading;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Client client;
        public void connect()
        {
            var visTh = new Thread(connecting);
            visTh.Start();

        }

        public void connecting()
        {
            client = new Client("127.0.0.1", 100);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("Start");
        }
    }
}
