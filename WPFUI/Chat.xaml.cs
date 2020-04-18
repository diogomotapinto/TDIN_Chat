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
using Shared;
using System.Net.Sockets;
using System.Threading;
using UserDatabase;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        public Users userController;

        Dictionary<Conversation, List<string>> chat;
        User user;
        App app;
        public Chat(User user, Users userController)
        {
            InitializeComponent();
            App app = (App)App.Current;
            this.app = app;
            this.userController = userController;
            this.user = user;
            app.MessageReceived += this.OnMessageReceived;
        }

        public void OnMessageReceived(object source, MessageEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Console.WriteLine("Message Received: " + e.TextMessage);
                textBlock.Inlines.Add(Environment.NewLine + "[" + user.Name + "]" + " - " + e.TextMessage);
            });
        }


        private void send_button_Click(object sender, RoutedEventArgs e)
        {
            string message = textBox.Text;
            textBox.Text = "";
            Client client = new Client("127.0.0.1", user.Port);
            textBlock.Inlines.Add(Environment.NewLine + "[" + app.getUser().ToString() + "]" + " - " + message);
            client.connect(new Messages("DIRECT_MESSAGE", message));
            client.Close();
        }
    }
}
