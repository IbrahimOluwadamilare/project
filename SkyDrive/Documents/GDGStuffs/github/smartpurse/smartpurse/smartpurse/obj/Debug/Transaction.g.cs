﻿#pragma checksum "C:\Users\Algorithm\Desktop\new\smartpurse\smartpurse\smartpurse\Transaction.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7FC87FCF745DC05669DC461DBA0B280B"
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
    
    
    public partial class Transaction : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox recieverTxt;
        
        internal System.Windows.Controls.TextBox payerTxt;
        
        internal System.Windows.Controls.TextBox amountTxt;
        
        internal System.Windows.Controls.PasswordBox pinTxt;
        
        internal System.Windows.Controls.Button mPaymentBtn;
        
        internal System.Windows.Controls.Button scanBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/smartpurse;component/Transaction.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.recieverTxt = ((System.Windows.Controls.TextBox)(this.FindName("recieverTxt")));
            this.payerTxt = ((System.Windows.Controls.TextBox)(this.FindName("payerTxt")));
            this.amountTxt = ((System.Windows.Controls.TextBox)(this.FindName("amountTxt")));
            this.pinTxt = ((System.Windows.Controls.PasswordBox)(this.FindName("pinTxt")));
            this.mPaymentBtn = ((System.Windows.Controls.Button)(this.FindName("mPaymentBtn")));
            this.scanBtn = ((System.Windows.Controls.Button)(this.FindName("scanBtn")));
        }
    }
}

