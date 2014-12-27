using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Kiddies_Fun_App.Resources;
using System.Threading;

namespace Kiddies_Fun_App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Thread.Sleep(3000);
        }



        private void Nursrey_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Nursery.xaml",UriKind.Relative));
        }

        private void Animal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Animal_Sounds.xaml", UriKind.Relative));
        }

        private void English_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/English_Alphabets.xaml", UriKind.Relative));
        }
    }
}