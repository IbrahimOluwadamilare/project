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
    public partial class Payment : PhoneApplicationPage
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void QRPayBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DisplayQR.xaml", UriKind.Relative));
        }

       
    }
}