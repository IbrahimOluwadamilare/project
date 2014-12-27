using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.NetworkInformation;
using Microsoft.Phone.Net.NetworkInformation;
using System.Xml.Linq;

using TweetSharp;

namespace futaRadioApp
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        WebClient client = new WebClient();
        public PivotPage1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            this.Loaded += new RoutedEventHandler(NewsLoad_Loaded);

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //navigation to specific pivot item from main page

            if (NavigationContext.QueryString.ContainsKey("item"))
            {
                var index = NavigationContext.QueryString["item"];
                var indexParsed = int.Parse(index);
                pivotct.SelectedIndex = indexParsed;
            }


            base.OnNavigatedTo(e);
        }


        private void Player_Loaded(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://media.wlmm.dk/limfjord", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            Player.Source = new Uri("http://media.wlmm.dk/limfjord", UriKind.RelativeOrAbsolute);
            Player.Play();
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            /*
                        if (NetworkInterface.GetIsNetworkAvailable())
                        {

                            var service = new TwitterService("DCKCZrG6gSqHGjPAZMBeiDDzj", "VYPhiTcei6cjSBUINeicy6mnJNzqO6T81eUZDGbhCVoNZwCZcc");
                            service.AuthenticateWith("186581066-UmXUIS7QsDehT27UX1M6C8vnnPqBjr9WdU38PG0L", "vqhl5F8YSMqR10z2S3tOm6btMjdGEbVuHjw0QVpBEJG7n");

                            //ScreenName is the profile name of the twitter user.
                            service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = "FUTARadio931FM" }, (ts, rep) =>
                            {
                                if (rep.StatusCode == HttpStatusCode.OK)
                                {
                                    //bind
                                    this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = ts; });
                                }
                            });
                        }
                        else
                        {

                            MessageBox.Show("Please check your internet connestion.");
                        }
                    }

            */

            string searhHasTag = "#futaradio";

            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                var service = new TwitterService("DCKCZrG6gSqHGjPAZMBeiDDzj", "VYPhiTcei6cjSBUINeicy6mnJNzqO6T81eUZDGbhCVoNZwCZcc");
                service.AuthenticateWith("186581066-UmXUIS7QsDehT27UX1M6C8vnnPqBjr9WdU38PG0L", "vqhl5F8YSMqR10z2S3tOm6btMjdGEbVuHjw0QVpBEJG7n");
                tweetList.ItemsSource = null;

                var options = new SearchOptions { Q = searhHasTag, Count = 100 };
                service.Search(options, (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        this.Dispatcher.BeginInvoke(() =>
                        {

                            tweetList.ItemsSource = tweets.Statuses;
                        });
                    }
                });
            }
        }
        void NewsLoad_Loaded(object sender, RoutedEventArgs e)
        {
           
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri("http://www.latestnigeriannews.com/feed/allnews/rss.xml"));
            
        }

        // a method for the rss feeds

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            //loading event the latest news pivot item

            var RSSdata = from rss in XElement.Parse(e.Result).Descendants("item")
                          select new RssItem
                              {
                                  Title = rss.Element("title").Value,
                                  PubDate = rss.Element("pubDate").Value,
                                  Description = rss.Element("description").Value
                              };
            myList.ItemsSource = RSSdata;
        }


        public void pivotct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pivotResource;

            switch (pivotct.SelectedIndex)
            {
                case 0:
                    pivotResource = "Pivot1ApplicationBar";
                    break;

                case 1:
                    pivotResource = "Pivot2ApplicationBar";
                    break;

                case 2:
                    pivotResource = "Pivot3ApplicationBar";
                    break;

                case 3:
                    pivotResource = "Pivot4ApplicationBar";
                    break;


                default:
                    throw new ArgumentOutOfRangeException();
            }

            ApplicationBar = (ApplicationBar)Resources[pivotResource];
        }

        private void tweet_refresh(object sender, EventArgs e)
        {
            
        } 

    }
}