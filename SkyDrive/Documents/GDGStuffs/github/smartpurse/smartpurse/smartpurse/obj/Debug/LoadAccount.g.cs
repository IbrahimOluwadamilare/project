﻿#pragma checksum "C:\Users\Oluwadamilare Ib\Documents\Visual Studio 2013\Projects\smartpurse\smartpurse\smartpurse\LoadAccount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53161A87E75EA66F61D838B77CAC1D35"
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


namespace smartpurse {
    
    
    public partial class LoadAccount : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.ListPicker BankOptions;
        
        internal Microsoft.Phone.Controls.ListPickerItem option1;
        
        internal Microsoft.Phone.Controls.ListPickerItem option2;
        
        internal Microsoft.Phone.Controls.ListPickerItem option3;
        
        internal Microsoft.Phone.Controls.ListPickerItem option4;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/smartpurse;component/LoadAccount.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.BankOptions = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("BankOptions")));
            this.option1 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("option1")));
            this.option2 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("option2")));
            this.option3 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("option3")));
            this.option4 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("option4")));
        }
    }
}

