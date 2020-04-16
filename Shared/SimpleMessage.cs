using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SimpleMessage
    {
        private User from;
        private User to;
        private string text;
        public SimpleMessage(User from, User to, string text)
        {
            this.from = from;
            this.to = to;
            this.text = text;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        public User To
        {
            get { return to; }
            set { to = value; }
        }

        public User From
        {
            get { return from; }
            set { from = value; }
        }
    }
}
