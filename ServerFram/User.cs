using System;
using System.Collections.Generic;
using System.Text;


namespace ServerFram
{
    [Serializable()]

    public class User
    {
        private string name;
        private string password;
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
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

        public void OnLoginUser(object source, EventArgs e)
        {
            Console.WriteLine("User logged in");
        }

    }
}
