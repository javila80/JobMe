using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using Acr.UserDialogs;
using JobMe.Models.Chat;
using JobMe.Services;
using JobMe.Views;
using Microsoft.AspNetCore.SignalR.Client;

using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.ListView.XForms;
using TheChat.Core.EventHandlers;
using TheChat.Core.Helpers;
using TheChat.Core.Services;
using TheChat.Messages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe.ViewModels.Chat
{
    /// <summary>
    /// ViewModel for chat message page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatMessageViewModel : BaseViewModel
    {
        #region Fields

        private IChatService ChatService;

        /// <summary>
        /// Stores the message text in an array.
        /// </summary>

        private string profileName;

        private string newMessage;

        private string profileImage;

        private ObservableCollection<Models.Chat.ChatMessage> chatMessageInfo = new ObservableCollection<Models.Chat.ChatMessage>();

        public static ChatDetail ChatDetail { get; set; }

        #endregion Fields

        public INavigation Navigation { get; set; }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageViewModel" /> class.
        /// </summary>
        ///
        //private bool _IsVisible;

        //public bool IsVisible
        //{
        //    get { return _IsVisible; }
        //    set { _IsVisible = value; OnPropertyChanged(); }
        //}
        //private ChatDetail myVar;

        //public ChatDetail selecteditem
        //{
        //    get { return myVar; }
        //    set { myVar = value; OnPropertyChanged(); }
        //}

        #region Templates Commands and methods

        public Command ImageTappedCommand { get; set; }
        public Command OutgoingImageTappedCommand { get; set; }
        public Command OutgoingVideoTappedCommand { get; set; }
        public Command IncomingVideoTappedCommand { get; set; }
        public Command FileTappedCommand { get; set; }

        private async void OutgoingImageClicked(object obj)
        {
            try
            {
                string url = ((JobMe.Models.Chat.ChatMessage)obj).ImageUrl;

                await Navigation.PushAsync(new LargePhoto(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("alert", ex.Message, "ok");
                //throw;
            };
        }

        private async void IncomingImageClicked(object obj)
        {
            try
            {
                string url = ((JobMe.Models.Chat.ChatMessage)obj).ImageUrl;
                string name = ((JobMe.Models.Chat.ChatMessage)obj).Sender;

                await Navigation.PushAsync(new LargePhoto(url) { Title = name });
            }
            catch (System.Exception ex)
            {
                throw;
            };
        }

        private async void OutgoingVideoClicked(object obj)
        {
            try
            {
                string url = ((JobMe.Models.Chat.ChatMessage)obj).VideoUrl;

                // await App.Navigation.PushAsync(new MiWebView(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });

                await Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });
            }
            catch (System.Exception)
            {
                //throw;
            };
        }

        private async void IncomingVideoClicked(object obj)
        {
            try
            {
                string url = string.IsNullOrEmpty(((JobMe.Models.Chat.ChatMessage)obj).ImagePath)?((JobMe.Models.Chat.ChatMessage)obj).VideoUrl: ((JobMe.Models.Chat.ChatMessage)obj).ImagePath;
                string name = ((JobMe.Models.Chat.ChatMessage)obj).Sender;

                //await App.Navigation.PushAsync(new MiWebView(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });
                await Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });
            }
            catch (System.Exception)
            {
                //throw;
            };
        }

        private async void FileClicked(object obj)
        {
            try
            {
                string url = EndPoint.BLOB_ENDPOINT + ((JobMe.Models.Chat.ChatMessage)obj).Message;
                await Launcher.OpenAsync(new Uri(url));
            }
            catch (System.Exception)
            {
                //throw;
            };
        }

        #endregion Templates Commands and methods

        public ChatMessageViewModel(ChatDetail selecteditem)
        {
            IsVisible = true;

            //App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;

            if (!App.ChatService1.IsConnected)
            {
                App.ChatService1 = new TheChat.Core.Services.ChatService();

                if (Preferences.Get("UserID", 0) > 0)
                {
                    //await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                    App.ChatService1.OnReceivedMessage -= ChatService_OnReceivedMessage;
                    App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;
                }
            }
            else
            {
                App.ChatService1.OnReceivedMessage -= ChatService_OnReceivedMessage;
                App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;
            }

            this.MakeVoiceCall = new Command(this.VoiceCallClicked);
            this.MakeVideoCall = new Command(this.VideoCallClicked);
            this.MenuCommand = new Command(this.MenuClicked);
            this.ShowCamera = new Command(this.CameraClicked);
            this.SendAttachment = new Command(this.AttachmentClicked);
            this.SendCommand = new Command(this.SendClicked);
            this.BackCommand = new Command(this.BackButtonClicked);
            this.ProfileCommand = new Command(this.ProfileClicked);
            this.DeleteChatCommand = new Command(this.DeleteChat);
            this.SendFile = new Command(this.SendFileClicked);
            this.ShowVideo = new Command(this.VideoClicked);

            this.GenerateMessageInfo(selecteditem);

            this.ImageTappedCommand = new Command(IncomingImageClicked);
            this.OutgoingImageTappedCommand = new Command(OutgoingImageClicked);

            this.OutgoingVideoTappedCommand = new Command(OutgoingVideoClicked);
            this.IncomingVideoTappedCommand = new Command(IncomingVideoClicked);

            this.FileTappedCommand = new Command(FileClicked);

            ProfileName = selecteditem.SenderName;
            profileImage = selecteditem.ImagePath;
            Logo = selecteditem.Logo;
            ChatDetail = selecteditem;

            if (Preferences.Get("UserType", 0) == 1) //Employee
            {
                IsLogoVisible = true;
                IsImageVisible = false;
            }
            else
            {
                IsLogoVisible = false;
                IsImageVisible = true;
            }

            //App.hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    ChatMessageInfo.Add(new ChatMessage
            //    {
            //        Message = message,
            //        Time = DateTime.Now,
            //         IsReceived = true
            //    });

            //});
        }

        public void ChatService_OnReceivedMessage(object sender, TheChat.Core.EventHandlers.MessageEventArgs e)
        {
            string nombre;

            if (Preferences.Get("UserType", 0) == 1) //Employee
            {
                nombre = Preferences.Get("Name", string.Empty);
            }
            else
            {
                nombre = Preferences.Get("Company", string.Empty);
            }
            JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage();

            Device.BeginInvokeOnMainThread(() =>
            {
                //si el mensaje es para mi
                if (nombre == e.Message.Sender)
                {
                    //Hay actualizar la lista de contactos

                    if (e.Message.TypeInfo.Name == nameof(SimpleTextMessage)) // Memsaje de textpo
                    {
                        var z = (SimpleTextMessage)e.Message;
                        msg = new JobMe.Models.Chat.ChatMessage()
                        {
                            Message = z.Text,
                            Time = z.Timestamp,
                            IsReceived = true,
                        };

                        ChatMessageInfo.Add(msg);
                    }
                    else if (e.Message.TypeInfo.Name == nameof(PhotoMessage)) //Mensaje de imagen
                    {
                        var z = (PhotoMessage)e.Message;
                        msg = new JobMe.Models.Chat.ChatMessage()
                        {
                            Base64Photo = z.Base64Photo,
                            Time = z.Timestamp,
                            //ContactID = ChatDetail.ContactID,
                            //UserID = ChatDetail.UserID,
                            //IDPosition = ChatDetail.IDPosition,
                            IsReceived = true,
                        };

                        ChatMessageInfo.Add(msg);
                    }
                    else if (e.Message.TypeInfo.Name == nameof(PhotoUrlMessage)) //Mensaje de imagen
                    {
                        var y = (PhotoUrlMessage)e.Message;

                        msg = new JobMe.Models.Chat.ChatMessage()
                        {
                            Time = y.Timestamp,
                            ImageUrl = y.Url,
                            IsReceived = true,
                            IsFile = y.IsFile,
                            Message = y.IsFile ? HttpUtility.UrlDecode(Path.GetFileName(y.Url)) : y.Url,
                        };

                        // var result = Path.GetFileName(y.Url);

                        ChatMessageInfo.Add(msg);
                    }
                    else if (e.Message.TypeInfo.Name == nameof(VideoMessage)) //Mensaje de video
                    {
                        var y = (VideoMessage)e.Message;

                        msg = new JobMe.Models.Chat.ChatMessage()
                        {
                            Time = y.Timestamp,
                            ImageUrl = y.VideoImage,
                            IsReceived = true,
                            IsVideo = true,
                            ImagePath = y.VideoUrl,
                            Base64Photo = y.Base64Photo

                            // Message = y.IsFile ? HttpUtility.UrlDecode(Path.GetFileName(y.Url)) : y.Url,
                        };

                        // var result = Path.GetFileName(y.Url);

                        ChatMessageInfo.Add(msg);
                    }
                }
            });
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string ProfileName
        {
            get
            {
                return this.profileName;
            }

            set
            {
                this.profileName = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        ///
        private bool _IsLogoVisible;

        public bool IsLogoVisible
        {
            get { return _IsLogoVisible; }
            set { _IsLogoVisible = value; OnPropertyChanged(); }
        }

        private bool _IsImageVisible;

        public bool IsImageVisible
        {
            get { return _IsImageVisible; }
            set { _IsImageVisible = value; OnPropertyChanged(); }
        }

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

        private byte[] _logo;

        public byte[] Logo
        {
            get { return this._logo; }
            set
            {
                this._logo = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a collection of chat messages.
        /// </summary>
        public ObservableCollection<Models.Chat.ChatMessage> ChatMessageInfo
        {
            get
            {
                return this.chatMessageInfo;
            }

            set
            {
                this.chatMessageInfo = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a new message.
        /// </summary>
        public string NewMessage
        {
            get
            {
                return this.newMessage;
            }

            set
            {
                this.newMessage = value;

                if (string.IsNullOrEmpty(newMessage))
                {
                    IsVisible = true;
                }
                else
                {
                    IsVisible = false;
                }

                this.OnPropertyChanged();
            }
        }

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the profile name is clicked.
        /// </summary>
        /// ClickCommand
        public Command ClickCommand { get; set; }

        public Command ProfileCommand { get; set; }

        public Command SendFile { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCall { get; set; }

        public Command DeleteChatCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCall { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the camera button is clicked.
        /// </summary>
        public Command ShowCamera { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the attachment button is clicked.
        /// </summary>
        public Command SendAttachment { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the send button is clicked.
        /// </summary>
        public Command SendCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the back button is clicked.
        /// </summary>
        public Command BackCommand { get; set; }

        public Command ShowVideo { get; set; }

        #endregion Commands

        #region Methods

        public SfListView listView { get; set; }

        //SfListView listView;
        /// <summary>
        /// Initializes a collection and add it to the message items.
        /// </summary>
        private async void GenerateMessageInfo(ChatDetail chat)
        {
            IsVisible = false;

            if (Preferences.Get("UserType", 0) == 1)
            {
                chat.TipoMensaje = 1;
            }
            else
            {
                chat.TipoMensaje = 2;
            }

            this.ChatMessageInfo = await Services.Chat.ChatService.GetMessagesNewAsync(chat);

            foreach (var item in ChatMessageInfo)
                item.Sender = ProfileName;

            Count = this.ChatMessageInfo.Count;

            ((LinearLayout)this.listView.LayoutManager).ScrollToRowIndex(
                   Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End, true);

            IsVisible = true;
        }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Invoked when the voice call button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void VoiceCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the video call button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void VideoCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        private async void VideoClicked(object obj)
        {
            try
            {
                if (!await JobMePermissions.CameraPermission())
                {
                    return;
                }

                await CrossMedia.Current.Initialize();

                //var photo = await CrossMedia.Current.PickVideoAsync();
                var photo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                {
                    SaveToAlbum = false,
                    Quality = Device.RuntimePlatform == Device.Android?VideoQuality.High:VideoQuality.Medium,
                    CompressionQuality = 90,
                    DefaultCamera = CameraDevice.Front,
                    Directory = "Media",
                    Name = "video.mp4",
                });
                // var photo = await CrossMedia.Current.TakeVideoAsync(mediaOptions);
                string fname = string.Empty;
                string myfilename = string.Empty;

                if (photo != null)
                {
                    //var stream = photo.GetStream();
                    FileInfo fi;
                    UserDialogs.Instance.ShowLoading("Uploading video");

                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                            fi = new FileInfo(photo.Path);
                            string extn = fi.Extension;
                            var newname = photo.Path.Replace(extn, ".mp4");

                            fname = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
                                    DateTime.Now.Year.ToString() +
                                    DateTime.Now.Millisecond.ToString() + "video.mp4";

                            await UserService.UploadVideo(photo, Preferences.Get("UserID", 0).ToString() + "_" + fname);
                            //fname = Path.GetFileName(photo.Path);
                            myfilename = Preferences.Get("UserID", 0).ToString() + "_" + fname.Split('.').First();
                            break;

                        case Device.Android:

                        //Stream stream = null;
                        fname = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
                               DateTime.Now.Year.ToString() +
                               DateTime.Now.Millisecond.ToString() + "video.mp4";

                        try
                        {
                            UserDialogs.Instance.ShowLoading("Compressing video");

                            string compressedfile = await DependencyService.Get<IVideoCompress>().CompressVideo(photo.Path);                                                                       
                                                      

                            Stream stream = File.Open(compressedfile, FileMode.Open, System.IO.FileAccess.ReadWrite);

                            await UserService.UploadVideo(stream, Preferences.Get("UserID", 0).ToString() + "_" + fname);

                        }
                        catch (Exception)
                        {

                            await UserService.UploadVideo(photo, Preferences.Get("UserID", 0).ToString() + "_" + fname);
                            //throw;
                        }
                          

                            //fname = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
                            //        DateTime.Now.Year.ToString() +
                            //        DateTime.Now.Millisecond.ToString() + "video.mp4";

                            //Stream stream = File.Open(compressedfile, FileMode.Open, System.IO.FileAccess.ReadWrite);

                            //await UserService.UploadVideo(stream, Preferences.Get("UserID", 0).ToString() + "_" + fname);
                            //fname = Path.GetFileName(photo.AlbumPath);

                            break;

                        default:
                            break;
                    }

                    myfilename = Preferences.Get("UserID", 0).ToString() + "_" + fname.Split('.').First();

                    MemoryStream imagen = DependencyService.Get<IVideoBitMap>().GenerateThumbImage(photo.Path, 2);

                    //var bytes = ImageHelper.ReadFully(imagen);

                    var base64Photo = Convert.ToBase64String(imagen.ToArray());

                    string To = string.Empty;
                    //mensaje para enviar
                    var message = new VideoMessage(ProfileName)
                    {
                        Base64Photo = base64Photo,
                        FileEnding = myfilename + ".jpg",
                        Recipient = ChatDetail.ContactID.ToString(),
                        //VideoUrl = EndPoint.BACKEND_ENDPOINT + "/uploads/" +fname,
                        VideoUrl = EndPoint.BACKEND_ENDPOINT + "/uploads/" + myfilename + ".mp4",
                        VideoImage = EndPoint.BLOB_ENDPOINT + myfilename + ".jpg",
                        IsVideo = true,
                    };
                    UserDialogs.Instance.HideLoading();
                    //mensaje para mostrar
                    JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage()
                    {
                        Time = DateTime.Now,
                        ContactID = ChatDetail.ContactID,
                        UserID = ChatDetail.UserID,
                        IDPosition = ChatDetail.IDPosition,
                        IsReceived = false,
                        Base64Photo = base64Photo,
                        ImageUrl = EndPoint.BLOB_ENDPOINT + myfilename + ".jpg",
                        VideoUrl = EndPoint.BACKEND_ENDPOINT + "/uploads/" + myfilename + ".mp4",
                        IsVideo = true
                    };

                    //Verificar que esta conectado al HUb

                    if (!App.ChatService1.IsConnected)
                    {
                        App.ChatService1 = new TheChat.Core.Services.ChatService();

                        if (Preferences.Get("UserID", 0) > 0)
                        {
                            await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                        }
                    }

                    //Este mensaje es el que se agrega a la lista
                    ChatMessageInfo.Add(msg);

                    //Este es el mensaje que se envia al hub
                    await App.ChatService1.SendMessageAsync(message);

                    if (Preferences.Get("UserType", 0) == 1) //Employee
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Name", string.Empty), "📹 Video"));
                    }
                    else
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Company", string.Empty), "📹 Video"));
                    }

                    //Esto es para agregarlo a la base de datos
                    await Services.Chat.ChatService.AddMessageAsync(msg);

                    //Ocultar el teclado en ios
                    //MessagingCenter.Send<ChatMessageViewModel, string>(this, "FocusKeyboardStatus", "nada");
                }

                // UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                string errmsg;

                if (ex.HResult == -2146233029)
                {
                    errmsg = "La operación tardo demasiado, verifica tu conexión a internet";
                }
                else
                {
                    errmsg = "No se pudo enviar el video, intenta nuevamente";
                }

                await App.Current.MainPage.DisplayAlert("JobMe", errmsg, "ok");
                UserDialogs.Instance.HideLoading();
                //throw;
            }
        }

        /// <summary>
        /// Invoked when the camera icon is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void CameraClicked(object obj)
        {
            try
            {
                if (!await JobMePermissions.CameraPermission())
                {
                    return;
                }
                var mediaOptions = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = false,
                    Directory = "Sample",
                    PhotoSize = PhotoSize.Medium,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    RotateImage = false,
                    CompressionQuality = 80,
                    AllowCropping = true,
                    SaveMetaData = false,
                };
                //options.CompressionQuality = 50;

                var photo = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                if (photo != null)
                {
                    var ext = photo.Path.Split('.').Last();

                    var stream = photo.GetStreamWithImageRotatedForExternalStorage();

                    var bytes = ImageHelper.ReadFully(stream);

                    var base64Photo = Convert.ToBase64String(bytes);

                    string myfoto = base64Photo;

                    string fname = Path.GetFileName(photo.Path);

                    string To = string.Empty;
                    //mensaje para enviar
                    var message = new PhotoMessage(ProfileName)
                    {
                        Base64Photo = base64Photo,
                        FileEnding = fname,
                        Recipient = ChatDetail.ContactID.ToString(),
                    };
                    //mensaje para mostrar
                    JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage()
                    {
                        Time = DateTime.Now,
                        ContactID = ChatDetail.ContactID,
                        UserID = ChatDetail.UserID,
                        IDPosition = ChatDetail.IDPosition,
                        IsReceived = false,
                        Base64Photo = photo.Path,
                        ImageUrl = EndPoint.BLOB_ENDPOINT + fname,
                        IsImage = true
                    };

                    //Este mensaje es el que se agrega a la lista
                    ChatMessageInfo.Add(msg);

                    //Verifica que este conectado al hub
                    if (!App.ChatService1.IsConnected)
                    {
                        App.ChatService1 = new TheChat.Core.Services.ChatService();

                        if (Preferences.Get("UserID", 0) > 0)
                        {
                            await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                        }
                    }

                    //Este es el mensaje que se envia al hub
                    await App.ChatService1.SendMessageAsync(message);

                   

                    if (Preferences.Get("UserType", 0) == 1) //Employee
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Name", string.Empty), "📷 Imagen"));
                    }
                    else
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Company", string.Empty), "📷 Imagen"));
                    }

                    //Esto es para agregarlo a la base de datos
                    await Services.Chat.ChatService.AddMessageAsync(msg);

                    //Ocultar el teclado en ios
                    MessagingCenter.Send<ChatMessageViewModel, string>(this, "FocusKeyboardStatus", "nada");
                }

                // UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
               
                
                
                await App.Current.MainPage.DisplayAlert("JobMe", ex.Message, "ok");
                //throw;
            }
        }

        /// <summary>
        /// Invoked when the attachment icon is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void AttachmentClicked(object obj)
        {
            if (!await JobMePermissions.GalleryPermission())
            {
                return;
            }
            var options = new PickMediaOptions();
            options.CompressionQuality = 50;

            var photo = await CrossMedia.Current.PickPhotoAsync(options);

            if (photo != null)
            {
                var ext = photo.Path.Split('.').Last();

                var stream = photo.GetStreamWithImageRotatedForExternalStorage();

                var bytes = ImageHelper.ReadFully(stream);

                var base64Photo = Convert.ToBase64String(bytes);

                string myfoto = base64Photo;

                string fname = Path.GetFileName(photo.Path);

                string To = string.Empty;
                //mensaje para enviar
                var message = new PhotoMessage(ProfileName)
                {
                    Base64Photo = base64Photo,
                    FileEnding = fname,
                    Recipient = ChatDetail.ContactID.ToString(),
                };
                //mensaje para mostrar
                JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage()
                {
                    Time = DateTime.Now,
                    ContactID = ChatDetail.ContactID,
                    UserID = ChatDetail.UserID,
                    IDPosition = ChatDetail.IDPosition,
                    IsReceived = false,
                    Base64Photo = photo.Path,
                    ImageUrl = EndPoint.BLOB_ENDPOINT + fname,
                    IsImage = true
                };

                //Verifica que este conectado al hub
                if (!App.ChatService1.IsConnected)
                {
                    App.ChatService1 = new TheChat.Core.Services.ChatService();

                    if (Preferences.Get("UserID", 0) > 0)
                    {
                        await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                    }
                }

                //Este es el mensaje que se envia al hub
                await App.ChatService1.SendMessageAsync(message);

                //Este mensaje es el que se agrega a la lista
                ChatMessageInfo.Add(msg);

                if (Preferences.Get("UserType", 0) == 1) //Employee
                {
                    Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Name", string.Empty), "📷 Imagen"));
                }
                else
                {
                    Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Company", string.Empty), "📷 Imagen"));
                }

                //Ocultar el teclado en ios
                MessagingCenter.Send<ChatMessageViewModel, string>(this, "FocusKeyboardStatus", "nada");

                //Esto es para agregarlo a la base de datos
                await Services.Chat.ChatService.AddMessageAsync(msg);
            }
        }

        /// <summary>
        /// Invoked when the send button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void SendClicked(object obj)
        {
           
            try
            {
                if (!string.IsNullOrWhiteSpace(this.NewMessage))
                {
                    int userid = Preferences.Get("UserID", 0);

                    JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage()
                    {
                        Message = this.NewMessage,
                        Time = DateTime.Now,
                        ContactID = ChatDetail.ContactID,
                        UserID = ChatDetail.UserID,
                        IDPosition = ChatDetail.IDPosition,
                        IsReceived = false,
                    };

                    var message = new SimpleTextMessage(ProfileName)
                    {
                        Text = this.NewMessage,
                        Recipient = ChatDetail.ContactID.ToString(),
                       Avatar = userid.ToString(),
                        Color = ChatDetail.IDPosition.ToString(),
                        //GroupName = ChatDetail.IDPosition.ToString(),

                    };

                    //Este mensaje es el que se agrega a la lista
                    ChatMessageInfo.Add(msg);

                    //borra el mensaje para que actualice el chat
                    this.NewMessage = null;

                    //Verifica que este conectado al hub
                    if (!App.ChatService1.IsConnected)
                    {
                        App.ChatService1 = new TheChat.Core.Services.ChatService();

                        if (Preferences.Get("UserID", 0) > 0)
                        {
                            await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                        }
                    }

                    //Este es el mensaje que se envia al hub
                    await App.ChatService1.SendMessageAsync(message);

                    if (Preferences.Get("UserType", 0) == 1) //Employee
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Name", string.Empty), msg.Message));
                    }
                    else
                    {
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Company", string.Empty), msg.Message));
                    }

                    //Esto es para agregarlo a la base de datos
                    await Services.Chat.ChatService.AddMessageAsync(msg);
                }
            }
            catch (Exception ex)
            {
                // throw;
            }
        }

        //private HubConnection hubConnection;
        /// <summary>
        /// Invoked when the back button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void BackButtonClicked(object obj)
        {
            await Navigation.PopModalAsync();
        }

        private async void DeleteChat(object obj)
        {
            if (await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                CancelText = "Cancel",
                OkText = "Ok",
                Message = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro de borrar la conversación?" : "Are you sure you want to delete the conversation ?",
            }))
            {
                if (Preferences.Get("UserType", 0) == 1)
                {
                    ChatDetail.TipoMensaje = 1;
                }
                else
                {
                    ChatDetail.TipoMensaje = 2;
                }

                if (await Services.Chat.ChatService.DeleteChatAsync(ChatDetail))
                {
                    ChatMessageInfo.Clear();
                    // await Navigation.PopModalAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("JobMe", "Cant delete chat", "Ok");
                }
            }
        }

        /// <summary>
        /// Invoked when the Profile name is clicked.
        /// </summary>
        private void ProfileClicked(object obj)
        {
            // Do something
        }

        private async void SendFileClicked(object obj)
        {
            string[] fileTypes;

            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var pickedFile = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();

                    if (pickedFile != null)
                    {
                        var stream = pickedFile.GetStream();

                        var bytes = ImageHelper.ReadFully(stream);

                        var base64Photo = Convert.ToBase64String(bytes);

                        string myfoto = base64Photo;

                        string fname = pickedFile.FileName;

                        //mensaje para enviar
                        var message = new PhotoMessage(ProfileName)
                        {
                            Base64Photo = base64Photo,
                            FileEnding = fname,
                            Recipient = ChatDetail.ContactID.ToString(),
                            IsFile = true,
                            Avatar = ChatDetail.UserID.ToString(),
                            Color = ChatDetail.IDPosition.ToString(),
                        };
                        //mensaje para mostrar
                        JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage()
                        {
                            Time = DateTime.Now,
                            ContactID = ChatDetail.ContactID,
                            UserID = ChatDetail.UserID,
                            IDPosition = ChatDetail.IDPosition,
                            IsReceived = false,
                            IsFile = true,
                            Message = fname,
                        };

                        //Verifica que este conectado al hub
                        if (!App.ChatService1.IsConnected)
                        {
                            App.ChatService1 = new TheChat.Core.Services.ChatService();

                            if (Preferences.Get("UserID", 0) > 0)
                            {
                                await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                            }
                        }

                        //Este mensaje es el que se agrega a la lista
                        ChatMessageInfo.Add(msg);

                        //Este es el mensaje que se envia al hub
                        await App.ChatService1.SendMessageAsync(message);

                     

                        if (Preferences.Get("UserType", 0) == 1) //Employee
                        {
                            Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Name", string.Empty), "📄 Archivo"));
                        }
                        else
                        {
                            Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ChatDetail.ContactID, Preferences.Get("Company", string.Empty), "📄 Archivo"));
                        }

                        //Ocultar el teclado en ios
                        MessagingCenter.Send<ChatMessageViewModel, string>(this, "FocusKeyboardStatus", "nada");

                        //Esto es para agregarlo a la base de datos
                        await Services.Chat.ChatService.AddMessageAsync(msg);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            // FileData fileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile(allowedDocumentTypes);//

            // App.Current.MainPage.DisplayAlert("JobMe", "Solo disponible para Premium", "OK");
        }

        //public SfListView ListView;
        //private async void OnLoadingAsync(object obj)
        //{
        //    IsBusy = true;

        //    ListView = obj as SfListView;
        //    var firstItem = ListView.DataSource.DisplayItems[0];
        //    this.GridIsVisible = false;
        //    this.IndicatorIsVisible = true;
        //    await Task.Delay(500);
        //    var r = new Random();
        //    ListView.DataSource.BeginInit();
        //    for (int i = 0; i < 5; i++)
        //    {
        //    }
        //    ListView.DataSource.EndInit();
        //    var firstItemIndex = ListView.DataSource.DisplayItems.IndexOf(firstItem);
        //    var header = (ListView.HeaderTemplate != null && !ListView.IsStickyHeader) ? 1 : 0;
        //    var totalItems = firstItemIndex + header;
        //    //ListView.LayoutManager.ScrollToRowIndex(totalItems, true);
        //    this.GridIsVisible = true;
        //    this.IndicatorIsVisible = false;

        //    IsBusy = false;
        //}

        //public bool indicatorIsVisible;
        //public bool gridIsVisible;
        //public bool IndicatorIsVisible
        //{
        //    get { return indicatorIsVisible; }
        //    set
        //    {
        //        indicatorIsVisible = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public bool GridIsVisible
        //{
        //    get { return gridIsVisible; }
        //    set
        //    {
        //        gridIsVisible = value;
        //        OnPropertyChanged();
        //    }
        //}

        #endregion Methods
    }
}