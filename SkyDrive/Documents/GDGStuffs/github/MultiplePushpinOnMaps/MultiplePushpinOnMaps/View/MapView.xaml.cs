using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.Device.Location;
using System.Windows.Input;
using System.Windows.Controls.Primitives;


using System.Windows.Media;
using System.IO.IsolatedStorage;
//using Microsoft.Maps.MapControl;
using Microsoft.Phone.Controls.Maps;
using MultiplePushpinOnMaps.ViewModel;

namespace MultiplePushpinOnMaps.View
{
    public partial class MapView : PhoneApplicationPage
    {
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        MapViewModel _mapViewModel;

        public MapView()
        {
            InitializeComponent();
            _mapViewModel = (MapViewModel)base.DataContext;

        }
        private void PushpinTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            if (pushpin.Content != null)
            {
                StackPanel content = (StackPanel)pushpin.Content;
                if (content.Visibility == Visibility.Collapsed)
                {
                    content.Visibility = Visibility.Visible;
                }

            }
            // to stop the event from going to the parent map control
            e.Handled = true;

        }
        private T GetChild<T>(DependencyObject obj, int selectedindex) where T : DependencyObject
        {
            DependencyObject child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child.GetType() == typeof(T))
                {
                    if (i == selectedindex)
                        break;
                }
                else if (child != null)
                {
                    child = GetChild<T>(child, selectedindex);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        if (i == selectedindex)
                            break;
                    }
                }
            }
            return child as T;
        }
        private void map_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int count = MapPins.Items.Count;
            for (int i = 0; i <= count; i++)
            {
                DependencyObject obj = GetChild<Pushpin>(MapPins, i);
                if (obj != null)
                {
                    Pushpin pin = obj as Pushpin;
                    StackPanel sb = pin.FindName("PushpinStack") as StackPanel;
                    if (sb != null)
                    {
                        sb.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
        }
    }


}