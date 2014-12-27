using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MultiplePushpinOnMaps.Resources;
using Microsoft.Phone.Tasks;
using System.Device.Location;


namespace MultiplePushpinOnMaps
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if ExtendedSplashscreen.xaml is on the backstack  and remove 
            if (NavigationService.BackStack.Count() == 1)
            {
                NavigationService.RemoveBackEntry();
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/MapView.xaml", UriKind.Relative));
        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Checkin.xaml", UriKind.Relative));
        }

        private void directionbutton_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Creating new Object of Bing Maps Directions Task and Intialize it with Starting and Ending Location Points
            BingMapsDirectionsTask bing = new BingMapsDirectionsTask()
            {
                //Giving label and coordinates to starting and ending points. 

                Start = new LabeledMapLocation("Digital Resource Center", new GeoCoordinate(7.305188,5.133730)),
                End = new LabeledMapLocation("University Senate Building", new GeoCoordinate(7.302335,5.139494))
            };
            // Launching Bing Maps Direction Tasks
            bing.Show();

        }

        private void About(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void placesofintrest(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PlaceofIntrest.xaml", UriKind.Relative));
        }
    }

    }
