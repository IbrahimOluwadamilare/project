using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Emergency_response_v2
{
    public partial class Report_Mode : PhoneApplicationPage
    {
        public Report_Mode()
        {
            InitializeComponent();
        }

        private void voicereport(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/AccidentPivot.xaml?item=0", UriKind.Relative));
        }

        private void videoreport(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/AccidentPivot.xaml?item=1", UriKind.Relative));
        }

        private void textmessagingreport(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/AccidentPivot.xaml?item=2", UriKind.Relative));
        }

        private void nocommunication(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ReportPivots/AccidentPivot.xaml?item=3", UriKind.Relative));
        }
    }
}