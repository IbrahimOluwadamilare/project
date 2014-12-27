using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SmartPay.Resources;

namespace SmartPay
{
    public partial class MainPage : PhoneApplicationPage
    {
        login user = new login();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void log(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void Registration(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

        private void retrive_password(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Account_password_retrival.xaml", UriKind.Relative));
        }

        private void about(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTxt.Text == "")
            {
                MessageBox.Show("Username is empty");
            }
            else if (passwordTxt.Password == "")
            {
                MessageBox.Show("Password is empty");
            }
            else
            {
                user.username = UsernameTxt.Text;
                user.password = passwordTxt.Password;
            }
        }

       
    }
    class login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}