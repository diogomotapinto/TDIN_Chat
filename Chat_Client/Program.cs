using System;
using Server;
using System.Threading;

namespace Chat_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var visTh = new Thread(visualInterface);
            visTh.Start();
            var mesTh = new Thread(messageEx);
            mesTh.Start();

        }

        public static void messageEx()
        {
            Console.WriteLine("Starting Message Receiver...");
            ClientServer server = new ClientServer("127.0.0.1", 101);
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
                    Login login = new Login();
                    messages = new Messages(Actions.LOGIN, login.getUser());
                    User user = login.getUser();
                    actions.LoggedIn += user.OnLoginUser;
                    client.connect(messages);
                    var logoutMSG = new Messages(Actions.LOGOUT, login.getUser());
                    client.connect(logoutMSG);
                    break;
                case 2:
                    Register register = new Register();
                    messages = new Messages(Actions.REGISTER, register.getUser());
                    client.connect(messages);
                    break;
                default:
                    return;
            }
            client.Close();
        }
    }
}
