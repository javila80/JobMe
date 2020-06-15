using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JobMe.Droid;
using JobMe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VideoPublicidad), typeof(NoStatusBarPageRenderer))]
namespace JobMe.Droid
{
    public class NoStatusBarPageRenderer : PageRenderer
    {
        global::Android.Views.View view;

        public NoStatusBarPageRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            WindowManagerFlags _originalFlags;
            try
            {
                var activity = this.Context as Activity;
                var attrs = activity.Window.Attributes;
                _originalFlags = attrs.Flags;
                attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
                activity.Window.Attributes = attrs;

                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"            ERROR: ", ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            WindowManagerFlags _originalFlags;
            var activity = this.Context as Activity;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.ForceNotFullscreen;
            activity.Window.Attributes = attrs;

        }
    }
}