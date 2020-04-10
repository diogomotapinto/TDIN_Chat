using Server;
using System.IO;
using System;

namespace Chat_Client
{
    public class Register
    {
        private User user;
        public Register()
        {
            bool done = false;
            string username = "";
            string password = "";
            string confirmPass = "";
            while (!done)
            {
                Console.WriteLine("Username:    ");
                username = Console.ReadLine();
                Console.WriteLine("Password:    ");
                password = Console.ReadLine();
                Console.WriteLine("Confirm Password:    ");
                confirmPass = Console.ReadLine();

                if (password == confirmPass)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Incorrect Password");
                }
            }

            user = new User(username, password);

        }

        public User getUser()
        {
            return user;
        }

    }
}
