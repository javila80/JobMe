using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Acr.UserDialogs;
using JobMe.Models.Chat;
using JobMe.Services.Chat;
using JobMe.ViewModels.Employer;
using JobMe.Views;
using JobMe.Views.Chat;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using TheChat.Core.EventHandlers;
using TheChat.Core.Helpers;
using TheChat.Core.Services;
using TheChat.Messages;

namespace JobMe.ViewModels.Chat
{
    /// <summary>
    /// View model for recent chat page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RecentChatViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<ChatDetail> chatItems;

        private string profileImage;

        private Command itemSelectedCommand;
        public ObservableCollection<ChatDetail> ChatContacts { get; }

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatViewModel" /> class.
        /// </summary>
        public RecentChatViewModel()
        {
            UpdateContacts();

            GetContacts();

            this.MakeVoiceCallCommand = new Command(this.VoiceCallClicked);
            this.MakeVideoCallCommand = new Command(this.VideoCallClicked);
            this.ShowSettingsCommand = new Command(this.SettingsClicked);
            this.MenuCommand = new Command(this.MenuClicked);
            this.ProfileImageCommand = new Command(this.ProfileImageClicked);
            this.DeleteCommand = new Command(this.DeleteMethod);
            this.RefreshCommand = new Command(this.RefreshMethod);
        }

        #endregion Constructor

        private void RefreshMethod(object obj)
        {
            IsRefreshing = true;
            int idemployee = (int)Preferences.Get("UserID", 0);

            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    GetContacts();

                    //GetCandidatesLiked(Preferences.Get("UserID", 0));
                });
            }

            IsRefreshing = false;
        }

        private bool _IsRefreshing;

        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set { _IsRefreshing = value; OnPropertyChanged(); }
        }

        private bool _IsImageVisible;

        public bool IsImageVisible
        {
            get { return _IsImageVisible; }
            set { _IsImageVisible = value; OnPropertyChanged(); }
        }

        private bool _IsLogoVisible;

        public bool IsLogoVisible
        {
            get { return _IsLogoVisible; }
            set { _IsLogoVisible = value; OnPropertyChanged(); }
        }

        private int _itemIndex = -1;

        public int ItemIndex
        {
            get { return _itemIndex; }
            set { _itemIndex = value; OnPropertyChanged(); }
        }

        private Syncfusion.ListView.XForms.SfListView _ListView;

        public Syncfusion.ListView.XForms.SfListView ListView
        {
            get { return _ListView; }
            set { _ListView = value; OnPropertyChanged(); }
        }

        private bool _IsRunning;

        public bool IsRunning
        {
            get { return _IsRunning; }
            set { _IsRunning = value; OnPropertyChanged(); }
        }

        private async void DeleteMethod(object obj)
        {
            try
            {
                if (await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    CancelText = "Cancel",
                    OkText = "Ok",
                    Message = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro de eliminar el chat?" : "Are you sure you want to delete the chat ?",
                }))
                {
                    var x = (ChatDetail)obj;

                    ChatContact ch = new ChatContact()
                    {
                        UserID = x.UserID,
                        ContactUserID = x.ContactID,
                        IDPosition = x.IDPosition
                    };

                    //Agregar el metodo de borrado de position
                    if (await Services.Chat.ChatService.DeleteContactAsync(ch))
                    {
                        if (ItemIndex >= 0)
                            ChatItems.RemoveAt(ItemIndex);
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se elimino correctamente el chat" : "Chat successfully deleted",
                            "OK");
                        //ListView.ResetSwipe();
                        //MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrío un error al eliminar el chat" : "Error deleting chat",
                            "OK");
                    }
                }

                ListView.ResetSwipe();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe",
                          App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrío un error al eliminar el chat" : "Error deleting chat",
                          "OK");
                //throw;
            }
        }

        private async void GetContacts()
        {
            IsRunning = true;

            //UserType
            int userid = Preferences.Get("UserID", 0);

            if (Preferences.Get("UserType", 0) == 1)
            {
                IsLogoVisible = true;
                IsImageVisible = false;
                ChatItems = await JobMe.Services.Chat.ChatService.GetContactsEmployeeAsync(userid);
            }
            else if (Preferences.Get("UserType", 0) == 2)
            {
                IsLogoVisible = false;
                IsImageVisible = true;
                ChatItems = await JobMe.Services.Chat.ChatService.GetContactsEmployerAsync(userid);
            }
            else if (Preferences.Get("UserType", 0) == 0)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", "Error cargando lista de contactos", "Ok");
            }
            IsRunning = false;
        }

        private void UpdateContacts()
        {
            //Recibe los mensajes cuando se agrega un contato del lado de usuario
            MessagingCenter.Subscribe<HomeViewModel>(this, "Hi", (sender) =>
           {
               //Device.BeginInvokeOnMainThread(async () =>
               //{
               //    int userid = Preferences.Get("UserID", 0);
               //    ChatItems = null;
               //    if (Preferences.Get("UserType", 0) == 1)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
               //    }
               //    else if (Preferences.Get("UserType", 0) == 2)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployerAsync(userid);
               //    }
               //});

               Device.BeginInvokeOnMainThread(() =>
               {
                   GetContacts();

                   //GetCandidatesLiked(Preferences.Get("UserID", 0));
               });
           });

            //Recibe los mensajes cuando se agrega un contato del lado de empresa
            MessagingCenter.Subscribe<PositionSelectedViewViewModel>(this, "Hi", (sender) =>
           {
               //Device.BeginInvokeOnMainThread(async () =>
               //{
               //    int userid = Preferences.Get("UserID", 0);
               //    ChatItems = null;
               //    if (Preferences.Get("UserType", 0) == 1)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
               //    }
               //    else if (Preferences.Get("UserType", 0) == 2)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployerAsync(userid);
               //    }
               //});
               Device.BeginInvokeOnMainThread(() =>
               {
                   GetContacts();

                   //GetCandidatesLiked(Preferences.Get("UserID", 0));
               });
           });

            //Actualiza la lista cuando cambia de pestaña
            MessagingCenter.Subscribe<MainEmployeeView>(this, "Hi", (sender) =>
           {
               //Device.BeginInvokeOnMainThread(async () =>
               //{
               //    int userid = Preferences.Get("UserID", 0);
               //    ChatItems = null;
               //    if (Preferences.Get("UserType", 0) == 1)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
               //    }
               //    else if (Preferences.Get("UserType", 0) == 2)
               //    {
               //        ChatItems = await ChatService.GetContactsEmployerAsync(userid);
               //    }
               //});

               Device.BeginInvokeOnMainThread(() =>
               {
                   object x = null;
                   RefreshMethod(x);

                   //GetCandidatesLiked(Preferences.Get("UserID", 0));
               });
           });
        }

        public INavigation Navigation { get; set; }

        #region Public Properties

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get
            {
                return this.profileImage;
            }

            set
            {
                this.profileImage = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the profile items.
        /// </summary>
        public ObservableCollection<ChatDetail> ChatItems
        {
            get
            {
                return this.chatItems;
            }

            set
            {
                if (this.chatItems == value)
                {
                    return;
                }

                this.chatItems = value;
                this.OnPropertyChanged();
            }
        }

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCallCommand { get; set; }

        public Command RefreshCommand { get; set; }
        public Command DeleteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCallCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the settings button is clicked.
        /// </summary>
        public Command ShowSettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets the command that is executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the profile image is clicked.
        /// </summary>
        public Command ProfileImageCommand { get; set; }

        #endregion Commands

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        ///
        private async void ItemSelected(object obj)
        {
            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            var z = (ChatDetail)x;

            if (Preferences.Get("UserType", 0) == 1)
            {
                z.TipoMensaje = 1;
            }
            else
            {
                z.TipoMensaje = 2;
            }

            try
            {
                await Navigation.PushAsync(new ChatMessagePage(z));
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Invoked when the Profile image is clicked.
        /// </summary>
        private void ProfileImageClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the voice call button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VoiceCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the video call button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VideoCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the settings button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SettingsClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        #endregion Methods
    }
}