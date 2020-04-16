using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI
{
    [Serializable]
    class LoggedIn
    {

        public LoggedIn()
        {

        }

        public void OnLogged(object source, EventArgs e)
        {
            Console.WriteLine("Logged...");

        }
    }
}
