
using Microsoft.Maps.MapControl;
using Microsoft.Phone.Shell;
using Microsoft.Practices.Prism.ViewModel;
using MultiplePushpinOnMaps.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace MultiplePushpinOnMaps.ViewModel
{
    public class MapViewModel : NotificationObject
    {
        private LOCATIONS locationItem;
     
        public MapViewModel()
        {
            locationItem = new LOCATIONS();
            ExtractXmlContent();
            setlocation(locationItem.Items);
        }

        private GeoCoordinate currentlocation;
        public GeoCoordinate CurrentLocation
        {
            get
            {
                return currentlocation;
            }
            set
            {
                currentlocation = value;
                RaisePropertyChanged("CurrentLocation");
            }
        }
        //public ICommand SelectionChangedCommands
        //{
        //    get { return selectionChangedCommands ?? (selectionChangedCommands = new DelegateCommand<Pushpin>(p => PushpinTap(p))); }
        //    set { selectionChangedCommands = value; }
        //}
        //private T GetChild<T>(DependencyObject obj, int selectedindex) where T : DependencyObject
        //{
        //    DependencyObject child = null;
        //    for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        //    {
        //        child = VisualTreeHelper.GetChild(obj, i);
        //        if (child != null && child.GetType() == typeof(T))
        //        {
        //            if (i == selectedindex)
        //                break;
        //        }
        //        else if (child != null)
        //        {
        //            child = GetChild<T>(child, selectedindex);
        //            if (child != null && child.GetType() == typeof(T))
        //            {
        //                if (i == selectedindex)
        //                    break;
        //            }
        //        }
        //    }
        //    return child as T;
        //}
        public void ExtractXmlContent()
        {
            XDocument doc = XDocument.Load("locations.xml");
            string xmlcontents = doc.ToString();
            locationItem = XMLDeserializer.Deserialize<LOCATIONS>(xmlcontents);
        }

        public List<LOCATIONSLOCATION> LOCATIONS
        {
            get
            {
                setlocation(locationItem.Items);
                return locationItem.Items;
            }
            set
            {
                locationItem.Items = value;
                RaisePropertyChanged("LOCATIONS");
            }
        }
       
        public void setlocation(List<LOCATIONSLOCATION> location)
        {
            foreach (LOCATIONSLOCATION locationcontent in location)
            {
                locationcontent.LocationName = locationcontent.DESCRIPTION + "-" + locationcontent.ADDRESS;
                locationcontent.Location = new GeoCoordinate(Convert.ToDouble(locationcontent.LATITUDE), Convert.ToDouble(locationcontent.LONGITUDE));
            }
            currentlocation = location[0].Location;
        }

        private List<LOCATIONSLOCATION> LocationData;
        public List<LOCATIONSLOCATION> GetLocationData
        {
            get
            {
                LocationData = new List<LOCATIONSLOCATION>();
                List<LOCATIONSLOCATION> data = new List<LOCATIONSLOCATION>();
                data = LOCATIONS;
                if (data != null)
                {
                    LocationData = data;
                }
                return LocationData;
            }
        }

       
    }
}
