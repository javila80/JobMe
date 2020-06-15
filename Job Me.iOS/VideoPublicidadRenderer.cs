using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using JobMe.iOS;
using JobMe.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoPublicidad), typeof(VideoPublicidadRenderer))]

namespace JobMe.iOS
{
    class VideoPublicidadRenderer : PageRenderer
    {
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }
    }
}