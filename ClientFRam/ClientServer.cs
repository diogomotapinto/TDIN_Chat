using System;
using System.Collections.Generic;
using System.Text;
using ServerFram;

namespace ClientFram
{
    class ClientServer : BEServer
    {
        public ClientServer(string ip, int port) : base(ip, port)
        {

        }

        public void Reducer(string type, object payload)
        {
            switch (type)
            {
                case Actions.DIRECT_MESSAGE:
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
