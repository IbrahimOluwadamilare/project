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
    public partial class AccountVerification : PhoneApplicationPage
    {
        account newuseracc = new account();
        public AccountVerification()
        {
            InitializeComponent();
        }

        private async void insert(account userdata)
        {
            try
            {
                await App.MobileService.GetTable<account>().InsertAsync(userdata).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("\nFailed, please check connection"));
                        //Dispatcher.BeginInvoke(() => SetProgressIndicator(false));
                        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative)));

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
            verifyBtn.IsEnabled = true;
        }

        private void agreeChk_Unchecked(object sender, RoutedEventArgs e)
        {
            verifyBtn.IsEnabled = false;
        }

        private void verifyBtn_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (char c in PINTxt.Text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    count++;
                }
            }
            if (PINTxt.Text != confirmPINTxt.Text)
            {
                MessageBox.Show("Confirmation PIN incorrect");
            }
            else if (count != 4)
            {
                MessageBox.Show("Enter a four digit PIN");
            }
            else
            {
                newuseracc.pin = PINTxt.Text;

                //to confirm transportation of varibles
                VerificationCodeTxt.Text = newuseracc.phone;

            }
        }
    }

}