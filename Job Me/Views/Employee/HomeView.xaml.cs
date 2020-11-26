using System;
using System.IO;
using System.Net;
using JobMe.ViewModels;
using Syncfusion.XForms.AvatarView;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentView
    {
        //  HomeViewModel vm = new HomeViewModel();

        public HomeView()
        {
            InitializeComponent();
        }

        //Logo de premium
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Job Me", "Próximamente", "OK");

            //await Navigation.PushAsync(new Credit() { Title = "Premium" });
        }
      

        //Click en el CV
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            int userid = Preferences.Get("UserID", 0);

            if (userid != 0)
            {
                await Navigation.PushAsync(new CV(userid) { Title = "CV" });
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
            }
        }

       
        //private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        //{
        //    var z = ()
        //    await Navigation.PushAsync(new LargePhoto() { Title = Preferences.Get("Name", string.Empty) });
        //}

        private async void btnAcademics_Clicked(object sender, EventArgs e)
        {
            int userid = Preferences.Get("UserID", 0);

            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var fname = Path.Combine(documentsPath, @"Media/" + Preferences.Get("UserName", string.Empty) + "_acads.mp4");

            var path = Preferences.Get("AcadVideo", string.Empty);

            string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + "_acads.mp4";
            UriVideoSource uriVideoSurce;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    //var fill = File.Exists(fname);

                    //if (fill)
                    //{
                    //    await Navigation.PushAsync(new PlayVideo(fname) { Title = "Academics Video" });
                    //}
                    //else
                    //{
                    if (CheckLink(url))
                    {
                        await Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video" });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                    }

                    //}

                    break;

                case Device.Android:

                    if (File.Exists(path))
                    {
                        await Navigation.PushAsync(new PlayVideo(path) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video" });
                    }
                    else
                    {
                        if (CheckLink(url))
                        {
                            // await App.Navigation.PushAsync(new MiWebView(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video", });
                            await Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video" });
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                        }
                    }

                    break;
            };
        }

        private async void btnJobs_Clicked(object sender, EventArgs e)
        {
            int userid = Preferences.Get("UserID", 0);

            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var fname = Path.Combine(documentsPath, @"Media/" + Preferences.Get("UserName", string.Empty) + "_jobs.mp4");

            var path = Preferences.Get("JobsVideo", string.Empty);

            string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + "_jobs.mp4";
            UriVideoSource uriVideoSurce;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    //var fill = File.Exists(fname);

                    //if (fill)
                    //{
                    //    await Navigation.PushAsync(new VideoJobs(fname) { Title = "Jobs Video" });
                    //}
                    //else
                    //{
                    if (CheckLink(url))
                    {
                        await Navigation.PushAsync(new VideoJobs(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de empleos" : "Jobs Video" });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                    }
                    //await Navigation.PushAsync(new PlayVideo(url) { Title = "Jobs Video" });

                    //}

                    break;

                case Device.Android:

                    if (File.Exists(path))
                    {
                        await Navigation.PushAsync(new VideoJobs(path) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de empleos" : "Jobs Video" });
                    }
                    else
                    {
                        if (CheckLink(url))
                        {
                            await Navigation.PushAsync(new VideoJobs(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de empleos" : "Jobs Video" });
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                        }
                    }

                    break;
            };
        }

        private async void btnOthers_Clicked(object sender, EventArgs e)
        {
            int userid = Preferences.Get("UserID", 0);

            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var fname = Path.Combine(documentsPath, @"Media/" + Preferences.Get("UserName", string.Empty) + "_others.mp4");

            var path = Preferences.Get("OthersVideo", string.Empty);

            string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + "_others.mp4";
            UriVideoSource uriVideoSurce;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    //var fill = File.Exists(fname);

                    //if (fill)
                    //{
                    //    await Navigation.PushAsync(new VideoOthers(fname) { Title = "Others Video" });
                    //}
                    //else
                    //{
                    if (CheckLink(url))
                    {
                        await Navigation.PushAsync(new VideoOthers(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de otros" : "Others Video" });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                    }

                    //}

                    break;

                case Device.Android:

                    if (File.Exists(path))
                    {
                        await Navigation.PushAsync(new VideoOthers(path) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de otros" : "Others Video" });
                    }
                    else
                    {
                        if (CheckLink(url))
                        {
                            await Navigation.PushAsync(new VideoOthers(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video de otros" : "Others Video" });
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                        }
                    }

                    break;
            };
        }

        private bool CheckLink(string url)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                return false;
                /* A WebException will be thrown if the status of the response is not `200 OK` */
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                }
            }
        }
        //click en la imagen
        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var image = (FFImageLoading.Forms.CachedImage)sender;

            

            await Navigation.PushAsync(new LargePhoto(image) { Title = Preferences.Get("Name", string.Empty) });
        }
    }
}