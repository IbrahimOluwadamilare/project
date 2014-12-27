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
    public partial class FloodReportMode : PhoneApplicationPage
    {
        public FloodReportMode()
        {
            InitializeComponent();
        }

        private void voiceflood(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FloodPivot.xaml?item=0", UriKind.Relative));
        }

        private void videoflood(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FloodPivot.xaml?item=1", UriKind.Relative));
        }

        private void textflood(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FloodPivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunicationflood(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FloodPivot.xaml?item=3", UriKind.Relative));
        }

    }
}