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

namespace WFPREGISTER
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Frame frame;
        public Page2(Frame obj)
        {
            InitializeComponent();
            frame = obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new Page1();
        }
    }
}
