using System;


namespace Server
{

    public class Messages : MarshalByRefObject
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
