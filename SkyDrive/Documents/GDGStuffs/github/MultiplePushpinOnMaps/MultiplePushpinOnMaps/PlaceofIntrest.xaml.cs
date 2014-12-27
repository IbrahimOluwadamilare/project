using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using MultiplePushpinOnMaps.Resources;

namespace MultiplePushpinOnMaps
{
    public partial class PlaceofIntrest : PhoneApplicationPage
    {
        public PlaceofIntrest()
        {
            InitializeComponent();
        }

        private void senate(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
            NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
            
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

    }
}