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
    public partial class Receive : PhoneApplicationPage
    {
        public Receive()
        {
            InitializeComponent();
        }

        private void QRRecBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScanQR.xaml", UriKind.Relative));
        }
    }
}