using Server;
using System.IO;
using System;
namespace Chat_Client
{
    public class Login
    {
        private User user;
        public Login()
        {
            string username = "";
            string password = "";

            Console.WriteLine("Username:    ");
            username = Console.ReadLine();
            Console.WriteLine("Password:    ");
            password = Console.ReadLine();

            user = new User(username, password);

        }

        public User getUser()
        {
            return user;
        }

    }
}
