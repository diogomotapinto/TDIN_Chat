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
using ClientFram;
using ServerFram;

namespace WFPREGISTER
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Client client;
        public Page1()
        {
            InitializeComponent();

            client = new Client("127.0.0.1", 100);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string clientUsername = username.Text;
            string clientPassword = password.Text;
            Messages messages = new Messages(Actions.LOGIN, new User(clientPassword, clientPassword));
            client.connect(messages);
            client.Close();
        }
    }
}
