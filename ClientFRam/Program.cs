using System;
using ServerFram;
using System.Threading;
using System.Runtime.Remoting;

namespace ClientFram
{
    class Program
    {
        private const string clientConfigFile = @"C:\Users\Diogo\source\repos\TDIN_Chat\ClientFram\App.config";
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(clientConfigFile, false);
            var visTh = new Thread(visualInterface);
            visTh.Start();
            /*var receiverTh = new Thread(messageReceiver);
            visTh.Join();
            receiverTh.Start();
            var senderTh = new Thread(messageSender);
            senderTh.Start();*/


        }


        public static void messageSender()
        {
            Console.WriteLine("Port of the other peer:   ");
            String port = Console.ReadLine();
            bool done = false;
            Client client = new Client("127.0.0.1", Int32.Parse(port));
            Messages messages;
            while (!done)
            {
                Console.WriteLine("Write Message:   ");
                string message = Console.ReadLine();
                messages = new Messages(Actions.DIRECT_MESSAGE, message);
                client.connect(messages);
            }
        }

        public static void messageReceiver()
        {
            Console.WriteLine("Select Client Port:  ");
            string clientPort = Console.ReadLine();
            Console.WriteLine("Starting Message Receiver...");
            ClientServer server = new ClientServer("127.0.0.1", Int32.Parse(clientPort));
        }

        public static void register()
        {
            UserController a = new UserController();
            Register register = new Register();
            if (a.register(register.getUser()))
            {
                Console.WriteLine("Registered successfully");
            }
            else
            {
                Console.WriteLine("Failed to register");
            }
            Console.ReadKey();
        }

        public static void login()
        {
            UserController a = new UserController();
            Login login = new Login();
            User user = login.getUser();

            if (a.login(user))
            {
                Console.WriteLine("Logged In!");
            }
            else
            {
                Console.WriteLine("Check your password.");
            }
            Console.ReadKey();
        }

        public static void visualInterface()
        {
            Console.WriteLine("What port?   ");
            String port = Console.ReadLine();
            Actions actions = new Actions();
            Client client = new Client("127.0.0.1", Int32.Parse(port));
            Messages messages;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-------------Welcome------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-------------1-Login------------------");
            Console.WriteLine("-------------2-Register---------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            string action = Console.ReadLine();
            switch (Int32.Parse(action))
            {
                case 1:
                    login();
                    break;
                case 2:
                    /*Register register = new Register();
                    messages = new Messages(Actions.REGISTER, register.getUser());
                    client.connect(messages);*/
                    register();
                    break;
                default:
                    return;
            }

            client.Close();
        }
    }
}
