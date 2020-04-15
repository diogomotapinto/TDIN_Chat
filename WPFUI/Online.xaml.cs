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
        public Online(UserController userContoller)
        {
            InitializeComponent();
            this.userController = userController;

            List<User> onlineUsers = userContoller.getOnline();

            foreach (var elem in onlineUsers)
            {
                Console.WriteLine(elem.ToString());
                Button button = new Button();
                button.Content = elem.ToString();
                stack.Children.Add(button);
            }
        }
    }
}
