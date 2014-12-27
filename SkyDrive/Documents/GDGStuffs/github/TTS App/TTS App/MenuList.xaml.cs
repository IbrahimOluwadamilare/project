using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TTS_App
{
    public partial class MenuList : PhoneApplicationPage
    {
        public MenuList()
        {
            InitializeComponent();
        }

        private void click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/martin.xaml",UriKind .Relative));
        }
    }
}