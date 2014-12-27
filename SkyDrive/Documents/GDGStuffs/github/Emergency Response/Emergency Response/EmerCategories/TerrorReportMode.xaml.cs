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
    public partial class TerrorReportMode : PhoneApplicationPage
    {
        public TerrorReportMode()
        {
            InitializeComponent();
        }

        private void voicet(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/TerrorPivot.xaml?item=0", UriKind.Relative));
        }

        private void videot(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/TerrorPivot.xaml?item=1", UriKind.Relative));
        }

        private void textt(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/TerrorPivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunicationt(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/TerrorPivot.xaml?item=3", UriKind.Relative));
        }
    }
}