using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace smartpurse
{
    public class accounts
    {
        public string Id { get; set; }
        public string PIN { get; set; }
        public int balance { get; set; }
    }
    public partial class AccountVerification : PhoneApplicationPage
    {
        accounts acc = new accounts();
        public AccountVerification()
        {
            InitializeComponent();
        }

        private void verifyBtn_Click(object sender, RoutedEventArgs e)
        {
            acc.balance = 0;
            acc.PIN = PINTxt.Text;
            acc.Id = "07065894157";

            insert(acc);
        }
        private async void insert(accounts items)
        {
            try
            {
                await App.MobileService.GetTable<accounts>().InsertAsync(items).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("User's details already exist."));
                    }
                    else
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show("Verification successful."));
                        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative)));
                    }
                });
            }
            catch (System.Net.WebException e)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show("\nConnection failed!\n"));
            }
        }

    }
}