using System;
using System.Windows.Controls;
using UserDatabase;

namespace WPFUI
{
    public class ClientServer : Server
    {

        public ClientServer(int port) : base(port)
        {

        }




        public void Reducer(string type, object payload)
        {
            switch (type)
            {
                case "DIRECT_MESSAGE":
                    string message = (string)payload;
                    Console.WriteLine(message);

                    break;
                default:
                    Console.WriteLine("Message type invalid!");
                    break;
            }

        }
    }
}

