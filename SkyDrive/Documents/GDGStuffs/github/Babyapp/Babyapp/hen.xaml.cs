using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Babyapp
{
    public partial class hen : PhoneApplicationPage
    {
        public hen()
        {
            InitializeComponent();
        }

        private void Image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.media2.Play();
        }

        private void main_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}