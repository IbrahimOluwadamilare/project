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
    public partial class KidnapReportMode : PhoneApplicationPage
    {
        public KidnapReportMode()
        {
            InitializeComponent();
        }
        private void voicek(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/KidnapPivot.xaml?item=0", UriKind.Relative));
        }

        private void videok(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/KidnapPivot.xaml?item=1", UriKind.Relative));
        }

        private void textk(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/KidnapPivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunicationk(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/KidnapPivot.xaml?item=3", UriKind.Relative));
        }
    }
}