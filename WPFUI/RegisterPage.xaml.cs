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

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        UserController userController;
        public RegisterPage(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string clientUsername = username.Text;
            string clientPassword = password.Text;

            if (password.Text != confim.Text)
            {
                MessageBox.Show("Something went wrong - Login!");
                return;
            }


            User user = new User(clientUsername, clientPassword);

            if (userController.register(user))
            {
                MessageBox.Show("Register Successfull!");
            }
            else
            {
                MessageBox.Show("Something went wrong - Login!");
            }
        }
    }
}
