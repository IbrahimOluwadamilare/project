﻿#pragma checksum "C:\Users\Oluwadamilare Ib\Documents\Visual Studio 2013\Projects\EasyPay\EasyPay\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "48DD1083B144570A7862B40EB9E9C84D"
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


namespace SmartPay {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox UsernameTxt;
        
        internal System.Windows.Controls.PasswordBox passwordTxt;
        
        internal System.Windows.Controls.Button loginBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EasyPay;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.UsernameTxt = ((System.Windows.Controls.TextBox)(this.FindName("UsernameTxt")));
            this.passwordTxt = ((System.Windows.Controls.PasswordBox)(this.FindName("passwordTxt")));
            this.loginBtn = ((System.Windows.Controls.Button)(this.FindName("loginBtn")));
        }
    }
}

