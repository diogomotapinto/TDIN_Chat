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
using UserDatabase;
using Shared;
using System.Threading;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Online.xaml
    /// </summary>

    public partial class Online : Page
    {
        Users userController;
        Frame frame;
        App app;
        public Online(Users userController, Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            this.userController = userController;
            List<User> onlineUsers = userController.getOnline();
            //Application.Current.createServer(new ClientServer(userController.getMe().Port));
            App app = (App)App.Current;
            app.initialize(app.getUser().Port);
            foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
                Button button = new Button();
                button.Content = elem.ToString();
                button.Click += Button_Click;
                stack.Children.Add(button);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string s = (string)btn.Content;
            Console.WriteLine(s);
            Chat chatPage = new Chat(userController.findUser(s), userController);
            frame.Navigate(chatPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();
            List<User> onlineUsers = userController.getOnline();

            foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
                Button button = new Button();
                button.Content = elem.ToString();
                button.Click += Button_Click;
                stack.Children.Add(button);
            }
        }
    }
}
