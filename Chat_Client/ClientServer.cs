using System;
using System.Collections.Generic;
using System.Text;
using Server;

namespace Chat_Client
{
    class ClientServer : BEServer
    {
        public ClientServer(string ip, int port) : base(ip, port)
        {

        }
    }
}
