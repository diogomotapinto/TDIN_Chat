using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Collections;

namespace Server
{
    class Program
    {

        public static Stream stream;
        public static Formatter formatter;

        static void Main(string[] args)
        {
            ArrayList users = new ArrayList();

            User user = new User("Diogo", "okok");
            users.Add(user);

            Console.WriteLine("Enter to exit.");
            string v = Console.ReadLine();
        }


    }
}
