using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiWebView : ContentPage
    {
        public event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        private double _width = 0;
        private double _height = 0;

        public MiWebView(string url)
        {
            InitializeComponent();
            OnOrientationChanged += DeviceRotated;
            webView.Source = url;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var oldWidth = _width;
            const double sizenotallocated = -1;

            base.OnSizeAllocated(width, height);
            if (Equals(_width, width) && Equals(_height, height)) return;

            _width = width;
            _height = height;

            // ignore if the previous height was size unallocated
            if (Equals(oldWidth, sizenotallocated)) return;

            // Has the device been rotated ?
            if (!Equals(width, oldWidth))
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((width < height) ? PageOrientation.Vertical : PageOrientation.Horizontal));
        }

        // called when the device orientation changed
        private void DeviceRotated(object sender, PageOrientationEventArgs e)
        {
            switch (e.Orientation)
            {
                case PageOrientation.Horizontal:
                    webView.HeightRequest = this._height;
                    webView.WidthRequest = this._width;
                    break;

                case PageOrientation.Vertical:
                    webView.HeightRequest = this._height / 2.5;
                    webView.WidthRequest = this._width;
                    break;

                default:
                    break;
            }
        }
    }

    public class PageOrientationEventArgs : EventArgs
    {
        public PageOrientationEventArgs(PageOrientation orientation)
        {
            Orientation = orientation;
        }

        public PageOrientation Orientation { get; }
    }

    public enum PageOrientation
    {
        Horizontal = 0,
        Vertical = 1,
    }
}