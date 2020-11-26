using JobMe.ViewModels.Employer;
using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsVideoLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Essentials;
using MLToolkit.Forms.SwipeCardView;
using System.Collections.ObjectModel;
using JobMe.Models;
using System.IO;
using Syncfusion.SfPdfViewer.XForms;
using System.Net;
using JobMe.ViewModels;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PositionSelectedView : ContentPage
    {
        public PositionSelectedView(ListaPositions p)
        {
            PositionSelectedViewViewModel vm = new PositionSelectedViewViewModel(p);
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        private void OnDragging(object sender, DraggingCardEventArgs e)
        {
            var view = (Xamarin.Forms.View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");
            //var superLikeFrame = view.FindByName<Frame>("SuperLikeFrame");
            var threshold = (this.BindingContext as PositionSelectedViewViewModel).Threshold;

            var draggedXPercent = e.DistanceDraggedX / threshold;

            var draggedYPercent = e.DistanceDraggedY / threshold;

            switch (e.Position)
            {
                case DraggingCardPosition.Start:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    //superLikeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;

                case DraggingCardPosition.UnderThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = (-1) * draggedXPercent;
                        nopeButton.Scale = 1 + draggedXPercent / 2;
                        //superLikeFrame.Opacity = 0;
                        //superLikeButton.Scale = 1;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = draggedXPercent;
                        likeButton.Scale = 1 - draggedXPercent / 2;
                        //superLikeFrame.Opacity = 0;
                        //superLikeButton.Scale = 1;
                    }
                    else if (e.Direction == SwipeCardDirection.Up)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 0;
                        nopeButton.Scale = 1;
                        likeButton.Scale = 1;
                        //superLikeFrame.Opacity = (-1) * draggedYPercent;
                        //superLikeButton.Scale = 1 + draggedYPercent / 2;
                    }
                    break;

                case DraggingCardPosition.OverThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = 1;
                        //superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = 1;
                        //superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Up)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 0;
                        //superLikeFrame.Opacity = 1;
                    }
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    //superLikeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;

                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    //superLikeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    //superLikeButton.Scale = 1;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDislikeClicked(object sender, EventArgs e)
        {
            this.SwipeCardView.InvokeSwipe(SwipeCardDirection.Left);
        }

        private void OnLikeClicked(object sender, EventArgs e)
        {
            this.SwipeCardView.InvokeSwipe(SwipeCardDirection.Right);
        }

        //Video Academics
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                //VideoPlayer video;
                //var stack = (popupLayout as SfPopupLayout).PopupView.ContentTemplate.CreateContent();
                //video = (stack as AbsoluteLayout).FindByName<VideoPlayer>("videoPlayer");

                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");

                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                //vm.MiVideo = new UriVideoSource
                //{
                //    Uri = "https://jobmeapi.azurewebsites.net/uploads/90_acads.mp4",
                //    // Uri = "https://jobmeapi.azurewebsites.net/uploads/hugo_acads.mp4",
                //};

                string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + u.UserID.ToString() + "_acads.mp4";

                if (CheckLink(url))
                {
                    //await Navigation.PushAsync(new MiWebView(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video", });
                    await Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Video académico" : "Academics Video" });
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("JobMe", "No se encontro el video solicitado", "Ok");
                //throw;
            }
        }

        //Video Jobs
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                // var main = (popupLayout as SfPopupLayout).Content.FindByName<SwipeCardView>("SwipeCardView");
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + u.UserID.ToString() + "_jobs.mp4";

                if (CheckLink(url))
                {
                    await Navigation.PushAsync(new VideoJobs(url) { Title = "Jobs Video" });
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("JobMe", "No se encontro el video solicitado", "Ok");
                //throw;
            }
        }

        //Video Others
        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            try
            {
                //  var main = (popupLayout as SfPopupLayout).Content.FindByName<SwipeCardView>("SwipeCardView");
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + u.UserID.ToString() + "_others.mp4";

                if (CheckLink(url))
                {
                    await Navigation.PushAsync(new VideoOthers(url) { Title = "Others Video" });
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("JobMe", "No se encontro el video solicitado", "Ok");
                //throw;
            }
        }

        //CV PDF

        private bool _isLocked;

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (_isLocked) return;
            _isLocked = true;

            try
            {
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                if (u.UserID > 0)
                {
                    await Navigation.PushAsync(new CV(u.UserID) { Title = "CV" });
                }
                else
                {
                    await DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
                }
            }
            catch (Exception ex)
            {
                _isLocked = false;
                await DisplayAlert("JobMe", "Error al obtener el CV de este usuario", "Ok");
                //throw new Exception( ex.Message);
            }

            Task.Delay(600);

            _isLocked = false;
        }

        private async void btnPhone_Clicked(object sender, EventArgs e)
        {
            try
            {
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;
                PhoneDialer.Open(u.Phone);
            }
            catch (Exception)
            {
                await DisplayAlert("JobMe", "No se encontro el telefono del usuario", "Ok");
                //throw;
            }
        }

        private async void btnMail_Clicked(object sender, EventArgs e)
        {
            try
            {
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                List<string> mymail = new List<string>() { u.Mail };

                var message = new EmailMessage
                {
                    Subject = "JobMe",
                    Body = "Me interesa tu perfil",
                    To = mymail,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await DisplayAlert("JobMe", "No se encontro el correo del usuario", "Ok");
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }

        private async void btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");

                UserModel u = new UserModel();

                u = (UserModel)main.TopItem;

                string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + u.UserID.ToString() + "_acads.mp4";

                if (CheckLink(url))
                {
                    await Navigation.PushAsync(new PlayVideo(url) { Title = "Academics Video" });
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No video found", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("JobMe", "No se encontro el video solicitado", "Ok");
                //throw;
            }
        }

        //Foto en grande
        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var main = (stly as StackLayout).FindByName<SwipeCardView>("SwipeCardView");
            UserModel u = new UserModel();

            u = (UserModel)main.TopItem;

            var image = (FFImageLoading.Forms.CachedImage)sender;

            await Navigation.PushAsync(new LargePhoto(image) { Title = u.Name });
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
    }
}