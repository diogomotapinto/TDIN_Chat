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
using UserDatabase;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    [Serializable]
    public partial class LoginPage : Page
    {

        Users userController;
        Frame frame;
        App app;
        public LoginPage(Users userController, Frame frame)
        {
            InitializeComponent();
            App app = (App)App.Current;
            this.app = app;

            this.userController = userController;
            this.frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string clientUsername = username.Text;
            string clientPassword = password.Text;
            User user = new User(clientUsername, clientPassword);
            if (userController.login(user))
            {
                app.createUser(user);
                Online onlinePage = new Online(userController, frame);
                frame.Navigate(onlinePage);
            }
            else
            {
                MessageBox.Show("Something went wrong - Login!");
            }
        }

    }
}
