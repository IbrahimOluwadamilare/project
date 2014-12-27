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
    public partial class Registration : PhoneApplicationPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void indBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/IndividualRegistration.xaml", UriKind.Relative));
        }

        private void busBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BusinessRegistration.xaml", UriKind.Relative));
        }

       
    }
}