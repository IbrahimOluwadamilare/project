﻿#pragma checksum "C:\Users\Oluwadamilare Ib\Documents\Visual Studio 2013\Projects\smartpurse\smartpurse\AccountPasswordRetrival.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B9B3480B4512C29BBC01A42ED61166F0"
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
    
    
    public partial class AccountPasswordRetrival : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox Fullname;
        
        internal System.Windows.Controls.TextBox Phonenumber;
        
        internal System.Windows.Controls.TextBox Emailaddress;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/smartpurse;component/AccountPasswordRetrival.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Fullname = ((System.Windows.Controls.TextBox)(this.FindName("Fullname")));
            this.Phonenumber = ((System.Windows.Controls.TextBox)(this.FindName("Phonenumber")));
            this.Emailaddress = ((System.Windows.Controls.TextBox)(this.FindName("Emailaddress")));
        }
    }
}
