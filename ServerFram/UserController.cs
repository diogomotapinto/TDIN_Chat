using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFram
{
    public class UserController : MarshalByRefObject, Interactions
    {
        Actions actions;
        List<User> onlineUsers;
        List<string> test;

        public UserController()
        {
            actions = new Actions();
            onlineUsers = new List<User>();
            test = new List<string>();
            Console.WriteLine("New User controller created");

            test.Add("a");
        }
        public bool login(User user)
        {
            var finalist = new List<User>();
            finalist = FileManager.ReadBinaryFile<User>();

            foreach (var elem in finalist)
            {
                if (elem.ToString() == user.ToString() && user.Password == elem.Password)
                {
                    Console.WriteLine("Logged  in {0}", user.ToString());
                    //this will return a list of all users with an account
                    actions.loginUser<User>(finalist);
                    onlineUsers.Add(user);
                    return true;
                }
            }

            Console.WriteLine("Falied to auth {0}", user.ToString());
            return false;
        }

        public bool logout(User user)
        {
            onlineUsers.Remove(user);
            
            Console.WriteLine("Logged out  {0}", user.ToString());
            
            foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
            }

            return true;
        }

        public bool register(User user)
        {
            Console.WriteLine("Attemp to register {0}", user.ToString());

            foreach (string elem in test)
            {
                Console.WriteLine(elem);

                if(elem.Equals(user.Name))
                {
                    Console.WriteLine("{0} already exists!", user.Name);
                    return false;
                }
            }

            test.Add(user.Name);
                /* var finalist = new List<User>();
                finalist = FileManager.ReadBinaryFile<User>();


                foreach (var elem in finalist)
                {
                    if (elem.ToString() == user.ToString())
                    {
                        Console.WriteLine("User {0} already has an account", user.ToString());
                        return false;
                    }
                }

                finalist.Add(user);
                FileManager.writeStream(finalist);
                Console.WriteLine("Hello {0}", user.ToString()); */

            return true;
        }
    }
}
