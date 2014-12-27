using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Babyapp.Resources;

namespace Babyapp
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

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.media.Play();
        }

        private void hen_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/hen.xaml",UriKind.Relative));
        }

    }
}