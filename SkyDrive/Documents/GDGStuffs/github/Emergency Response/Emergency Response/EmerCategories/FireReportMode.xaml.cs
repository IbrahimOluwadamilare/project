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
    public partial class FireReportMode : PhoneApplicationPage
    {
        public FireReportMode()
        {
            InitializeComponent();
        }

        private void voicef(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FirePivot.xaml?item=0", UriKind.Relative));
        }

        private void videof(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FirePivot.xaml?item=1", UriKind.Relative));
        }

        private void textf(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FirePivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunicationf(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/FirePivot.xaml?item=3", UriKind.Relative));
        }
    }
}