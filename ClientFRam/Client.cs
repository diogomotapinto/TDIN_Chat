using System;
using System.Net;
using System.Net.Sockets;
using ServerFram;

namespace ClientFram
{
    public class Client
    {
        private IPAddress address;
        private Int32 port;
        private TcpClient client;
        NetworkStream stream;
        public Client(string address, Int32 port)
        {
            this.port = port;
            this.address = IPAddress.Parse("127.0.0.1");
            this.client = new TcpClient(address, port);
            stream = client.GetStream();
        }

        public void connect(Object message)
        {
            try
            {

                int count = 0;
                while (count++ < 1)
                {

                    Byte[] data = Utils.ObjectToByteArray(message);

                    stream.Write(data, 0, data.Length);

                    Console.WriteLine("Sent: {0}", message);

                    data = new Byte[256];
                    String response = String.Empty;

                    Int32 bytes = stream.Read(data, 0, data.Length);

                    response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    if (response != Actions.ALL_GOOD)
                    {
                        Console.WriteLine("Something went wrong!");
                    }


                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        public void Close()
        {
            stream.Close();
            client.Close();
        }
    }




}
