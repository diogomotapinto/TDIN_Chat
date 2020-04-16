using System;
using System.Runtime.Remoting;

namespace ServerFram
{
    class Program
    {
        private const string configFilePath = @"C:\Users\dnc18\Prog\TDIN_Chat\ServerFram\App.config";

        static void Main(string[] args)
        { 
            RemotingConfiguration.Configure(configFilePath, false);
            Console.WriteLine("[Server] hosting User Manager");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
