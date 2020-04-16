using System;
using System.Runtime.Remoting;
using Shared;
using UserDatabase;

namespace ClientFram
{
    class Program : MarshalByRefObject
    {
        private const string clientConfigFile = @"C:\Users\dnc18\Prog\TDIN_Chat\ClientFRam\App.config";
        
        private static User loggedUser = null;
        static void Main(string[] args)
        {
            Users controller = null;
            try
            {
                RemotingConfiguration.Configure(clientConfigFile, false);
                controller = new Users();
                Program prog = new Program();
                controller.NewAuthEvent += prog.newAuthEventHandler;

            } catch(Exception e)
            {
                Console.WriteLine(value: e.InnerException.Message);
            }
            
            visualInterface(controller);
         }

        public void newAuthEventHandler(AuthenticationEventArgs arg)
        {
            if(arg.Login)
            {
                Console.WriteLine("{0} has logged in.", arg.user.Name);
            }
            else
            {
                Console.WriteLine("{0} has logged out", arg.user.Name);
            }
        }

        public static void register(Users controller)
        {
            Register register = new Register();
            if (controller.register(register.getUser()))
            {
                Console.WriteLine("Registered successfully");
            }
            else
            {
                Console.WriteLine("Failed to register");
            }
            Console.ReadKey();
        }

        public static void login(Users controller)
        {
            Login login = new Login();
            User user = login.getUser();

            if (controller.login(user))
            {
                loggedUser = user;
                Console.WriteLine("Logged In!");
            }
            else
            {
                Console.WriteLine("Check your password.");

            }
        }

        public static bool logout(Users controller)
        {
            if (loggedUser != null && controller.logout(loggedUser))
            {
                Console.WriteLine("Logout");
                return true;
            }

            Console.WriteLine("Logout failed");

            return false;
        }

        public static void visualInterface(Users controller)
        {
            bool live = true;

            while(live)
            {
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
                        login(controller);
                        break;
                    case 2:
                        register(controller);
                        break;
                    case 3:
                        live = !logout(controller);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
