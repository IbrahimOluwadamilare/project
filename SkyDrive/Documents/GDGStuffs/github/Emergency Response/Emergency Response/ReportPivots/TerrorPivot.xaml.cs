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
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;


namespace Emergency_Response
{
    public partial class TerrorPivot : PhoneApplicationPage
    {
        public TerrorPivot()
        {
            InitializeComponent();
        }

        public static double latitude;
        public static double longitude;
        public static string erc_phonenumber = "08148289528";
        public static string erc_email_address = "ibrahimoluwadamilare01@outlook.com";


        public async void terror_nocommunication(object sender, EventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            Geoposition position = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(5));
            var gpscoordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            geolocator.DesiredAccuracyInMeters = 20;

            latitude = position.Coordinate.Latitude;
            longitude = position.Coordinate.Longitude;

                string terror_message = "There is a current terrorist attack at Latitude:" + latitude + " and Longitude:" + longitude + " Please we need your help";
                SmsComposeTask terror_alert_sms = new SmsComposeTask();
                terror_alert_sms.To = erc_phonenumber;
                terror_alert_sms.Body = terror_message;
                terror_alert_sms.Show();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //navigation to specific pivot item from main page

            if (NavigationContext.QueryString.ContainsKey("item"))
            {
                var index = NavigationContext.QueryString["item"];
                var indexParsed = int.Parse(index);
                terrorpivot.SelectedIndex = indexParsed;
            }


            base.OnNavigatedTo(e);
        }

        public void terrorpivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pivotResource;

            switch (terrorpivot.SelectedIndex)
            {
                case 0:
                    pivotResource = "Pivot1ApplicationBar";
                    break;

                case 1:
                    pivotResource = "Pivot2ApplicationBar";
                    break;

                case 2:
                    pivotResource = "Pivot3ApplicationBar";
                    break;

                case 3:
                    pivotResource = "Pivot4ApplicationBar";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ApplicationBar = (ApplicationBar)Resources[pivotResource];
        }

    }
}