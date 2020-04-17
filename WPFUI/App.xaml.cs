using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Threading;
using Shared;
namespace WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        ClientServer server;
        User user;
        public App()
        {

        }
        public User getUser()
        {
            return user;
        }
        public void createUser(User user)
        {
            this.user = user;
        }

        public void createServer(ClientServer server)
        {
            this.server = server;
            Thread t = new Thread(runServer);
            t.Start();
        }

        public void runServer()
        {
            server.StartListener();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("Start");
        }
    }
}
