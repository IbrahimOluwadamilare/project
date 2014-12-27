using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using converter.Resources;
using WPET;

namespace converter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool convertValue1;
        Settings<string> convertionType = new Settings<string>("ConvertionType", "Distance");

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void SetupLabels()
        {
            if (convertionType.Value == "Distance")
            {
                this.Heading.Text = "Distance";
                textBlock1.Text = "Kilometer";
                textBlock2.Text = "Meters";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else if (convertionType.Value == "Temperature")
            {
                this.Heading.Text = "Temperature";
                textBlock1.Text = "Fahrenheight";
                textBlock2.Text = "Celsius";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else if (convertionType.Value == "Time")
            {
                this.Heading.Text = "Time";
                textBlock1.Text = "Hours";
                textBlock2.Text = "Seconds";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else if (convertionType.Value == "Land_Mass")
            {
                this.Heading.Text = "Land Mass";
                textBlock1.Text = "Hectares";
                textBlock2.Text = "Acers";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else if (convertionType.Value == "Power")
            {
                this.Heading.Text = "Electrical Power";
                textBlock1.Text = "Kilowatts";
                textBlock2.Text = "Horsepower";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else if (convertionType.Value == "Volume")
            {
                this.Heading.Text = "Metric Volume";
                textBlock1.Text = "Cubic Meteres";
                textBlock2.Text = "Gallons";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            SetupLabels();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            switch (convertionType.Value)
            {
                    //temperature convertion values
                case "Temperature":
                    {
                        if (convertValue1)
                        {
                            TextBox2.Text = "";
                            try
                            {
                                double fahrenheightValue = double.Parse(TextBox1.Text);
                                double celsiusValue = (fahrenheightValue - 32) * (5.0 / 9.0);
                                TextBox2.Text = celsiusValue.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            TextBox1.Text = "";
                            try
                            {
                                double celsiusValue = double.Parse(TextBox2.Text);
                                double fahrenheitValue = (celsiusValue * (9.0 / 5.0)) + 32;
                                TextBox1.Text = fahrenheitValue.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;

                    // distance convertion values
                case "Distance":
                    {
                        if (convertValue1)
                        {
                            TextBox2.Text = "";
                            try
                            {
                                double kmValue = double.Parse(TextBox1.Text);
                                double mtValue = 1000 * kmValue;
                                TextBox2.Text = mtValue.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            TextBox1.Text = "";
                            try
                            {
                                double mtvalue = double.Parse(TextBox2.Text);
                                double kmValue = mtvalue / 1000;
                                TextBox1.Text = kmValue.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;

                    //time convertion values
                case "Time": 
                    {
                        if (convertValue1) 
                        {
                            TextBox2.Text = "";
                            try 
                            {
                                double hours = double.Parse(TextBox1.Text);
                                double seconds = hours * 60 * 60;
                                TextBox2.Text = seconds.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else 
                            {
                             TextBox1.Text = "";
                            try 
                            {
                                double seconds = double.Parse(TextBox2.Text);
                                double hours = seconds / (60 * 60);
                                TextBox1.Text = hours.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                            }
                        }
                    break;

                    // land mass convertion values
                case "Land_Mass":
                    {
                        if (convertValue1)
                        {
                            TextBox2.Text = "";
                            try
                            {
                                double cvolume = double.Parse(TextBox1.Text);
                                double gallons = cvolume * 264.172;
                                TextBox2.Text = gallons.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            TextBox1.Text = "";
                            try
                            {
                                double gallons = double.Parse(TextBox2.Text);
                                double cvolume = gallons * 0.00378541;
                                TextBox1.Text = cvolume.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;

                    //power convertion values

                case "Power":
                    {
                        if (convertValue1)
                        {
                            TextBox2.Text = "";
                            try
                            {
                                double kilowatts = double.Parse(TextBox1.Text);
                                double horsepower = kilowatts * 1.34102;
                                TextBox2.Text = horsepower.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            TextBox1.Text = "";
                            try
                            {
                                double horsepower = double.Parse(TextBox2.Text);
                                double kilowatts = horsepower * 0.745700;
                                TextBox1.Text = kilowatts.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;

                    //volume convertion values
                case "Volume":
                    {
                        if (convertValue1)
                        {
                            TextBox2.Text = "";
                            try
                            {
                                double hours = double.Parse(TextBox1.Text);
                                double seconds = hours * 60 * 60;
                                TextBox2.Text = seconds.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            TextBox1.Text = "";
                            try
                            {
                                double seconds = double.Parse(TextBox2.Text);
                                double hours = seconds / (60 * 60);
                                TextBox1.Text = hours.ToString();
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;
                    }
            this.Focus();
            }
     

        private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        private void ChooseTemperatureConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Temperature";
            SetupLabels();
        }

        private void ChooseDistanceConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Distance";
            SetupLabels();
        }
        private void ChooseTimeConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Time";
            SetupLabels();
        }

        private void ChooseVolumeConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Volume";
            SetupLabels();
        }
        private void ChooseLandMassConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Land_Mass";
            SetupLabels();
        }
        private void ChoosePowerConvertion_Click(object sender, EventArgs e)
        {
            convertionType.Value = "Power";
            SetupLabels();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        private void about_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml", UriKind .Relative));
        }
                   

    }
}