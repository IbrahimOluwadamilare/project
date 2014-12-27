using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace converter
{
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
            this.textblock1.Text = "Version 1.00 \r\n\r\n Application developed by Oluwadamilare Ibrahim for Attitude Developers";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask newmail = new Microsoft.Phone.Tasks.EmailComposeTask();
            newmail.Subject = "Suggestions submitted";
            newmail.To = "ibrahimoluwadamilare01@outlook.com";
            newmail.Show();
        }

    }
}