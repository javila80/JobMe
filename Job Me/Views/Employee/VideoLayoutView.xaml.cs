using FormsVideoLibrary;
using JobMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoLayoutView : ContentView
    {

        // ActivityViewModel vm = new ActivityViewModel();
        public VideoLayoutView()
        {


            MessagingCenter.Subscribe<ActivityView, int>(this, "ColliDaVentilare", (sender, arg) =>
            {

                if (arg == 1)

                {
                    var x = videoPlayer.Status;

                    videoPlayer.Play();

                    //if (videoPlayer.Status == VideoStatus.Playing)
                    //{
                    //    videoPlayer.Pause();
                    //}
                    //else if (videoPlayer.Status == VideoStatus.Paused)
                    //{
                    //    videoPlayer.Play();
                    //}
                    //else
                    //{

                    //    videoPlayer.Play();
                    //}

                }
                else
                {

                    videoPlayer.Pause();

                }

            });

            MessagingCenter.Subscribe<MainEmployeeView, int>(this, "Status", (sender, arg) =>
            {

                if (videoPlayer.Status == VideoStatus.Playing)
                {
                    videoPlayer.Stop();
                }


            });

            InitializeComponent();

        }
    }
}