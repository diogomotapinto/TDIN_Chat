using System;
using MyUser;

namespace Server
{
    [Serializable()]
    public class Messages
    {
        private string header;
        private object payload;
        public Messages(string header, object payload)
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
