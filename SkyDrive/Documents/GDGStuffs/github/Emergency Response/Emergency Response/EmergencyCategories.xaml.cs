using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Emergency_Response
{
    public partial class EmergencyCategory : PhoneApplicationPage
    {
        public EmergencyCategory()
        {
            InitializeComponent();
        }

        private void robbery(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/RobberyReportMode.xaml", UriKind.Relative));
        }

        private void kidnap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/KidnapReportMode.xaml", UriKind.Relative));
        }

        private void fire(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/FireReportMode.xaml", UriKind.Relative));
        }

        private void accident(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/AccidentReportMode.xaml", UriKind.Relative));
        }

        private void earthquake(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/EarthquakeReportMode.xaml", UriKind.Relative));
        }

        private void flood(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/FloodReportMode.xaml", UriKind.Relative));
        }

        private void terror(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmerCategories/TerrorReportMode.xaml", UriKind.Relative));
        }
    }
}