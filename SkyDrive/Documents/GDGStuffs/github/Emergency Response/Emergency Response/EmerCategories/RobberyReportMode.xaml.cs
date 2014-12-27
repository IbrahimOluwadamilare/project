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
    public partial class RobberyReportMode : PhoneApplicationPage
    {
        public RobberyReportMode()
        {
            InitializeComponent();
        }

        private void voicer(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/RobberyPivot.xaml?item=0", UriKind.Relative));
        }

        private void videor(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/RobberyPivot.xaml?item=1", UriKind.Relative));
        }

        private void textr(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/RobberyPivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunicationr(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/RobberyPivot.xaml?item=3", UriKind.Relative));
        }
    }
}