using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using Shared;
using System.Windows.Controls;



namespace WPFUI
{
    public class Server
    {
        TcpListener server = null;
        List<User> onlineUsers;
        TextBlock textBlock;
        public Server(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            onlineUsers = new List<User>();
            server.Start();
        }

        public void setTextBlock(TextBlock textBlock)
        {
            this.textBlock = textBlock;
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


        public virtual void Reducer(string type, object payload)
        {
            switch (type)
            {
                case "ok":
                    break;
                default:
                    Console.WriteLine(payload);
                    textBlock.Inlines.Add((string)payload);
                    break;
            }

        }



    }
}
