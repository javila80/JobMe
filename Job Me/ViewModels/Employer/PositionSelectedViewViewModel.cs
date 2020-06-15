using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using JobMe.Models;
using FormsVideoLibrary;
using Xamarin.Essentials;
using System.Threading.Tasks;
using JobMe.Views;
using System.Linq;
using JobMe.Services.Chat;
using JobMe.Models.Chat;
using JobMe.Views.Chat;

namespace JobMe.ViewModels.Employer
{
    internal class PositionSelectedViewViewModel : BaseViewModel
    {
        private int idPosition;

        public int IDPosition
        {
            get { return idPosition; }
            set
            {
                idPosition = value;
                OnPropertyChanged();
            }
        }

        public int Contador { get; set; }
        public ICommand CardTappedCommand { get; set; }

        public ObservableCollection<CardDataModel> Data { get; set; }

        private uint _threshold;

        public uint Threshold
        {
            get => _threshold;
            set
            {
                _threshold = value;
                OnPropertyChanged();
            }
        }

        //private int _IdPosition;

        //public int IdPosition
        //{
        //    get { return _IdPosition; }
        //    set { _IdPosition = value; OnPropertyChanged(); }
        //}

        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }

        public ICommand TapCommand { get; set; }

        private ObservableCollection<UserModel> candidatesList;

        public ObservableCollection<UserModel> ListCandidates
        {
            get { return candidatesList; }
            set { candidatesList = value; OnPropertyChanged(); }
        }

        private bool _IsOpen;

        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; OnPropertyChanged(); }
        }

        private string _MiNombre;

        public string MiNombre
        {
            get { return _MiNombre; }
            set { _MiNombre = value; OnPropertyChanged(); }
        }

        private string _textoboton;

        public string textoboton
        {
            get { return _textoboton; }
            set { _textoboton = value; OnPropertyChanged(); }
        }

        private UriVideoSource _MiVideo;

        public UriVideoSource MiVideo
        {
            get { return _MiVideo; }
            set { _MiVideo = value; OnPropertyChanged(); }
        }

        public Command LikeCommand { get; set; }

        public Command DislikeCommand { get; set; }

        private bool _DisplayPopup;

        public bool DisplayPopup
        {
            get { return _DisplayPopup; }
            set { _DisplayPopup = value; OnPropertyChanged(); }
        }

        public Command BtnChatCommand { get; set; }

        public string PositionName { get; set; }

        private string _Academicslbl;

        public string Academicslbl
        {
            get { return _Academicslbl; }
            set { _Academicslbl = value; OnPropertyChanged(); }
        }

        private string _Otherslbl;

        public string Otherslbl
        {
            get { return _Otherslbl; }
            set { _Otherslbl = value; OnPropertyChanged(); }
        }

        private string _Jobslbl;

        public string Jobslbl
        {
            get { return _Jobslbl; }
            set { _Jobslbl = value; OnPropertyChanged(); }
        }

        private string _LastItemText;

        public string LastItemText
        {
            get { return _LastItemText; }
            set { _LastItemText = value; OnPropertyChanged(); }
        }

        public PositionSelectedViewViewModel(ListaPositions p)
        {
            LastItemText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No hay más candidatos por el momento" : "No more candidates available right now";
            Academicslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Académico" : "Academics";
            Jobslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empleos" : "Jobs";
            Otherslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Otros" : "Others";
            DisplayPopup = false;
            Threshold = (uint)(App.ScreenWidth / 3);
            //IdPosition = idPosition;
            IsLastItem = false;
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Command<DraggingCardEventArgs>(OnDraggingCommand);
            // TapCommand = new Command(OnTapped);
            BtnChatCommand = new Command(GoChatMe);
            IDPosition = p.IDPosition;
            PositionName = p.Name;
            //GetPositionsLiked(p.IDPosition);
            GetCandidatesByPosition(p.IDPosition);
        }

        public ChatDetail MyChat { get; set; }

        private async void GoChatMe()
        {
            try
            {
                DisplayPopup = false;
                //  await Navigation.PopAsync();
                //MessagingCenter.Send<PositionSelectedViewViewModel>(this, "Hi");

                //await Navigation.PopAsync();
                await Navigation.PushAsync(new ChatMessagePage(MyChat) { Title = MyChat.SenderName });
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        //private void OnLikeCommand()
        //{
        //}

        //private void OnDislikeCommand()
        //{
        //}

        //private void OnTapped()
        //{
        //    IsOpen = true;

        //    MiVideo = new UriVideoSource
        //    {
        //        Uri = "https://jobmeapi.azurewebsites.net/uploads/Jjj_others.mp4",
        //    };

        //    //MiVideo = new FileVideoSource
        //    //{
        //    //    File = "Jobme1.mp4",
        //    //};

        //    var z = MiNombre;

        //}

        public ObservableCollection<PositionsLiked> Positionliked { get; set; }

        private async void GetPositionsLiked(int idPosition)
        {
            Positionliked = await Services.PositionService.GetPositionsLiked(idPosition);
        }

        private async void GetCandidatesByPosition(int idPosition)
        {
            IsBusy = true;

            ListCandidates = await Services.PositionService.GetCandidatesByPositionAsync(idPosition);

            if (ListCandidates.Count <= 0)
            {
                IsLastItem = true;
            }

            IsBusy = false;
        }

        private bool _IsLastItem;

        public bool IsLastItem
        {
            get { return _IsLastItem; }
            set { _IsLastItem = value; OnPropertyChanged(); }
        }

        public INavigation Navigation { get; set; }

        private async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            Contador += 1;

            if (Contador == ListCandidates.Count)
            {
                IsLastItem = true;
            }
            //Like
            if (eventArgs.Direction == SwipeCardDirection.Right)
            {
                UserModel item = (UserModel)eventArgs.Item;

                var x = item.UserID;
                var z = item.UserName;

                MiNombre = z;

                //Agregar a la tabla de positions liked
                //AddPositionLiked(int idPosition, userID);
                try
                {
                    if (IDPosition > 0)
                    {
                        Services.EmployerService.AddCandidateLikedAsync(IDPosition, x);

                        int liked = await Services.PositionService.GetPositionLiked(IDPosition, x);
                        //var coindice = Positionliked.Where(obj => obj.UserID == item.UserID).FirstOrDefault();

                        if (liked > 0)
                        {
                            int userid = Preferences.Get("UserID", 0);
                            ChatContact ch = new ChatContact()
                            {
                                UserID = userid,
                                ContactUserID = item.UserID,
                                IDPosition = IDPosition
                            };

                            MyChat = new ChatDetail()
                            {
                                IDPosition = this.IDPosition,
                                PositionName = PositionName,
                                ContactID = item.UserID,
                                UserID = userid,
                                ImagePath = EndPoint.BACKEND_ENDPOINT + "uploads/" + item.UserID.ToString() + ".jpg",
                                SenderName = item.Name,
                                TipoMensaje = 2,  //eMPLOYEr
                            };

                            JobMatchName = item.Name;
                            JobMatchPosition = PositionName;

                            var jm = new JobMatch()
                            {
                                IDPosition = this.IDPosition,
                                UserId = item.UserID
                            };

                            //Argega un usuario a la lista de chats
                            await ChatService.AddContactAsync(ch);

                            //Actualizar la lista de contactos
                            //MessagingCenter.Send(this, "Hi");

                            try
                            {
                                // Use default vibration length
                                Vibration.Vibrate();
                            }
                            catch (FeatureNotSupportedException ex)
                            {
                                // Feature not supported on device
                            }
                            catch (Exception ex)
                            {
                                // Other error has occurred.
                            }

                            //Agregar a la tabla de JobMatch
                            Task.Run(() => Services.Chat.ChatService.AddJobMatchAsync(jm));

                            //enviar la notificaciom
                            Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ch.ContactUserID, "👍 JobMatch", "Go to Chat Me"));

                            DisplayPopup = true;
                        }
                        else
                        {
                            if (Contador % 3 == 0)
                            {
                                await Navigation.PushModalAsync(new VideoPublicidad());
                            }
                        }
                    }

                    Preferences.Set("IDPositionSelected", null);
                }
                catch (Exception)
                {
                    // throw;
                }
            }
            else
            {
                if (Contador % 3 == 0)
                {
                    await Navigation.PushModalAsync(new VideoPublicidad());
                }
            }

            ////var x = $"{item} swiped {eventArgs.Direction}";
        }

        private string _JobMatchName;

        public string JobMatchName
        {
            get { return _JobMatchName; }
            set { _JobMatchName = value; OnPropertyChanged(); }
        }

        private string _JobMatchPosition;

        public string JobMatchPosition
        {
            get { return _JobMatchPosition; }
            set { _JobMatchPosition = value; OnPropertyChanged(); }
        }

        private void OnDraggingCommand(DraggingCardEventArgs eventArgs)
        {
            switch (eventArgs.Position)
            {
                case DraggingCardPosition.Start:
                    return;

                case DraggingCardPosition.UnderThreshold:
                    break;

                case DraggingCardPosition.OverThreshold:
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    return;

                case DraggingCardPosition.FinishedOverThreshold:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}