using System;
using System.Net;
using System.Net.Sockets;

using System.Threading;
using System.Collections.Generic;

namespace Server
{

    class Server
    {
        TcpListener server = null;
        Actions actions;
        List<User> onlineUsers;
        public Server(string ip, int port)
        {
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
                    Reducer(hex.getHeader(), hex.getPayload());
                    string str = "Hey Device!";
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }


        private void Reducer(string type, object payload)
        {
            switch (type)
            {
                case Actions.REGISTER:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    registerUser((User)payload);
                    break;
                case Actions.LOGIN:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    loginUser((User)payload);
                    break;
                case Actions.LOGOUT:
                    Console.WriteLine("{1}: Received: {0}", type, Thread.CurrentThread.ManagedThreadId);
                    LogoutUser((User)payload);
                    break;
                default:
                    Console.WriteLine(payload);
                    break;
            }

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


        private void loginUser(User user)
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
                    return;
                }
            }

            Console.WriteLine("Something is wrong {0}", user.ToString());
        }

        private void LogoutUser(User user)
        {
            onlineUsers.Remove(user);
            Console.WriteLine("Logged out  {0}", user.ToString());
        }


        public List<User> getLoggedIn()
        {
            return FileManager.ReadBinaryFile<User>();
        }


    }


}
