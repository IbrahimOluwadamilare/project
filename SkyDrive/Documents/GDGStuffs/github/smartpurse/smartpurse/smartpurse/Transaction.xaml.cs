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
    public partial class Transaction : PhoneApplicationPage
    {
        private string code;
        accounts trans = new accounts();
        public Transaction()
        {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("name"))
            {
                recieverTxt.Text = IsolatedStorageSettings.ApplicationSettings["name"] as string;
            }
        }

        private void scanBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScanQrCode.xaml", UriKind.Relative));

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("key"))
            {
                code  = NavigationContext.QueryString["key"];
                payerTxt.Text = code.Substring(14);

                // etc ...
            }
        }

        private void mPaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            trans.Id = code.Substring(3, 11);
            trans.PIN = pinTxt.Password;
            trans.balance = int.Parse(amountTxt.Text);

        }
    }
}