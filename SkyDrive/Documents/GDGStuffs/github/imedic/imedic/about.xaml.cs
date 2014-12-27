using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace imedic
{
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
            this.textblock1.Text = "Version 1.00 \r\n\r\n Application developed by Team OnHigh for Imagine Cup 2014 ";
        }

    }
}