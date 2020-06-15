using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace JobMe.iOS
{
    public class NoStatusBarPageRenderer : PageRenderer
    {
        public NoStatusBarPageRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.Fade);

            base.ViewWillAppear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            UIApplication.SharedApplication.SetStatusBarHidden(false, UIStatusBarAnimation.Fade);

            base.ViewDidDisappear(animated);
        }
    }
}