using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using System.IO.IsolatedStorage;

namespace smartpurse
{
    public partial class Login : PhoneApplicationPage
    {
        private string appusername;
        private string apppassword;
     
        public Login()
        {
            InitializeComponent();

            
        }

        private void loginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //userlogin newlog = new userlogin();

            //newlog.Id = UsernameTxt.Text;
            //newlog.password = passwordTxt.Text;

            //check(newlog);

            if (IsolatedStorageSettings.ApplicationSettings.Contains("username"))
            {
                appusername = IsolatedStorageSettings.ApplicationSettings["username"] as string;
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("password"))
            {
                apppassword = IsolatedStorageSettings.ApplicationSettings["password"] as string;
            }


            if (appusername == UsernameTxt.Text)
            {
                if (apppassword == passwordTxt.Text)
                {
                    NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Invalid Passord");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username");
            }
        }
        private async void check(userlogin item)
        {
            try
            {
                await App.MobileService.GetTable<userlogin>().UpdateAsync(item).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("\nUpdate failed!\n"));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative)));
                    }
                });
            }
            catch (System.Net.WebException e)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("\nConnection failed!\n"));
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }

             
        
    }
}