using System;
using Server;

namespace Chat_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What port?   ");
            String port = Console.ReadLine();
            Client client = new Client("127.0.0.1", Int32.Parse(port));
            Console.WriteLine("Message: ");


            Register register = new Register();
            Messages messages = new Messages(Actions.REGISTER, register.getUser());
            client.connect(messages);
        }
    }
}
