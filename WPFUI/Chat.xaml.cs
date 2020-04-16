using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServerFram;
using System.Threading;
using ClientFram;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        public UserController userController;
        Dictionary<Conversation, SimpleMessage> chat;
        public Chat(User user, UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            Thread t = new Thread(messageReceiver);
        }

        public void messageReceiver()
        {
            Console.WriteLine("Select Client Port:  ");
            string clientPort = Console.ReadLine();
            Console.WriteLine("Starting Message Receiver...");
            ClientServer server = new ClientServer("127.0.0.1", userController.getMe().Port);
        }

    }
}
