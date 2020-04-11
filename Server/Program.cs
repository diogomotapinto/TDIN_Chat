using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        private const int portNum = 13;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server...");
            BEServer server = new BEServer("127.0.0.1", 100);
        }


    }
}
