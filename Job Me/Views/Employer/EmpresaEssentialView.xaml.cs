using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpresaEssentialView : ContentView
    {
        public EmpresaEssentialView()
        {
            InitializeComponent();

            StackLayout sl1 = new StackLayout();


            var inputes = new Label
            {
                Text = "       Essential       ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };


            string fuente = string.Empty;
            FontAttributes atributo = FontAttributes.None;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    fuente = "Font Awesome 5 Free";
                    atributo = FontAttributes.Bold;
                    break; ;
                case Device.Android:
                    fuente = "FontSolid-900.otf#Font Awesome 5 Free Solid";
                    atributo = FontAttributes.None;
                    break;
            };

            //Company
            var inputCompany = new SfTextInputLayout
            {
                Hint = "Company",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputName.HelperText = "Enter your name";
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry()
            };

            //Image
            var imageentry = new Entry();

            imageentry.Focused += Imageentry_Focused;

            var inputlogo = new SfTextInputLayout
            {
                Hint = "Logo",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputName.HelperText = "Enter your name";
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = imageentry
            };

            
            //Description
            var inputDescription = new SfTextInputLayout
            {
                Hint = "Description",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0c0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputName.HelperText = "Enter your name";
                CharMaxLength = 50,
                //inputName.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry()
            };

            //Mail
            var inputMail = new SfTextInputLayout
            {
                Hint = "Mail",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf0e0",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputMail.HelperText = "Enter your Mail";
                //inputMail.CharMaxLength = 3;
                //inputMail.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry()
            };

            //inputName
            var inputName = new SfTextInputLayout
            {
                Hint = "Name",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,

                LeadingView = new Label()
                {
                    Text = "\uf57d",
                    FontFamily = fuente,
                    FontAttributes = atributo,
                    FontSize = 24,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 0, 10, 0)
                },
                ContainerType = ContainerType.Filled,
                //inputCountry.HelperText = "Enter your country";
                CharMaxLength = 50,
                //inputCountry.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry() { Margin = new Thickness(0, 0, 30, 0) }
            };


            //Telephone
            var inputPhone = new SfTextInputLayout
            {
                Hint = "Phone",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf095",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                //inputPhone.HelperText = "Enter your Phone";
                //inputPhone.CharMaxLength = 3;
                // inputPhone.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry()
            };


            //Username                      
            var inputUser = new SfTextInputLayout
            {
                Hint = "Username",
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf406",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                // inputUser.HelperText = "Enter your Username";
                //inputUser.CharMaxLength = 3;
                //inputUser.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry()
            };

            //Password
            var inputPass = new SfTextInputLayout
            {
                Hint = "Password",
                EnablePasswordVisibilityToggle = true,
                InputViewPadding = 5,
                LeadingViewPosition = ViewPosition.Outside,
                LeadingView = new Label()
                {
                    Text = "\uf023",
                    FontFamily = fuente,
                    FontSize = 24,
                    FontAttributes = atributo,
                    TextColor = Color.FromHex(Colores.JobMeGray),
                    VerticalOptions = LayoutOptions.Center
                },
                ContainerType = ContainerType.Filled,
                // inputPass.HelperText = "Enter your Password";
                //inputPass.c = 3;
                //inputPass.ShowCharCount = true;
                HintLabelStyle = new LabelStyle() { FontSize = 16 },
                InputView = new Entry() { IsPassword = true }
            };

            //Add moore
            var lbaddmore = new Label
            {
                Text = " +      Add more contacts      ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                // inputes.FontAttributes = FontAttributes.Bold;
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex(Colores.JobMeOrange),
                Margin = new Thickness(0, 0, 0, 20)
            };



            var lbaddmoretap = new TapGestureRecognizer();
            lbaddmoretap.Tapped += (sender, args) =>
           {

           };


            var lbPalomita = new Label()
            {
                Text = "\uf00c",
                FontFamily = fuente,
                FontSize = 60,
                FontAttributes = atributo,
                TextColor = Color.FromHex(Colores.JobMeOrange),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 80)

            };

            var lbPalomitatap = new TapGestureRecognizer();
            lbPalomitatap.Tapped += async (sender, args) => await AddUser();

            lbPalomita.GestureRecognizers.Add(lbPalomitatap);

            sl1.Orientation = StackOrientation.Vertical;
            //Label label1 = new Label();           
            //label1.SetBinding(Label.TextProperty, "Nombre");
            //label1.BindingContext = vm;

            //sl1.Children.Add(inputNM);
            sl1.Children.Add(inputes);
            sl1.Children.Add(inputCompany);
            sl1.Children.Add(inputlogo);
            
            sl1.Children.Add(inputDescription);
            sl1.Children.Add(inputMail);
            sl1.Children.Add(inputName);
            sl1.Children.Add(inputUser);
            sl1.Children.Add(inputPass);
            sl1.Children.Add(inputPhone);
            sl1.Children.Add(lbaddmore);

            this.Content = sl1;
        }

        private async void Imageentry_Focused(object sender, FocusEventArgs e)
        {
            
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    return;
                }

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };

                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile == null)
                {
                    return;
                }

        }


        private async Task AddUser()
        {
            //IsVisible = true;
            //IsBusy = true;

            await Navigation.PushModalAsync(new SuccessRegister());
        }

    }
}