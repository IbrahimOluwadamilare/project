﻿#pragma checksum "C:\Users\Algorithm\Desktop\new\smartpurse\smartpurse\smartpurse\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "52BD2A914A62C5CBF4350697B7636A23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
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
    
    
    public partial class HomePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image recieveBtn;
        
        internal System.Windows.Controls.Image sendBtn;
        
        internal System.Windows.Controls.Image checkInBtn;
        
        internal System.Windows.Controls.Image accountBtn;
        
        internal System.Windows.Controls.Image aboutBtn;
        
        internal System.Windows.Controls.Image exitBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/smartpurse;component/HomePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.recieveBtn = ((System.Windows.Controls.Image)(this.FindName("recieveBtn")));
            this.sendBtn = ((System.Windows.Controls.Image)(this.FindName("sendBtn")));
            this.checkInBtn = ((System.Windows.Controls.Image)(this.FindName("checkInBtn")));
            this.accountBtn = ((System.Windows.Controls.Image)(this.FindName("accountBtn")));
            this.aboutBtn = ((System.Windows.Controls.Image)(this.FindName("aboutBtn")));
            this.exitBtn = ((System.Windows.Controls.Image)(this.FindName("exitBtn")));
        }
    }
}

