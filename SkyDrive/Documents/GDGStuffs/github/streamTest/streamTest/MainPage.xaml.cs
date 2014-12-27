using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using streamTest.Resources;
using System.Windows.Threading;

namespace streamTest
{
    public partial class MainPage : PhoneApplicationPage
    {
      SystemMediaTransportControls systemControls;
    public MainPage()
    {
        this.InitializeComponent();

    }

    void InitializeTransportControls()
    {
        // Hook up app to system transport controls.
        systemControls = SystemMediaTransportControls.GetForCurrentView();
        systemControls.ButtonPressed += SystemControls_ButtonPressed;

        // Register to handle the following system transpot control buttons.
        systemControls.IsPlayEnabled = true;
        systemControls.IsPauseEnabled = true;
    }

    void MusicPlayer_CurrentStateChanged(object sender, RoutedEventArgs e)
    {
        switch (mediaplayer.CurrentState)
        {
            case MediaElementState.Playing:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                break;
            case MediaElementState.Paused:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                break;
            case MediaElementState.Stopped:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Stopped;
                break;
            case MediaElementState.Closed:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;
                break;
            default:
                break;
        }
    }

    void SystemControls_ButtonPressed(SystemMediaTransportControls sender,
SystemMediaTransportControlsButtonPressedEventArgs args)
    {
        switch (args.Button)
        {
            case SystemMediaTransportControlsButton.Play:
                PlayMedia();
                break;
            case SystemMediaTransportControlsButton.Pause:
                PauseMedia();
                break;
            default:
                break;
        }
    }

    async void PlayMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            mediaplayer.Play();
        });
    }

    async void PauseMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            mediaplayer.Pause();
        });
    }

    private void cmdPlay_Click(object sender, RoutedEventArgs e)
    {
        mediaplayer.Source = new Uri("http://media.wlmm.dk/limfjord", UriKind.Absolute);
        mediaplayer.Play();
    }

    private void cmdStop_Click(object sender, RoutedEventArgs e)
    {
        mediaplayer.Stop();

    }

    private void mediaplayer_CurrentStateChanged(object sender, RoutedEventArgs e)
    {

    }
}

}