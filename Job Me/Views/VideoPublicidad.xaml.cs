using FormsVideoLibrary;
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
    public partial class VideoPublicidad : ContentPage
    {
        public VideoPublicidad()
        {
            InitializeComponent();

            videoPlayer.IsVisible = false;
            boton.IsVisible = false;
            PlayVideo();
        }

        private async void PlayVideo()
        {
            await Task.Delay(400);

            videoPlayer.IsVisible = true;
            boton.IsVisible = true;
            string path = string.Empty;

            Random random = new Random();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    boton.TextColor = Color.Black;
                    boton.BackgroundColor = Color.WhiteSmoke;
                    boton.Opacity = .5;

                    if (random.Next(3) == 1)
                    {
                        path = "Videos/Jobme1.mp4";
                    }
                    else
                    {
                        path = "Videos/Jobme2.mp4";
                    }

                    break;

                case Device.Android:
                    boton.TextColor = Color.Black;
                    boton.BackgroundColor = Color.WhiteSmoke;
                    boton.Opacity = .5;
                    videoPlayer.HorizontalOptions = LayoutOptions.Fill;
                    videoPlayer.VerticalOptions = LayoutOptions.Fill;
                    boton.HeightRequest = 50;
                    if (random.Next(3) == 1)
                    {
                        path = "Jobme1.mp4";
                    }
                    else
                    {
                        path = "Jobme2.mp4";
                    }

                    break;
            };

            videoPlayer.Source = new ResourceVideoSource()
            {
                Path = path
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            videoPlayer.Stop();

            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "AllowLandscape");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "PreventLandscape");
        }
    }
}