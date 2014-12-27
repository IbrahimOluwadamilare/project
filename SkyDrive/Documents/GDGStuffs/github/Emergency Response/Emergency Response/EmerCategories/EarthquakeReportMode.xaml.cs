using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Emergency_Response.EmergencyCategories
{
    public partial class EarthquakeReportMode : PhoneApplicationPage
    {
        public EarthquakeReportMode()
        {
            InitializeComponent();
        }

        private void voice(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/EarthquakePivot.xaml?item=0", UriKind.Relative));
        }

        private void video(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/EarthquakePivot.xaml?item=1", UriKind.Relative));
        }

        private void text(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/EarthquakePivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunication(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/EarthquakePivot.xaml?item=3", UriKind.Relative));
        }
    }
}