﻿#pragma checksum "C:\Users\Oluwadamilare Ib\Documents\Visual Studio 2013\Projects\MultiplePushpinOnMaps\MultiplePushpinOnMaps\View\MapView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "61E03B6C8F70372ED197088F36613B2D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MultiplePushpinOnMaps.View {
    
    
    public partial class MapView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Maps.Map map;
        
        internal Microsoft.Phone.Controls.Maps.MapItemsControl MapPins;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MultiplePushpinOnMaps;component/View/MapView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.map = ((Microsoft.Phone.Controls.Maps.Map)(this.FindName("map")));
            this.MapPins = ((Microsoft.Phone.Controls.Maps.MapItemsControl)(this.FindName("MapPins")));
        }
    }
}

