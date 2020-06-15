using Acr.UserDialogs;
using JobMe.Behaviors;
using JobMe.Models;
using JobMe.Models.Chat;
using JobMe.Services;
using JobMe.Services.Chat;
using JobMe.Views;
using JobMe.Views.Chat;
using JobMe.Views.Employee;
using MediaManager.Forms;
using MLToolkit.Forms.SwipeCardView.Core;
using Newtonsoft.Json.Linq;
using Plugin.FilePicker;
using Plugin.Media;
using Plugin.Media.Abstractions;

//using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;
using Syncfusion.Pdf.Parsing;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.ComboBox;
using Syncfusion.XForms.PopupLayout;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;

using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        private string _SearchText;

        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                ChatItems = null;
                _SearchText = value;
                OnPropertyChanged();
            }
        }


        private string _LastItem;

        public string LastItemText
        {
            get { return _LastItem; }
            set { _LastItem = value; OnPropertyChanged(); }
        }

        // public INavigation Navigation { get; set; }

        private Stream m_pdfDocumentStream;

        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                OnPropertyChanged();
            }
        }

        private bool _IsVisible;

        public bool Visible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private byte[] _Photo;

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; OnPropertyChanged(); }
        }

        private byte[] _CV;

        public byte[] CV
        {
            get { return _CV; }
            set { _CV = value; OnPropertyChanged(); }
        }

        private ImageSource _PhotoSrc;

        public ImageSource PhotoSrc
        {
            get { return _PhotoSrc; }
            set { _PhotoSrc = value; OnPropertyChanged(); }
        }

        private bool _PdfVisible;

        public bool PdfVisible
        {
            get { return _PdfVisible; }
            set { _PdfVisible = value; OnPropertyChanged(); }
        }

        public ICommand MultiplyBy2Command { private set; get; }

        private ImageSource _PhotoURL;

        public ImageSource PhotoURL
        {
            get { return _PhotoURL; }
            set { _PhotoURL = value; OnPropertyChanged(); }
        }

        private string _Age;

        public string Age
        {
            get { return _Age; }
            set { _Age = value; OnPropertyChanged(); }
        }

        public Command AvatarTapCommand { get; set; }

        public Command PickFileTapCommand { get; set; }

        public Command CVTapCommand { get; set; }

        private Command<object> _BtnCommand;

        public Command<object> BntCommand
        {
            get { return _BtnCommand; }
            set { _BtnCommand = value; }
        }

        private Command _LogOutCommand;

        public Command LogOutCommand
        {
            get { return _LogOutCommand; }
            set
            {
                _LogOutCommand = value;
                OnPropertyChanged();
            }
        }

        private string _PhotoFromURI;

        public string PhotoFromURI
        {
            get { return _PhotoFromURI; }
            set { _PhotoFromURI = value; OnPropertyChanged(); }
        }

        private bool _PhotoUriVisible = false;

        public bool PhotoUriVisible
        {
            get { return _PhotoUriVisible; }
            set { _PhotoUriVisible = value; OnPropertyChanged(); }
        }

        private bool _PhotoFileVisible = true;

        public bool PhotoFileVisible
        {
            get { return _PhotoFileVisible; }
            set { _PhotoFileVisible = value; OnPropertyChanged(); }
        }

        public void UpdateData()
        {
            //CAbie MainEmployeeView por MainEmployeeViewModel
            MessagingCenter.Subscribe<MainEmployeeViewModel, int>(this, "Status", (sender, arg) =>
            {
                if (arg == 1)
                {
                    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

                    //if (File.Exists(documentsPath))
                    //{
                    //    // Descargar la imagen
                    //    IsUriVisible = false;
                    //    IsFileVisible = true;

                    //    using (var streamReader = new StreamReader(documentsPath))
                    //    {
                    //        var bytes = default(byte[]);
                    //        using (var memstream = new MemoryStream())
                    //        {
                    //            streamReader.BaseStream.CopyTo(memstream);
                    //            bytes = memstream.ToArray();

                    //            Fotico = bytes;
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    // Descargar la imagen
                    IsUriVisible = true;
                    IsFileVisible = false;
                    //Carga desde URL
                    PhotoURL = EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg";

                    //}

                    if (Preferences.Get("Name", "") != "" && (int)Preferences.Get("UserID", 0) > 0 && Preferences.Get("Age", "") != "" && Preferences.Get("Degree", "") != "")
                    {
                        Name = Preferences.Get("Name", "");
                        MyDegree = Preferences.Get("Degree", "");
                        Age = Preferences.Get("Age", "");
                    }
                    else
                    {
                        GetUser();
                    }

                    GetDate();
                    // GetUser();
                }
            });
            MessagingCenter.Subscribe<MainEmployeeView, int>(this, "Status", (sender, arg) =>
            {
                if (arg == 1)
                {
                    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

                    //if (File.Exists(documentsPath))
                    //{
                    //    // Descargar la imagen
                    //    IsUriVisible = false;
                    //    IsFileVisible = true;

                    //    using (var streamReader = new StreamReader(documentsPath))
                    //    {
                    //        var bytes = default(byte[]);
                    //        using (var memstream = new MemoryStream())
                    //        {
                    //            streamReader.BaseStream.CopyTo(memstream);
                    //            bytes = memstream.ToArray();

                    //            Fotico = bytes;
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    if (File.Exists(documentsPath))
                    {
                        MiFotostr = null;

                        using (var streamReader = new StreamReader(documentsPath))
                        {
                            var bytes = default(byte[]);
                            using (var memstream = new MemoryStream())
                            {
                                streamReader.BaseStream.CopyTo(memstream);
                                bytes = memstream.ToArray();

                                MiFotostr = ImageSource.FromStream(() => new MemoryStream(bytes));
                            }
                        }
                    }
                    else //descarga la foto a la memoria
                    {
                        try
                        {
                            var webClient = new WebClient();
                            byte[] imageBytes = webClient.DownloadData(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"));
                            MiFotostr = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                            MemoryStream stream = new MemoryStream(imageBytes);
                            DependencyService.Get<IFileService>().SavePicture((Preferences.Get("UserID", 0)).ToString() + ".jpg", stream);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        //Fotico = imageBytes;
                    }

                    // Descargar la imagen
                    //IsUriVisible = true;
                    //IsFileVisible = false;
                    ////Carga desde URL
                    //PhotoURL = EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg";

                    //}

                    if (Preferences.Get("Name", "") != "" && (int)Preferences.Get("UserID", 0) > 0 && Preferences.Get("Age", "") != "" && Preferences.Get("Degree", "") != "")
                    {
                        Name = Preferences.Get("Name", "");
                        MyDegree = Preferences.Get("Degree", "");
                        Age = Preferences.Get("Age", "");
                    }
                    else
                    {
                        GetUser();
                    }

                    GetDate();
                    // GetUser();
                }
            });
        }

        private bool _IsFileVisible;

        public bool IsFileVisible
        {
            get { return _IsFileVisible; }
            set { _IsFileVisible = value; OnPropertyChanged(); }
        }

        private bool _IsUriVisible;

        public bool IsUriVisible
        {
            get { return _IsUriVisible; }
            set { _IsUriVisible = value; OnPropertyChanged(); }
        }

        private byte[] _fotico;

        public byte[] Fotico
        {
            get { return _fotico; }
            set { _fotico = value; OnPropertyChanged(); }
        }

        private object _SelectedIndex;

        public object SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;

                //if ((int)_SelectedIndex == 2)
                //{
                //    MessagingCenter.Send<HomeViewModel>(this, "Hi");
                //}
                OnPropertyChanged();
            }
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

        private byte[] _JobMatchLogo;

        public byte[] JobMatchLogo
        {
            get { return _JobMatchLogo; }
            set { _JobMatchLogo = value; OnPropertyChanged(); }
        }

        private string _Essential;

        public string Essentiallbl
        {
            get { return _Essential; }
            set { _Essential = value; OnPropertyChanged(); }
        }

        private string _Interest;

        public string Interestlbl
        {
            get { return _Interest; }
            set { _Interest = value; OnPropertyChanged(); }
        }

        private string _Logoutlbl;

        public string Logoutlbl
        {
            get { return _Logoutlbl; }
            set { _Logoutlbl = value; }
        }

        private string _Editinfolbl;

        public string Editinfolbl
        {
            get { return _Editinfolbl; }
            set { _Editinfolbl = value; }
        }

        public Command BtnChatCommand { get; set; }

        public Command<SfPopupLayout> OpenRelativeDialog { get; set; }

        public Command MyProperty { get; set; }

        private Uri mifoto;

        public Uri Mifoto
        {
            get { return mifoto; }
            set { mifoto = value; OnPropertyChanged(); }
        }

        private ImageSource mifotostr;

        public ImageSource MiFotostr
        {
            get { return mifotostr; }
            set { mifotostr = value; OnPropertyChanged(); }
        }

        public HomeViewModel(bool IsEdit)
        {
            this.OpenRelativeDialog = new Command<SfPopupLayout>(this.DisplayDialogRelativeToView);
            //this.MyProperty = new Command(()=>DisplayDialogRelativeToView());

            Academicslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Académico" : "Academics";
            Otherslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Otros" : "Others";
            Jobslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empleos" : "Jobs";
            Interestlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Intereses" : "Interest";
            Essentiallbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Esencial" : "Essential";
            Logoutlbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Cerrar sesión" : "Log out";
            Editinfolbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar información" : "Edit info";

            IsVisible = false;
            PdfVisible = true;
            SelectedIndex = 0;
            DisplayPopup = false;

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

            if (File.Exists(documentsPath))
            {
                using (var streamReader = new StreamReader(documentsPath))
                {
                    var bytes = default(byte[]);
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();

                        MiFotostr = ImageSource.FromStream(() => new MemoryStream(bytes));
                    }
                }
            }
            else //descarga la foto a la memoria
            {
                try
                {
                    var webClient = new WebClient();
                    byte[] imageBytes = webClient.DownloadData(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"));
                    MiFotostr = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                    MemoryStream stream = new MemoryStream(imageBytes);
                    DependencyService.Get<IFileService>().SavePicture((Preferences.Get("UserID", 0)).ToString() + ".jpg", stream);
                }
                catch (Exception)
                {
                    throw;
                }

                //Fotico = imageBytes;
            }

            //    IsUriVisible = false;
            //    IsFileVisible = true;

            //using (var streamReader = new StreamReader(documentsPath))
            //{
            //    var bytes = default(byte[]);
            //    using (var memstream = new MemoryStream())
            //    {
            //        streamReader.BaseStream.CopyTo(memstream);
            //        bytes = memstream.ToArray();

            //        Fotico = bytes;
            //    }
            //}

            //}
            //else
            //{
            // Descargar la imagen
            //IsUriVisible = true;
            //IsFileVisible = false;
            //Carga desde URL
            // MiFotostr = null;
            // MiFotostr = ImageSource.FromUri(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"));

            //MiFotostr  = new UriImageSource
            //{
            //    Uri = new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"),
            //    CachingEnabled = false

            //};
            //Actulizafoto();

            // PhotoURL = ImageSource.FromUri(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"));
            //  PhotoURL = EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg";
            //  Prueba(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg");

            //}

            CVTapCommand = new Command((x) => UpdateCV());
            AvatarTapCommand = new Command<SfPopupLayout>(TakePhoto);
            PickFileTapCommand = new Command<SfPopupLayout>(PickPhoto);
            LogOutCommand = new Command((x) => LogOut());
            BntCommand = new Command<object>(TappedCommandMethod);
            RefreshCommand = new Command(Refresh);

            ItemSelectedCommand = new Command(ItemSelected);
        }

        //public async void Actulizafoto()
        //{
        //    Mifoto = new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg");

        //    var webClient = new WebClient();
        //    byte[] imageBytes = webClient.DownloadData(Mifoto);

        //    Fotico = imageBytes;
        //}

        private void DisplayDialogRelativeToView(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        //private void DisplayDialogRelativeToView()
        //{
        //    App.Current.MainPage.DisplayAlert("", "caca", "on");
        //}
        private async void CheckChatStatus()
        {
            App.Registra();

            App.ChatService1.OnReceivedMessage += ChatService_OnReceivedMessage;

            //Verificar que esta conectado al HUb

            if (!App.ChatService1.IsConnected)
            {
                App.ChatService1 = new TheChat.Core.Services.ChatService();

                if (Preferences.Get("UserID", 0) > 0)
                {
                    await App.ChatService1.InitAsync(Preferences.Get("UserID", 0).ToString());
                }
            }
        }

        private void ChatService_OnReceivedMessage(object sender, TheChat.Core.EventHandlers.MessageEventArgs e)
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
            //JobMe.Models.Chat.ChatMessage msg = new JobMe.Models.Chat.ChatMessage();

            Device.BeginInvokeOnMainThread(async () =>
            {
                //si el mensaje es para mi
                if (nombre == e.Message.Sender)
                {

                    //var toRemove = ChatItems.Where(x => x.ContactID.ToString() == e.Message.Avatar).FirstOrDefault();

                    //ChatItems.Insert(0,toRemove);

                    ChatDetail listItem = null;

                    foreach (var item in ChatItems)
                    {


                        //Actualiza el contador de mensajes
                        if (item.ContactID.ToString() == e.Message.Avatar && item.IDPosition.ToString() == e.Message.Color)
                        {

                            item.CuentaMensajes += 1;
                            item.Time = DateTime.Now.ToString("hh:mm");
                            //ChatItems.Remove(item);

                            //ChatItems.Insert(0, item);
                            listItem = item;
                        }

                        item.ContadorVisible = item.CuentaMensajes > 0;
                    }



                    ChatItems.Remove(listItem);

                    ChatItems.Insert(0, listItem);

                    //ChatItems = new ObservableCollection<ChatDetail>(ChatItems.OrderBy(x => x.Time));

                    //int userid = Preferences.Get("UserID", 0);

                    ////if (Preferences.Get("UserType", 0) == 1)
                    ////{
                    ////        ChatItems = await ChatService.GetContactsEmployeeAsync(userid);
                    ////}
                    ////else if (Preferences.Get("UserType", 0) == 2)
                    //{
                    //        ChatItems = await ChatService.GetContactsEmployerAsync(userid);
                    //}
                    //else if (Preferences.Get("UserType", 0) == 0)
                    //{
                    //    await App.Current.MainPage.DisplayAlert("JobMe", "Error cargando lista de contactos", "Ok");
                    //}


                    //var n = ChatItems.Except(z);






                    //ChatItems = z;

                    IsVisible = ChatItems.Count == 0 ? true : false;

                    // ChatItems = z;
                    //GetContacts();
                }
            });
        }

        public HomeViewModel()
        {
            //Verifica que este conectado al chat y que pueda recibir
            CheckChatStatus();

            Preferences.Set("UserType", 1);

            LastItemText = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "No hay más empleos por el momento" : "No more Jobs available right now";
            Academicslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Académico" : "Academics";
            Otherslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Otros" : "Others";
            Jobslbl = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Empleos" : "Jobs";
            //Congrats = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Felicidades" : "Congratulations";
            //GotoChat= App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ir a Chat Me" : "Go to Chat Me";
            this.DeleteCommand = new Command(this.DeleteMethod);

            IsVisible = false;
            PdfVisible = true;
            SelectedIndex = 0;
            UpdateData();
            DisplayPopup = false;

            //Obtiene la lista de contactos del chat
            GetContacts();

            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

            //if (File.Exists(documentsPath) && Preferences.Get("Name", "") != "")
            //{
            //    IsUriVisible = false;
            //    IsFileVisible = true;

            //    using (var streamReader = new StreamReader(documentsPath))
            //    {
            //        var bytes = default(byte[]);
            //        using (var memstream = new MemoryStream())
            //        {
            //            streamReader.BaseStream.CopyTo(memstream);
            //            bytes = memstream.ToArray();

            //            Fotico = bytes;
            //        }
            //    }

            //if (File.Exists(documentsPath))
            //{
            //    using (var streamReader = new StreamReader(documentsPath))
            //    {
            //        var bytes = default(byte[]);
            //        using (var memstream = new MemoryStream())
            //        {
            //            streamReader.BaseStream.CopyTo(memstream);
            //            bytes = memstream.ToArray();

            //            MiFotostr = ImageSource.FromStream(() => new MemoryStream(bytes));
            //        }
            //    }
            //}
            //else //descarga la foto a la memoria
            //{
            //    try
            //    {
            //        var webClient = new WebClient();
            //        byte[] imageBytes = webClient.DownloadData(new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg"));
            //        MiFotostr = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            //        MemoryStream stream = new MemoryStream(imageBytes);
            //        DependencyService.Get<IFileService>().SavePicture((Preferences.Get("UserID", 0)).ToString() + ".jpg", stream);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }

            //    //Fotico = imageBytes;
            //}

            //}
            //else
            //{
            // Descargar la imagen
            IsUriVisible = true;
            IsFileVisible = false;
            //Carga desde URL
            PhotoURL = EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg";
            //  Prueba(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg");

            //}

            //Obtiene la lista de puestos disponibles
            GetDate();

            CVTapCommand = new Command((x) => UpdateCV());

            AvatarTapCommand = new Command<SfPopupLayout>(TakePhoto);
            PickFileTapCommand = new Command<SfPopupLayout>(PickPhoto);

            LogOutCommand = new Command((x) => LogOut());
            BtnChatCommand = new Command((x) => GoChatMe());
            BntCommand = new Command<object>(TappedCommandMethod);
            RefreshCommand = new Command(Refresh);
            Threshold = (uint)(App.ScreenWidth / 3);
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Command<DraggingCardEventArgs>(OnDraggingCommand);

            ItemSelectedCommand = new Command(ItemSelected);

            //}
            //GetCandidatesLiked(Preferences.Get("UserID", 0));

            //Este pedazo es nuevo
            //if (string.IsNullOrEmpty(Preferences.Get("Name", string.Empty))
            //    && (int)Preferences.Get("UserID", 0) > 0
            //    && string.IsNullOrEmpty(Preferences.Get("Age", string.Empty))
            //    && string.IsNullOrEmpty(Preferences.Get("Degree", string.Empty))
            //    && (int)Preferences.Get("LogOut", 0) != 1)
            //{
            //    Name = Preferences.Get("Name", "");
            //    MyDegree = Preferences.Get("Degree", "");
            //    Age = Preferences.Get("Age", "");
            //}
            //else
            //{
            GetUser();
            //}

            //hasta aqui
        }

        public ObservableCollection<CandidatesLiked> CandidatesLiked { get; set; }

        private async void GetCandidatesLiked(int idPosition)
        {
            CandidatesLiked = await Services.PositionService.GetCandidatesLiked(idPosition);
        }

        private async void GoChatMe()
        {
            DisplayPopup = false;

            //MessagingCenter.Send<HomeViewModel>(this, "Hi");

            await Navigation.PushAsync(new ChatMessagePage(MyChat) { Title = MyChat.SenderName });
            //SelectedIndex = 2;
        }

        public async void GetDate()
        {
            var z = await Services.PositionService.GetPositionsbyCandidateAsync(Preferences.Get("UserID", 0));

            Device.BeginInvokeOnMainThread(() =>
            {
                //Este mocho es nuevo

                if (Data != null)
                {
                    Data.Clear();
                }
                else
                {
                    Data = new ObservableCollection<Positions>();
                }

                if (z.Count > 0)
                {
                    IsLastItem = false;
                }
                else
                {
                    IsLastItem = true;
                }

                Contador = 0;

                foreach (Positions p in z)
                {
                    Data.Add(new Positions()
                    {
                        IDPosition = p.IDPosition,
                        Description = p.Description,
                        Name = p.Name,
                        Logo2 = p.Logo.Length == 0 ? ImageSource.FromFile("notfound.jpg")
                                                            : ImageSource.FromStream(() =>
                                      new MemoryStream(p.Logo)
                            ),
                        Company = p.Company,
                        UserID = p.UserID
                    });
                }

                //Data = new ObservableCollection<Positions>(z);
                //  GetCandidatesLiked(Preferences.Get("UserID", 0));
            });
        }

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

        private string myVar;

        public string MyDegree
        {
            get { return myVar; }
            set { myVar = value; OnPropertyChanged(); }
        }

        private string _Academicslbl;

        public string Academicslbl
        {
            get { return _Academicslbl; }
            set { _Academicslbl = value; OnPropertyChanged(); }
        }

        private string _Jobslbl;

        public string Jobslbl
        {
            get { return _Jobslbl; }
            set { _Jobslbl = value; OnPropertyChanged(); }
        }

        private string _Otherslbl;

        public string Otherslbl
        {
            get { return _Otherslbl; }
            set { _Otherslbl = value; OnPropertyChanged(); }
        }

        private async Task<bool> CameraPermission()
        {
            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (cameraStatus == PermissionStatus.Granted & storageStatus == PermissionStatus.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void GetUser()
        {
            IsBusy = true;
            int userid = (int)Preferences.Get("UserID", 0);

            if (userid > 0)
            {
                //await Task.Delay(200);
                UserModel u = new UserModel();
                u = await Services.UserService.GetUserAsync(userid);

                Name = u.Name;
                // Photo = u.Photo;
                // CV = u.CV;
                MyDegree = u.MyDegree;
                Preferences.Set("Name", u.Name);
                Preferences.Set("Degree", MyDegree);

                DateTime now = DateTime.Today;
                int age = now.Year - u.BirthDate.Year;
                if (u.BirthDate > now.AddYears(-age)) age--;

                DateTime n = DateTime.Now; // To avoid a race condition around midnight
                int myage = n.Year - u.BirthDate.Year;

                //if (n.Month < u.BirthDate.Month || (n.Month == u.BirthDate.Month && n.Day < u.BirthDate.Day))
                //    age--;

                Age = age.ToString();
                Preferences.Set("Age", age.ToString());
            }

            IsBusy = false;
        }

        private async void UpdateCV()
        {
            int userid = (int)Preferences.Get("UserID", 0);
            var u = new UserModel();
            u.UserID = userid;
            try
            {
                if (await GalleryPermission())
                {
                }

                var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permissions.StorageRead))
                    //{
                    //}

                    status = await Permissions.RequestAsync<Permissions.StorageWrite>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var file = await CrossFilePicker.Current.PickFile();

                    if (file != null)
                    {
                        u.CVName = file.FileName;

                        if (u.CVName.Substring(u.CVName.Length - 3).ToUpper() != "PDF" && u.CVName.Substring(u.CVName.Length - 3).ToUpper() != "JPG")
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Tipo de archivo no admitido, solo pdf o jpg", "Ok");
                            return;
                        }

                        var str = file.DataArray;

                        using (var memoryStream = new MemoryStream())
                        {
                            file.GetStream().CopyTo(memoryStream);
                            file.Dispose();
                            u.CV = memoryStream.ToArray();
                        }

                        var response = await Services.UserService.UpdateCV(u);

                        if (response)
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "CV Updated", "Ok");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("JobMe", "Ocurrio un error al actualizar el CV", "Ok");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // await Application.Current.MainPage.DisplayAlert("JobMe", ex.Message, "Ok");
                // throw;
            }
        }

        private async void TappedCommandMethod(object obj)
        {
            string btn = (string)obj;

            switch (btn)
            {
                case "Essential":
                    await Navigation.PushAsync(new EditEmployeeDetail(1)
                    { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar" : "Edit Essential" });
                    break;

                case "Interest":
                    await Navigation.PushAsync(new EditEmployeeDetail(2)
                    { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar" : "Edit Interests" });
                    break;

                case "Academics":
                    await Navigation.PushAsync(new EditEmployeeDetail(3)
                    { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar" : "Edit Academics" });
                    break;

                case "Jobs":
                    await Navigation.PushAsync(new EditEmployeeDetail(4)
                    { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar" : "Edit Jobs" });
                    break;

                case "Others":
                    await Navigation.PushAsync(new EditEmployeeDetail(5)
                    { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar" : "Edit Others" });
                    break;

                default:
                    break;
            }
        }

        private async void TakePhoto(SfPopupLayout popupLayout)
        {
            try
            {
                int userid = (int)Preferences.Get("UserID", 0);

                var mediaOptions = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = false,
                    Directory = "Sample",
                    Name = userid + "_photo.jpg",
                    PhotoSize = PhotoSize.Medium,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    RotateImage = false,
                    CompressionQuality = 80,
                    AllowCropping = true,
                    SaveMetaData = false,
                    CustomPhotoSize = 70 //Resize to 90% of original
                };

                if (!await CameraPermission())
                {
                    return;
                }
                var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            selectedImageFile.GetStreamWithImageRotatedForExternalStorage().CopyTo(memoryStream);

                            await UserService.UploadPhoto(selectedImageFile.GetStreamWithImageRotatedForExternalStorage(), userid.ToString() + ".jpg");

                            MiFotostr = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                            DependencyService.Get<IFileService>().SavePicture(userid.ToString() + ".jpg", selectedImageFile.GetStreamWithImageRotatedForExternalStorage());

                            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                            //documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

                            // MessagingCenter.Send<HomeViewModel>(this, "Hi");
                            //Device.BeginInvokeOnMainThread(() => {
                            //    Mifoto = new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg");
                            //});

                            //var webClient = new WebClient();
                            //byte[] imageBytes = webClient.DownloadData(Mifoto);

                            //using (var streamReader = new StreamReader(documentsPath))
                            //{
                            //    var bytes = default(byte[]);
                            //    using (var memstream = new MemoryStream())
                            //    {
                            //        streamReader.BaseStream.CopyTo(memstream);
                            //        bytes = memstream.ToArray();

                            //        IsFileVisible = true;
                            //        IsUriVisible = false;
                            //       Fotico = imageBytes;
                            //        MessagingCenter.Send<HomeViewModel>(this, "Hi");
                            //    }
                            //}
                            //Mifoto = new Uri(EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg");

                            //}
                            //else
                            //{
                            //    // Descargar la imagen
                            //    IsUriVisible = true;
                            //    IsFileVisible = false;
                            //    //Carga desde URL
                            //    PhotoURL = EndPoint.BACKEND_ENDPOINT + "/uploads/" + (Preferences.Get("UserID", 0)).ToString() + ".jpg";

                            //}

                            // PhotoURL = ImageSource.FromFile(selectedImageFile.Path);

                            //selectedImageFile.Dispose();
                        }

                        popupLayout.IsOpen = false;
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                        // throw;
                    }

                    return;
                };
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                //throw;
            }
        }

        private async Task<bool> GalleryPermission()
        {
            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Media>();
            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Media>();
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (cameraStatus == PermissionStatus.Granted & storageStatus == PermissionStatus.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void PickPhoto(SfPopupLayout popupLayout)
        {
            try
            {
                int userid = (int)Preferences.Get("UserID", 0);

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium,
                    RotateImage = false,
                    CompressionQuality = 80,
                    SaveMetaData = false,
                    CustomPhotoSize = 70 //Resize to 90% of original
                };

                if (!await GalleryPermission())
                {
                    return;
                }
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            //var z = selectedImageFile.GetStreamWithImageRotatedForExternalStorage();

                            await UserService.UploadPhoto(selectedImageFile.GetStreamWithImageRotatedForExternalStorage(), userid.ToString() + ".jpg");

                            DependencyService.Get<IFileService>().SavePicture(userid.ToString() + ".jpg", selectedImageFile.GetStreamWithImageRotatedForExternalStorage());

                            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                            documentsPath = Path.Combine(documentsPath, (Preferences.Get("UserID", 0)).ToString() + ".jpg");

                            using (var streamReader = new StreamReader(documentsPath))
                            {
                                var bytes = default(byte[]);
                                using (var memstream = new MemoryStream())
                                {
                                    streamReader.BaseStream.CopyTo(memstream);
                                    bytes = memstream.ToArray();

                                    IsFileVisible = true;
                                    IsUriVisible = false;
                                    Fotico = bytes;
                                    MessagingCenter.Send<HomeViewModel>(this, "Hi");
                                }
                            }
                        }

                        popupLayout.IsOpen = false;
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                        // throw;
                    }

                    return;
                };
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Job Me", "Ocurrio un error al actualizar la foto", "Ok");
                //throw;
            }
        }

        private void LogOut()
        {
            Preferences.Set("AcademicsVideo", null);
            Preferences.Set("JobsVideo", null);
            Preferences.Set("OthersVideo", null);
            Preferences.Set("UserID", null);
            Preferences.Set("Name", null);
            Preferences.Set("Degree", null);
            Preferences.Set("Age", null);
            Preferences.Set("MyFoto", null);
            Preferences.Set("AcadVideo", null);
            Preferences.Set("JobsVideo", null);
            Preferences.Set("OthersVideo", null);
            Preferences.Set("LogOut", 1);

            Application.Current.MainPage = new NavigationPage(new LandingPage()) { BarBackgroundColor = Color.FromHex(Colores.JobMeOrange) };
        }

        //private async void Prueba(string url)
        //{
        //    var downloadedImage = await ImageService.DownloadImage(url);

        //    if (downloadedImage != null)
        //    {
        //        Stream stream = new MemoryStream(downloadedImage);
        //        DependencyService.Get<IFileService>().SavePicture((Preferences.Get("UserID", 0)).ToString() + ".jpg", stream);
        //    }

        //    //MyProperty = ImageSource.FromStream(() => new MemoryStream(downloadedImage));

        //}

        //static class ImageService
        //{
        //    static readonly HttpClient _client = new HttpClient();

        //    public static Task<byte[]> DownloadImage(string imageUrl)
        //    {
        //        if (!imageUrl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
        //            throw new Exception("iOS and Android Require Https");

        //        return _client.GetByteArrayAsync(imageUrl);
        //    }
        //}

        private ObservableCollection<Positions> myVar1;

        public ObservableCollection<Positions> Data
        {
            get { return myVar1; }
            set { myVar1 = value; OnPropertyChanged(); }
        }

        public int Contador { get; set; }

        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }
        public ICommand RefreshCommand { get; set; }
        public INavigation Navigation { get; set; }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private bool _IsLastItem;

        public bool IsLastItem
        {
            get { return _IsLastItem; }
            set { _IsLastItem = value; OnPropertyChanged(); }
        }

        private async void Refresh(object obj)
        {
            IsRefreshing = true;
            int idemployee = (int)Preferences.Get("UserID", 0);

            {
                var z = await Services.PositionService.GetPositionsbyCandidateAsync(Preferences.Get("UserID", 0));

                Device.BeginInvokeOnMainThread(() =>
                {
                    Data.Clear();

                    if (z.Count > 0)
                    {
                        IsLastItem = false;
                    }
                    else
                    {
                        IsLastItem = true;
                    }

                    Contador = 0;

                    foreach (Positions p in z)
                    {
                        Data.Add(new Positions()
                        {
                            IDPosition = p.IDPosition,
                            Description = p.Description,
                            Name = p.Name,
                            Logo2 = p.Logo.Length == 0 ? ImageSource.FromFile("notfound.jpg") : ImageSource.FromStream(() =>
                                     new MemoryStream(p.Logo)
                            ),
                            Company = p.Company,
                            UserID = p.UserID
                        });
                    }

                    //GetCandidatesLiked(Preferences.Get("UserID", 0));
                });
            }

            IsRefreshing = false;
        }

        private async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            Contador += 1;

            //Like
            if (eventArgs.Direction == SwipeCardDirection.Right)
            {
                //Agregar a la tabla de positions liked
                try
                {
                    Positions item = (Positions)eventArgs.Item;

                    var idposition = item.IDPosition;

                    int userid = (int)Preferences.Get("UserID", 0);

                    Services.EmployerService.AddPositionsLikedAsync(userid, idposition);

                    //var coindice = CandidatesLiked.Where(obj => obj.IDPosition == item.IDPosition).FirstOrDefault();
                    int liked = await Services.PositionService.GetCandidateLiked(userid, idposition);

                    if (liked > 0)
                    {
                        ChatContact ch = new ChatContact()
                        {
                            UserID = userid,
                            ContactUserID = item.UserID,
                            IDPosition = item.IDPosition
                        };

                        JobMatchPosition = item.Name;
                        JobMatchLogo = item.Logo;
                        JobMatchName = Preferences.Get("Name", string.Empty);

                        //Crea la variable para enviar a la pagina de chats
                        MyChat = new ChatDetail()
                        {
                            IDPosition = item.IDPosition,
                            PositionName = item.Name,
                            ContactID = item.UserID,
                            UserID = userid,
                            Logo = item.Logo,
                            SenderName = item.Name,
                            TipoMensaje = 1,  //eMPLOYEE
                        };

                        //Argega un usuario a la lista de chats
                        await ChatService.AddContactAsync(ch);

                        var jm = new JobMatch()
                        {
                            IDPosition = item.IDPosition,
                            UserId = userid
                        };

                        //Argega un usuario a la lista de chats
                        //await ChatService.AddContactAsync(ch);

                        //guardar el jobmatch
                        await Task.Run(() => Services.Chat.ChatService.AddJobMatchAsync(jm));

                        //Actualiza la lista de contactos
                        //MessagingCenter.Send<HomeViewModel>(this, "Hi");

                        //enviar la notificacion
                        Task.Run(() => Services.PushNotifications.PushServices.SendPushAsync(ch.ContactUserID, "👍 JobMatch", "Go to Chat Me"));

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

                        DisplayPopup = true;
                    }
                    else
                    {
                        if (Contador % 3 == 0)
                        {
                            // await Application.Current.MainPage.DisplayAlert("JobMe", "Videos con publicidad", "Ok");
                            await Navigation.PushModalAsync(new VideoPublicidad());
                        }
                    }
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
                    // await Application.Current.MainPage.DisplayAlert("JobMe", "Videos con publicidad", "Ok");
                    await Navigation.PushModalAsync(new VideoPublicidad());
                }
            }

            if (Contador == Data.Count)
            {
                IsLastItem = true;
            }
        }

        public ChatDetail MyChat { get; set; }

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

        private bool _DisplayPopup;

        public bool DisplayPopup
        {
            get { return _DisplayPopup; }
            set { _DisplayPopup = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// ////////////////////////////////
        /// </summary>
        ///
        public Command DeleteCommand { get; set; }

        private bool _IsRunning;

        public bool IsRunning
        {
            get { return _IsRunning; }
            set { _IsRunning = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ChatDetail> chatItems;

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

        public async void GetContacts()
        {
            // IsRunning = true;

            //UserType
            int userid = Preferences.Get("UserID", 0);

            if (Preferences.Get("UserType", 0) == 1)
            {
                ChatItems = await ChatService.GetContactsEmployeeAsync(userid);

                foreach (var item in ChatItems)
                {
                    item.ContadorVisible = item.CuentaMensajes > 0 ? true : false;
                }

            }
            else if (Preferences.Get("UserType", 0) == 2)
            {
                ChatItems = await ChatService.GetContactsEmployerAsync(userid);
            }
            else if (Preferences.Get("UserType", 0) == 0)
            {
                await App.Current.MainPage.DisplayAlert("JobMe", "Error cargando lista de contactos", "Ok");
            }

            IsVisible = ChatItems.Count == 0 ? true : false;
        }

        public ICommand ItemSelectedCommand { get; set; }

        //public Command ItemSelectedCommand
        //{
        //    get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        //}

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
                //Borrar el contador de los mensajes

                foreach (var item in ChatItems)
                {
                    if (item.UserID == z.UserID && item.ContactID == z.ContactID && item.IDPosition == z.IDPosition)
                    {
                        item.CuentaMensajes = 0;
                        item.ContadorVisible = false;
                    }
                }

                Services.Chat.ChatService.UpdateContador(z);
                await Navigation.PushAsync(new ChatMessagePage(z));
            }
            catch (System.Exception ex)
            {
                throw;
            }
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
                        var takeoffsSelected = ChatItems.Where(z => z.IDPosition == ch.IDPosition && z.UserID == ch.UserID && z.ContactID == ch.ContactUserID).FirstOrDefault();
                        ChatItems.Remove(takeoffsSelected);
                        await Application.Current.MainPage.DisplayAlert("JobMe",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se elimino correctamente el chat" : "Chat successfully deleted",
                            "OK");

                        //Activar la etiqueta de no tienes contactos
                        IsVisible = ChatItems.Count > 0 ? false : true;
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
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe",
                          App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrío un error al eliminar el chat" : "Error deleting chat",
                          "OK");
                //throw;
            }
        }
    }
}