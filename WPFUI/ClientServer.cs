using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UserDatabase;

namespace WPFUI
{
    public class ClientServer : Server
    {
        public ClientServer(int port) : base(port)
        {

        }
        TextBlock textBlock;
        public ClientServer(int port, TextBlock textBlock) : base(port)
        {
            this.textBlock = textBlock;
        }

        public void setTextBlock(TextBlock textBlockextBlo)
        {
            this.textBlock = textBlock;
        }


        public void Reducer(string type, object payload)
        {
            switch (type)
            {
                case "DIRECT_MESSAGE":
                    string message = (string)payload;
                    Console.WriteLine(message);
                    //textBlock.Inlines.Add(message + Environment.NewLine);
                    break;
                default:
                    Console.WriteLine("Message type invalid!");
                    break;
            }

        }
    }
}

