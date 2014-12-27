using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartPay
{
    public partial class Individual_registration : PhoneApplicationPage
    {
        individual newuser = new individual();
        account newuseracc = new account();
        public Individual_registration()
        {
            InitializeComponent();

            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.Text = "Creating Account";
        }
        private void SetProgressIndicator(bool value)
        {
            SystemTray.ProgressIndicator.IsIndeterminate = value;
            SystemTray.ProgressIndicator.IsVisible = value;
        }
        private async void insert(individual userdata)
        {
            try
            {
                await App.MobileService.GetTable<individual>().InsertAsync(userdata).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("\nFailed, please check connection"));
                        Dispatcher.BeginInvoke(() => SetProgressIndicator(false));
                        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/AccountVerification.xaml", UriKind.Relative)));

                    }
                    else
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("\nAccount successfully created, you will receive a verification code to proceed"));
                    }
                });
            }
            catch (System.Net.WebException e)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("\nConnection failed!\n"));
            }

        }
        private void agreeChk_Checked(object sender, RoutedEventArgs e)
        {
            registerBtn.IsEnabled = true;
        }

        private void agreeChk_Unchecked(object sender, RoutedEventArgs e)
        {
            registerBtn.IsEnabled = false;
        }

        private void FullNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FullNameTxt.Text == "full name") { FullNameTxt.Text = ""; }
        }

        private void FullNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FullNameTxt.Text == "") { FullNameTxt.Text = "full name"; }
        }

        private void PhoneNoTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneNoTxt.Text == "phone no") { PhoneNoTxt.Text = ""; }
        }

        private void PhoneNoTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneNoTxt.Text == "") { PhoneNoTxt.Text = "phone no"; }
        }

        private void AddressTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressTxt.Text == "address") { AddressTxt.Text = ""; }
        }

        private void AddressTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddressTxt.Text == "") { AddressTxt.Text = "address"; }
        }

        private void EmailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTxt.Text == "email address") { EmailTxt.Text = ""; }
        }

        private void EmailTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTxt.Text == "") { EmailTxt.Text = "email address"; }
        }

        private void UsernameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTxt.Text == "username") { UsernameTxt.Text = ""; }
        }

        private void UsernameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTxt.Text == "") { UsernameTxt.Text = "username"; }
        }

        private void PasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTxt.Text == "password") { PasswordTxt.Text = ""; }
        }

        private void PasswordTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTxt.Text == "") { PasswordTxt.Text = "password"; }
        }

        private void ConfirmPasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordTxt.Text == "confirm password") { ConfirmPasswordTxt.Text = ""; }
        }

        private void ConfirmPasswordTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordTxt.Text == "") { ConfirmPasswordTxt.Text = "confirm password"; }
            MessageBoxResult pass;
            if (ConfirmPasswordTxt.Text != PasswordTxt.Text)
            {
                pass = MessageBox.Show("Wrong password confirmation", "Confirm Password", MessageBoxButton.OK);
                if (pass == MessageBoxResult.OK)
                {
                    ConfirmPasswordTxt.Text = "confirm password";
                    PasswordTxt.Text = "";
                    PasswordTxt.Focus();
                }
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (char c in PasswordTxt.Text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    count++;
                }
            }
            if (FullNameTxt.Text == "full name") 
            {
                MessageBox.Show("Please, enter your full name");
                FullNameTxt.Focus();
            }
            else if (PhoneNoTxt.Text == "phone no")
            {
                MessageBox.Show("Please, enter your phone number");
                PhoneNoTxt.Focus();
            }
            else if (AddressTxt.Text == "address")
            {
                MessageBox.Show("Please, enter your address");
                AddressTxt.Focus();
            }
            else if (EmailTxt.Text == "email address")
            {
                MessageBox.Show("Please, enter your email");
                EmailTxt.Focus();
            }
            else if (UsernameTxt.Text == "username")
            {
                MessageBox.Show("Please, enter your username");
                UsernameTxt.Focus();
            }
            else if (PasswordTxt.Text == "password")
            {
                MessageBox.Show("Please, enter your password");
                PasswordTxt.Focus();
            }
            else if (PasswordTxt.Text != ConfirmPasswordTxt.Text)
            {
                MessageBox.Show("Wrong password ocnfirmation");
                ConfirmPasswordTxt.Text = "confirm password";
                PasswordTxt.Focus();
            }
            else if (count < 6)
            {
                MessageBox.Show("Password is too short");
                ConfirmPasswordTxt.Text = "confirm password";
                PasswordTxt.Focus();
            }
            else
            {
                SetProgressIndicator(true);
                newuser.name = FullNameTxt.Text;
                newuser.phone = PhoneNoTxt.Text;
                newuser.address = AddressTxt.Text;
                newuser.email = EmailTxt.Text;
                newuser.username = UsernameTxt.Text;
                newuser.password = PasswordTxt.Text;

                newuseracc.phone = PhoneNoTxt.Text;
                newuseracc.balance = 0.0f;

                insert(newuser);
            }

        }
    }
    class individual
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    class account
    {
        public string phone { get; set; }
        public string pin { get; set; }
        public float balance { get; set; }
        
    }
}