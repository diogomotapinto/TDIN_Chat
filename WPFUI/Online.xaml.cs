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

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Online.xaml
    /// </summary>

    public partial class Online : Page
    {
        UserController userController;
        Frame frame;
        public Online(UserController userContoller, Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            this.userController = userController;
            LoggedIn loggedIn = new LoggedIn();

            //userContoller.Logged += loggedIn.OnLogged;


            List<User> onlineUsers = userContoller.getOnline();

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


            Chat chatPage = new Chat(new User("ola", "ola"), userController);
            frame.Navigate(chatPage);

        }


    }
}
