using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public delegate void AuthenticationEventHandler(AuthenticationEventArgs arg);

    [Serializable]
    public class AuthenticationEventArgs : EventArgs
    {
        private User authUser;
        private bool login;

        public User user
        {
            get
            {
                return authUser;
            }
        }

        public bool Login
        {
            get
            {
                return login;
            }
        }

        public AuthenticationEventArgs(User user, bool isLogin)
        {
            authUser = user;
            login = isLogin;
        }
    }
}
