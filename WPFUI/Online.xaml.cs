using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UserDatabase;
using Shared;


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
        User userMe;
        List<User> onlineUsers;
        public Online(Users userController, Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            this.userController = userController;
            onlineUsers = userController.getOnline();
            App app = (App)App.Current;
            app.initialize(app.getUser().Port);
            userMe = app.getUser();
            OnlineUsers onlineUsersList = new OnlineUsers(this, userController);
            userController.NewAuthEvent += onlineUsersList.newAuthEventHandler;
            app.RequestReceived += this.OnRequestReceived;
            app.AcceptedReceived += this.OnAcceptedReceived;
            refreshList(app.getUser(), true);
        }

        public void OnRequestReceived(object source, RequestEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to talk with " + e.user.ToString() + "?", "Request", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Dispatcher.Invoke(() =>
                    {
                        Chat chatPage = new Chat(e.user, userController, frame, this);
                        frame.Navigate(chatPage);
                    });
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "Request");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "Request");
                    break;
            }
        }


        public void refreshList(User myUser, bool state)
        {
            stack.Children.Clear();
            userController.setState(myUser.Name, state);
            foreach (var elem in userController.getOnline())
            {
                if (!elem.Equals(myUser))
                {
                    Console.WriteLine(elem.ToString());
                    Button button = new Button();
                    button.Content = elem.ToString();
                    if (elem.Available == true)
                    {
                        button.Click += Button_Click;
                        button.Background = Brushes.Green;
                    }
                    else
                    {
                        button.Background = Brushes.Red;
                    }
                    stack.Children.Add(button);
                }
            }
        }

        public void OnAcceptedReceived(object source, RequestEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Console.WriteLine(e.user.ToString());
                Chat chatPage = new Chat(e.user, userController, frame, this);
                frame.Navigate(chatPage);
            });
        }


        public void createButton(User user)
        {
            this.Dispatcher.Invoke(() =>
            {
                Console.WriteLine("{0} has logged in.", user.Name);
                Button button = new Button();
                button.Content = user.ToString();
                if (user.Available == true)
                {
                    button.Click += Button_Click;
                    button.Background = Brushes.Green;
                }
                else
                {
                    button.Background = Brushes.Red;
                }
                stack.Children.Add(button);
            }
            );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string s = (string)btn.Content;
            User to = userController.findUser(s);
            Client client = new Client("127.0.0.1", to.Port);
            client.connect(new Messages(Actions.START_CHAT, userMe));
            client.Close();
            Chat chatPage = new Chat(to, userController, frame, this);
            frame.Navigate(chatPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();
            foreach (var elem in userController.getOnline())
            {
                if (!elem.Equals(app.getUser()))
                {
                    Console.WriteLine(elem.ToString());
                    Button button = new Button();
                    button.Content = elem.ToString();
                    if (elem.Available == true)
                    {
                        button.Click += Button_Click;
                        button.Background = Brushes.Green;
                    }
                    else
                    {
                        button.Background = Brushes.Red;
                    }
                    stack.Children.Add(button);
                }
            }
        }
    }
}
