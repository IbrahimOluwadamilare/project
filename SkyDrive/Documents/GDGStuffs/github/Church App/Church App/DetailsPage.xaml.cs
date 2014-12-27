using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Church_App
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml",UriKind.Relative));
        }
        private void App_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void App_Click2(object sender, EventArgs e)
        {
            NavigationService.GoForward();
        }
    }
}