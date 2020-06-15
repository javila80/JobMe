using FormsVideoLibrary;
using MediaManager;
using MediaManager.Forms;
using MediaManager.Playback;
using Octane.Xamarin.Forms.VideoPlayer.Constants;
//using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoOthers : ContentPage
    {
        public Uri MyProperty { get; set; }
        public VideoOthers(string url, int tipo = 0)
        { 
            InitializeComponent();

            Device.BeginInvokeOnMainThread(() =>
            {
                act.IsRunning = true;
                videoplayer.Source = url;
    
                //await CrossMediaManager.Current.Play(url);
                //CrossMediaManager.Current.StateChanged += Current_StateChanged;
            });
           
            //if (tipo != 0)
            //{

            //    videoPlayer.Source  =new  FileVideoSource
            //    {

            //        File = url,
            //    };
            //}
            //else
            //{
            //    videoPlayer.Source = new UriVideoSource
            //    {
            //        Uri = url,
            //    };
            //}

        }
        private void Current_StateChanged(object sender, StateChangedEventArgs e)
        {
            var z = sender;

            Device.BeginInvokeOnMainThread(() =>
            {
                act.IsRunning = false;
                videoplayer.IsVisible = true;
            });
              
        }

        private void videoplayer_PlayerStateChanged(object sender, Octane.Xamarin.Forms.VideoPlayer.Events.VideoPlayerStateChangedEventArgs e)
        {
            switch (e.CurrentState)
            {
                case PlayerState.Prepared:
                    act.IsRunning = false;
                    break;
                case PlayerState.Completed:
                    // Go back to the previous page once the video completes.
                    break;
                case PlayerState.Error:
                    DisplayAlert("Error Playing Video", "We're sorry but something is wrong with this video.", "OK");
                    break;
            }
        }

        protected async override void OnDisappearing()
        {
            videoplayer.Source = null;
            // await CrossMediaManager.Current.Stop();
            //videoplayer.Source = null;
            //CrossMediaManager.Current.Stop();
            // CrossMediaManager.Current.Dispose();
            base.OnDisappearing();
        }


        //protected override void OnAppearing()
        //{

        //    //Esto es nuevo
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        videoplayer.IsVisible = false;
        //    });

        //    //            videoplayer.IsVisible = false;
        //    base.OnAppearing();
        //}
    }
}