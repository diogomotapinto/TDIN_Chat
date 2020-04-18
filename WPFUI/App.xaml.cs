using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using Shared;
using System.Net;
using System.Net.Sockets;
namespace WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public class MessageEventArgs : EventArgs
    {
        public string TextMessage { get; set; }
    }


    public class RequestEventArgs : EventArgs
    {
        public User user { get; set; }
    }

    public partial class App : Application
    {

        User user;
        TcpListener server;
        public delegate void MessageReceivedEventHandler(object source, MessageEventArgs args);

        public event MessageReceivedEventHandler MessageReceived;

        public delegate void RequestEventHandler(object source, RequestEventArgs args);

        public event RequestEventHandler RequestReceived;

        public App(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

        }

        public void initialize(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            Thread t = new Thread(runServer);
            t.Start();
        }

        public void runServer()
        {
            server.Start();
            StartListener();
        }

        public App()
        {

        }

        public User getUser()
        {
            return user;
        }



        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(() => HandleDeivce(client));
                    t.Start();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }
        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();

            Byte[] bytes = new Byte[256];
            int i;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    Messages hex = (Messages)Utils.ByteArrayToObject(bytes);
                    Reducer(hex.getHeader(), hex.getPayload());
                    string str = Actions.ALL_GOOD;
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    stream.Write(reply, 0, reply.Length);
                    //Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }


        public void createUser(User user)
        {
            this.user = user;
        }

        protected virtual void OnMessageReceived(string message)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, new MessageEventArgs() { TextMessage = message });
            }
        }

        protected virtual void OnRequestReceived(User user)
        {
            if (RequestReceived != null)
            {
                RequestReceived(this, new RequestEventArgs() { user = user });
            }
        }



        public virtual void Reducer(string type, object payload)
        {
            switch (type)
            {
                case Actions.START_CHAT:
                    Console.WriteLine(payload);
                    OnRequestReceived((User)payload);
                    break;
                default:
                    Console.WriteLine(payload);
                    OnMessageReceived((string)payload);
                    break;
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("Start");
        }
    }
}
