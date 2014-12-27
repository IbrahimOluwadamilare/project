using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Emergency_Response
{
    public partial class FloodPivot : PhoneApplicationPage
    {
        public FloodPivot()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //navigation to specific pivot item from main page

            if (NavigationContext.QueryString.ContainsKey("item"))
            {
                var index = NavigationContext.QueryString["item"];
                var indexParsed = int.Parse(index);
                floodpivot.SelectedIndex = indexParsed;
            }


            base.OnNavigatedTo(e);
        }

        public void floodpivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pivotResource;

            switch (floodpivot.SelectedIndex)
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