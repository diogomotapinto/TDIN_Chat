using System;
using System.Collections.Generic;
using System.Text;

namespace ServerFram
{
    [Serializable()]
    public class Actions
    {
        public const string REGISTER = "REGISTER";
        public const string LOGIN = "LOGIN";
        public const string LOGOUT = "LOGOUT";
        public const string DIRECT_MESSAGE = "DIRECT_MESSAGE";
        public const string ALL_GOOD = "200";
        public Actions()
        {

        }

        public void loginUser<T>(List<T> list)
        {
            OnLoginUser();
        }

        public delegate void LoginEventHandler(object source, EventArgs args);

        public event LoginEventHandler LoggedIn;

        protected virtual void OnLoginUser()
        {
            if (LoggedIn != null)
            {
                LoggedIn(this, EventArgs.Empty);
            }
        }

    }
}
