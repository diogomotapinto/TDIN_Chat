using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace ServerFram
{

    public class BEServer
    {
        private const string configFilePath = "C:\\Users\\dnc18\\Prog\\TDIN_Chat\\ServerFram\\App.config";
        TcpListener server = null;
        Actions actions;
        List<User> onlineUsers;
        public BEServer(string ip, int port)
        {
            RemotingConfiguration.Configure(configFilePath, false);
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            actions = new Actions();
            onlineUsers = new List<User>();
            server.Start();
            StartListener();
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
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
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
                    Reducer(hex.getHeader(), hex.getPayload(), stream);
                    //Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }


        public virtual void Reducer(string type, object payload, NetworkStream stream)
        {
            switch (type)
            {

                case Actions.REGISTER:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    registerUser((User)payload);
                    break;
                case Actions.LOGIN:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    if (loginUser((User)payload))
                    {
                        string str = Actions.ALL_GOOD;
                        Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                        stream.Write(reply, 0, reply.Length);
                    }
                    break;
                case Actions.LOGOUT:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    LogoutUser((User)payload);
                    break;
                default:
                    Console.WriteLine(payload);
                    break;
            }

            stream.Close();
        }


        private void registerUser(User user)
        {
            var finalist = new List<User>();
            finalist = FileManager.ReadBinaryFile<User>();

            foreach (var elem in finalist)
            {
                if (elem.ToString() == user.ToString())
                {
                    Console.WriteLine("User {0} already has an account", user.ToString());
                    return;
                }
            }

            finalist.Add(user);
            FileManager.writeStream(finalist);
            Console.WriteLine("Hello {0}", user.ToString());
        }


        private bool loginUser(User user)
        {
            var finalist = new List<User>();
            finalist = FileManager.ReadBinaryFile<User>();

            foreach (var elem in finalist)
            {
                if (elem.ToString() == user.ToString() && user.Password == elem.Password)
                {
                    Console.WriteLine("Logged  in {0}", user.ToString());
                    //this will return a list of all users with an account
                    actions.loginUser<User>(finalist);
                    onlineUsers.Add(user);
                    return true;
                }
            }

            Console.WriteLine("Something is wrong {0}", user.ToString());
            return false;
        }

        private void LogoutUser(User user)
        {
            onlineUsers.Remove(user);
            Console.WriteLine("Logged out  {0}", user.ToString());
            foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
            }
        }


        public List<User> getLoggedIn()
        {
            return FileManager.ReadBinaryFile<User>();
        }


    }


}
