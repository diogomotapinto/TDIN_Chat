﻿using System;
using System.Collections.Generic;
using Shared;

namespace UserDatabase
{
    public class Users : MarshalByRefObject, Interactions
    {
        List<User> onlineUsers;
        public event AuthenticationEventHandler NewAuthEvent;

        public Users()
        {
            onlineUsers = new List<User>();
            Console.WriteLine("New Users object created");
        }

        public User findUser(String name, List<User> list)
        {
            foreach (var elem in list)
            {
                if (name == elem.ToString())
                {
                    return elem;
                }
            }
            return null;
        }

        public bool login(User user)
        {
            var registeredUsers = new List<User>();
            registeredUsers = FileManager.ReadBinaryFile<User>();

            Console.WriteLine("Login request received from: {0}.", user.ToString());

            foreach (var elem in registeredUsers)
            {
                if ((elem.ToString() == user.ToString() && user.Password == elem.Password) && findUser(user.ToString(), onlineUsers) == null)
                {
                    Console.WriteLine("Logged  in {0}", user.ToString());
                    //this will return a list of all users with an account
                    onlineUsers.Add(user);

                    /* EVENT STUFF */
                    AuthenticationEventArgs newAuth = new AuthenticationEventArgs(user, true);
                    if (NewAuthEvent != null)
                    {
                        Console.WriteLine("Rasing event");
                        NewAuthEvent(newAuth);
                    }
                    /* EVENT STUFF */

                    return true;
                }
            }

            Console.WriteLine("Falied to auth: {0}", user.ToString());

            return false;
        }


        public List<User> getOnline()
        {
            return onlineUsers;
        }


        public bool logout(User user)
        {
            onlineUsers.Remove(user);

            Console.WriteLine("Logged out  {0}", user.ToString());

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