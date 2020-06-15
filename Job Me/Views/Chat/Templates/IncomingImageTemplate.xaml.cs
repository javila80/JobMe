using JobMe.Models.Chat;
using JobMe.ViewModels;
using JobMe.ViewModels.Chat;
using JobMe.Views.Chat.Selectors;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat
{
    /// <summary>
    /// Which is used for incoming image template
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingImageTemplate : BindableViewCell
    {

        public IncomingImageTemplate()
        {
            InitializeComponent();
            //ImageTappedCommand = new Command(ClikcMethod);
            //BindingContext = this;
        }

        public Command ImageTappedCommand { get; set; }


        private async void ClikcMethod(object obj)
        {
            try
            {
                string url = ((ChatMessage)obj).ImageUrl;
                string name = ((ChatMessage)obj).Sender;
                              
          
                    await App.Navigation.PushAsync(new LargePhoto(url) { Title = name });
              

            }
            catch (System.Exception ex)
            {

                throw ;
            };


        }

    }
}