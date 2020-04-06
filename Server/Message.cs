using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{

    class Message
    {
        private string header;
        private object payload;
        public Message(string header, object payload)
        {
            this.header = header;
            this.payload = payload;
        }

        public string getHeader()
        {
            return header;
        }

        public object getPayload()
        {
            return this.payload;
        }

    }
}
