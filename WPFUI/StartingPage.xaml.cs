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
using System.Runtime.Remoting;
using UserDatabase;


namespace WPFUI
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Frame frame;
        private const string clientConfigFile = @"..\WPFUI\App.config";
        Users userController;
        public Page2(Frame obj)
        {
            InitializeComponent();
            RemotingConfiguration.Configure(clientConfigFile, false);
            userController = new Users();
            frame = obj;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new LoginPage(userController, frame);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new RegisterPage(userController);
        }
    }
}
