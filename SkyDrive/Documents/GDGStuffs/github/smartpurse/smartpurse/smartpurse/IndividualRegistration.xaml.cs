using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace smartpurse
{
     public class indreg
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
    }
    public class userlogin
    {
        public string Id { get; set; }
        public string phoneno { get; set; }
        public string password { get; set; }
    }
    public partial class IndividualRegistration : PhoneApplicationPage
    {
        indreg newuser = new indreg();
        userlogin newlogin = new userlogin();
        private string appusername;
        private string apppassword;
        private string appname;
        private string appphoneno;

        public IndividualRegistration()
        {
            InitializeComponent();
        }

        private async void Insert(indreg items)
        {
            try
            {
                await App.MobileService.GetTable<indreg>().InsertAsync(items).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("User's details already exist."));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(() => insuser(newlogin));

                    }
                });
            }
            catch (System.Net.WebException e)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("\nConnection failed!\n"));
            }
        }
        private async void insuser(userlogin items)
        {
            try
            {
                await App.MobileService.GetTable<userlogin>().InsertAsync(items).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("User's details already exist."));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(() => save());
                        Dispatcher.BeginInvoke(() => MessageBox.Show("Registration successful."));
                        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/AccountVerification.xaml", UriKind.Relative)));
                    }
                });
            }
            catch (System.Net.WebException e)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("\nConnection failed!\n"));
            }
        }
        private void agreeChk_Checked_1(object sender, RoutedEventArgs e)
        {
            registerBtn.IsEnabled = true;
        }

        private void agreeChk_Unchecked_1(object sender, RoutedEventArgs e)
        {
            registerBtn.IsEnabled = false;
        }

        private void registerBtn_Click_1(object sender, RoutedEventArgs e)
        {
            newuser.Id = PhoneNoTxt.Text;
            newlogin.Id = UsernameTxt.Text;
            newuser.name = FullNameTxt.Text;
            newuser.phoneno = PhoneNoTxt.Text;
            newlogin.phoneno = PhoneNoTxt.Text;
            newuser.address = AddressTxt.Text;
            newuser.email = EmailTxt.Text;
            newuser.username = UsernameTxt.Text;
            newuser.password = PasswordTxt.Text;
            newlogin.password = PasswordTxt.Text;

            appname = FullNameTxt.Text;
            appphoneno = PhoneNoTxt.Text;
            appusername = UsernameTxt.Text;
            apppassword = PasswordTxt.Text;
            save();
            Insert(newuser);

        }

        private void save()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            
            if (!settings.Contains("username"))
            {
                settings.Add("username", appusername);
            }
            else { settings["username"] = appusername; }

            if (!settings.Contains("password"))
            {
                settings.Add("password", apppassword);
            }
            else { settings["password"] = apppassword; }
            if (!settings.Contains("name"))
            {
                settings.Add("name", appname);
            }
            else { settings["name"] = appname; }

            if (!settings.Contains("phoneno"))
            {
                settings.Add("phoneno", appphoneno);
            }
            else { settings["phoneno"] = appphoneno; }

            settings.Save();

        }
       
    }
}