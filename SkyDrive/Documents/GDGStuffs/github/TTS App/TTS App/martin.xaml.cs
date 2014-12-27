using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TTS_App.Resources;
using Windows.Phone.Speech.Synthesis;

namespace TTS_App
{
    public partial class MainPage : PhoneApplicationPage
    {

        SpeechSynthesizer reader;
       // System.Speech.Synthesis.SynthesizerState reader;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.textbox1.Text = "I have a dream that one day Nigeria will be the Hub of technological advancement in the world ";
        }
        private async void play_Click(object sender, EventArgs e)
        {
                
                reader = new SpeechSynthesizer();
                await reader.SpeakTextAsync(textbox1.Text);
                reader.Dispose();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            reader.Dispose();
        }

    }
}