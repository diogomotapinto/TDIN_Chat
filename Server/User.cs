using System;
using System.Collections.Generic;
using System.Text;


namespace Server
{
    [Serializable()]

    class User
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


    }
}
