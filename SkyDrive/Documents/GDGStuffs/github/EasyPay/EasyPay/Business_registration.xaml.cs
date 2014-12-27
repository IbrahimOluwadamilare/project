using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartPay
{
    public partial class Business_registration : PhoneApplicationPage
    {
        public Business_registration()
        {
            InitializeComponent();
        }

        private void agreeChk_Checked(object sender, RoutedEventArgs e)
        {
            regBtn.IsEnabled = true;
        }

        private void agreeChk_Unchecked(object sender, RoutedEventArgs e)
        {
            regBtn.IsEnabled = false;
        }

        private void busNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (busNameTxt.Text == "business name")
            {
                busNameTxt.Text = "";
            }
        }

        private void busNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (busNameTxt.Text == "")
            {
                busNameTxt.Text = "business name";
            }
        }

        private void phoneNoTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (phoneNoTxt.Text == "phone no")
            {
                phoneNoTxt.Text = "";
            }
        }

        private void phoneNoTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (phoneNoTxt.Text == "")
            {
                phoneNoTxt.Text = "phone no";
            }
        }

        private void addressTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (addressTxt.Text == "address")
            {
                addressTxt.Text = "";
            }
        }

        private void addressTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addressTxt.Text == "")
            {
                addressTxt.Text = "address";
            }
        }

        private void emailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailTxt.Text == "email address")
            {
                emailTxt.Text = "";
            }
        }

        private void emailTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailTxt.Text == "")
            {
                emailTxt.Text = "email address";
            }
        }

        private void usernameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTxt.Text == "username") { usernameTxt.Text = ""; }
        }

        private void usernameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTxt.Text == "") { usernameTxt.Text = "username"; }
        }
    }
}