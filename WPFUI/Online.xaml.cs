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

    public class OnlineUsers : MarshalByRefObject
    {
        Online page;
        Users userController;
        public OnlineUsers(Online page, Users userController)
        {
            this.page = page;
            this.userController = userController;
        }
        [STAThread]
        public void newAuthEventHandler(AuthenticationEventArgs arg)
        {
            if (arg.Login)
            {
                page.createButton(arg.user);
            }
            else
            {
                Console.WriteLine("{0} has logged out", arg.user.Name);
            }
        }



    }

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
            App app = (App)App.Current;
            app.initialize(app.getUser().Port);
            OnlineUsers onlineUsersList = new OnlineUsers(this, userController);
            userController.NewAuthEvent += onlineUsersList.newAuthEventHandler;
            foreach (var elem in onlineUsers)
            {
                if (!elem.Equals(app.getUser()))
                {
                    Console.WriteLine(elem.ToString());
                    Button button = new Button();
                    button.Content = elem.ToString();
                    button.Click += Button_Click;
                    stack.Children.Add(button);
                }
            }
        }


        public void createButton(User user)
        {
            this.Dispatcher.Invoke(() =>
            {
                Console.WriteLine("{0} has logged in.", user.Name);
                Button button = new Button();
                button.Content = user.ToString();
                button.Click += Button_Click;
                stack.Children.Add(button);
            }
            );
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
