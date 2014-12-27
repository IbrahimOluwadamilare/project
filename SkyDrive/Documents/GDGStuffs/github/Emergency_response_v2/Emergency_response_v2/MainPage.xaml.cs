using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Emergency_response_v2.Resources;

namespace Emergency_response_v2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void emergency(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Report_Mode.xaml", UriKind.Relative));
        }

       
    }
}