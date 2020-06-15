using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LargePhoto : ContentPage
    {
        public LargePhoto()
        {
            InitializeComponent();
            int userid = Preferences.Get("UserID", 0);

            string url = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + ".jpg";
            //Prueba(url);

            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);
           
            Myfoto.Source= ImageSource.FromStream(() => new MemoryStream(imageBytes));
          
            //Myfoto.Source = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + ".jpg";
        }

        public LargePhoto(int userid)
        {
            InitializeComponent();
           
            Myfoto.Source = EndPoint.BACKEND_ENDPOINT + "uploads/" + userid.ToString() + ".jpg";
        }

        private async void Prueba(string url)
        {

            var downloadedImage = await ImageService.DownloadImage(url);
            Stream stream = new MemoryStream(downloadedImage);

             Myfoto.Source = ImageSource.FromStream(() => new MemoryStream(downloadedImage));

           // DependencyService.Get<IFileService>().SavePicture((Preferences.Get("UserID", 0)).ToString() + ".jpg", stream);
        }

        public LargePhoto(string url)
        {

            InitializeComponent();
            Myfoto.Source = url;

        }


        static class ImageService
        {
            static readonly HttpClient _client = new HttpClient();

            public static Task<byte[]> DownloadImage(string imageUrl)
            {
                try
                {
                    if (!imageUrl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
                        throw new Exception("iOS and Android Require Https");

                    return _client.GetByteArrayAsync(imageUrl);
                }
                catch (Exception ex)
                {
                    return null;
                    
                }
               
            }
        }

    }
}