using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Synthesis;

namespace Kiddies_Fun_App
{
    public partial class LetterP : PhoneApplicationPage
    {
        SpeechSynthesizer reader;
        public LetterP()
        {
            InitializeComponent();
        }

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            reader = new SpeechSynthesizer();
            await reader.SpeakTextAsync(TextBlock1.Text);
        }
    }
}