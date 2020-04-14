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

        public UserController()
        {
            actions = new Actions();
            onlineUsers = new List<User>();
            Console.WriteLine("New User controller created");
        }
        public bool login(User user)
        {
            var registeredUsers = new List<User>();
            registeredUsers = FileManager.ReadBinaryFile<User>();

            Console.WriteLine("Login request received from: {0}.", user.ToString());

            foreach (var elem in registeredUsers)
            {
                if (elem.ToString() == user.ToString() && user.Password == elem.Password)
                {
                    Console.WriteLine("Logged  in {0}", user.ToString());
                    //this will return a list of all users with an account
                    actions.loginUser<User>(registeredUsers);
                    onlineUsers.Add(user);
                    return true;
                }
            }

            Console.WriteLine("Falied to auth: {0}", user.ToString());

            return false;
        }

        public bool logout(User user)
        {
            onlineUsers.Remove(user);
            
            Console.WriteLine("Logged out  {0}", user.ToString());
            
            /* foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
            } */

            return true;
        }

        public bool register(User newUser)
        {
            Console.WriteLine("Attemp to register {0}", newUser.ToString());
    
            var registeredUsers = new List<User>();

            registeredUsers = FileManager.ReadBinaryFile<User>();

            foreach (var registeredUser in registeredUsers)
            {
                if (registeredUser.ToString() == newUser.ToString())
                {
                    Console.WriteLine("User {0} already has an account", newUser.ToString());
                    return false;
                }
            }

            registeredUsers.Add(newUser);
            FileManager.writeStream(registeredUsers);
            
            Console.WriteLine("Registered new user: {0}", newUser.ToString());

            return true;
        }
    }
}
