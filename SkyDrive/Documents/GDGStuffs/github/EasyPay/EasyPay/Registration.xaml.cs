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
    public partial class Registration : PhoneApplicationPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void business_registration(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Business_registration.xaml", UriKind.Relative));
        }
        private void individual_registration(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Individual_registration.xaml", UriKind.Relative));
        }
    }
}