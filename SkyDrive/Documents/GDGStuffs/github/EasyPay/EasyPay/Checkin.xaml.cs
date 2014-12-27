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

namespace SmartPay
{
    public partial class Checkin : PhoneApplicationPage
    {
        public Checkin()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded; 
            
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMap();
        }

        private async void UpdateMap()
        {
            Geolocator geolocator = new Geolocator();
            Geoposition position = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5));
            var gpscoordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            geolocator.DesiredAccuracyInMeters = 50;
            myMap.LandmarksEnabled = true;
            myMap.Center = gpscoordinate;
            myMap.PedestrianFeaturesEnabled = true;
            myMap.CartographicMode = MapCartographicMode.Road;
            myMap.SetView(gpscoordinate, 15);
            Pushpin pushpin = (Pushpin)this.FindName("MyPushpin");
            pushpin.GeoCoordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);

            //mymap.SetView(new GeoCoordinate(7.299569D, 5.136380D), 17D);
        }

        private void MyPushpin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            MessageBox.Show(pushpin.Content.ToString());
        }

    }
}