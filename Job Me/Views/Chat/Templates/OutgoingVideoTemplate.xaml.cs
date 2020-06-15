using JobMe.Models.Chat;
using JobMe.ViewModels;
using JobMe.Views.Chat.Selectors;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat
{
    /// <summary>
    /// Which is used for outgoing image template
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutgoingVideoTemplate : BindableViewCell

    {
        public OutgoingVideoTemplate()
        {
            InitializeComponent();
            //OutgoingImageTappedCommand = new Command(ClikcMethod);
            //BindingContext = this;
        }

        public Command OutgoingImageTappedCommand { get; set; }

        private async void ClikcMethod(object obj)
        {
            try
            {
                string url = ((ChatMessage)obj).VideoUrl;

                await App.Navigation.PushAsync(new PlayVideo(url) { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Yo" : "Me", });
            }
            catch (System.Exception)
            {
                //throw;
            };
        }
    }
}