using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Actions
    {
        public const string REGISTER = "REGISTER";
        public const string LOGIN = "LOGIN";

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
