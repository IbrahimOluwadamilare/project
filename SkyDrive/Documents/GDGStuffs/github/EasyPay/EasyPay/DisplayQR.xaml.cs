using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ZXing;
using System.Windows.Media.Imaging;

namespace SmartPay
{
    public partial class DisplayQR : PhoneApplicationPage
    {
        public DisplayQR()
        {
            InitializeComponent();
        }
        private static WriteableBitmap Generator(string qrinfo)
        {
            BarcodeWriter write = new BarcodeWriter();
            write.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {
                Foreground = System.Windows.Media.Color.FromArgb(0, 0, 0, 0)
            };
            write.Format = BarcodeFormat.QR_CODE;
            write.Options.Height = 400;
            write.Options.Width = 400;
            write.Options.Margin = 1;

            var code = write.Write(qrinfo);

            return code;
        }
    }
}