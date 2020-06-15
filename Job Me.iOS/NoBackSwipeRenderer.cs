using DisableSwipe.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(NoBackSwipeRenderer))]
namespace DisableSwipe.iOS
{
    public class NoBackSwipeRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (ViewController != null && ViewController.NavigationController != null)
                ViewController.NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }
    }
}