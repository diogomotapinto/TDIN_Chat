using System;
using System.Collections.Generic;
using System.Text;


namespace Shared
{
    [Serializable()]

    public class User
    {
        private string name;
        private string password;
        private int port;
        private bool available;
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            Random rnd = new Random();
            this.port = rnd.Next(100, 200);
            this.available = true;
        }

        public bool Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   name == user.name &&
                   password == user.password &&
                   port == user.port &&
                   Port == user.Port &&
                   Name == user.Name &&
                   Password == user.Password;
        }
    }
}
