using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using futaRadioApp.Resources;

namespace futaRadioApp
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
        private void Grid_latestNews_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml?item=3", UriKind.Relative));
        }

        private void Grid_shoutOut_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml?item=2", UriKind.Relative));
        }

        private void Grid_stationGuide_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml?item=1", UriKind.Relative));
        }

        private void Grid_lunchStation_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml?item=0", UriKind.Relative));
        }

    }
}