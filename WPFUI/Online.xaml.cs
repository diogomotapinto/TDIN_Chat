﻿using System;
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
    /// Interaction logic for Online.xaml
    /// </summary>
    public partial class Online : Page
    {
        UserController userController;
        public Online(UserController userContoller)
        {
            InitializeComponent();
            this.userController = userController;
            Button button = new Button();
            button.Content = "User x";
            stack.Children.Add(button);
        }
    }
}
