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

namespace MultiplePushpinOnMaps
{
    public partial class MapPage : PhoneApplicationPage
    {
        public MapPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded; 
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            Geoposition position = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5));
            var gpscoordinate = new GeoCoordinate(7.302335, 5.139494);
            geolocator.DesiredAccuracyInMeters = 50;
            myMap.LandmarksEnabled = true;
            myMap.Center = gpscoordinate;
            myMap.PedestrianFeaturesEnabled = true;
            myMap.CartographicMode = MapCartographicMode.Hybrid;
            myMap.SetView(gpscoordinate, 16);
            Pushpin pushpin = (Pushpin)this.FindName("MyPushpin");
            pushpin.Content = "The University Senate Bld.";
            pushpin.GeoCoordinate = new GeoCoordinate(7.302335, 5.139494);
        }

        private void MyPush_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            MessageBox.Show(pushpin.Content.ToString());
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml",UriKind.Relative));
        }
    }
}