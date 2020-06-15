using JobMe.Models;
using JobMe.Views;
using JobMe.Views.Employer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{
    public class ActivityEmpresaViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private Command<Object> tappedCommand;

        public Command<object> TappedCommand
        {
            get { return tappedCommand; }
            set { tappedCommand = value; }
        }
        private ObservableCollection<ListaPositions> _ListPositions;
        public ObservableCollection<ListaPositions> ListPositions
        {
            get { return _ListPositions; }
            set
            {
                this._ListPositions = value;
                this.OnPropertyChanged();
            }
        }
        public ActivityEmpresaViewModel()
        {
            TappedCommand = new Command<object>(TappedCommandMethod);
            UpdateData();
            GetPositions();
        }

        private async void TappedCommandMethod(object obj)
        {
            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

            ListaPositions f = (ListaPositions)x;

            await Navigation.PushAsync(new PositionSelectedView(f) { Title = f.Name });


        }

        private async void GetPositions()
        {
            IsBusy = true;

            int idcompany = Preferences.Get("idCompany", 0);
            int userid = Preferences.Get("UserID", 0);
            if (idcompany > 0)
            {

                ListPositions = await Services.PositionService.GetPositionsAsync(idcompany, userid);
               // await Task.Delay(500);

            }


            IsBusy = false;
        }

        public void UpdateData()
        {
            MessagingCenter.Subscribe<EditJobViewModel, int>(this, "UpdateList", (sender, arg) =>
            {

                if (arg == 1)
                {
                    GetPositions();
                    // GetUser();
                }


            });

            MessagingCenter.Subscribe<EditJobView, int>(this, "UpdateList", (sender, arg) =>
            {

                if (arg == 1)
                {
                    GetPositions();
                    // GetUser();
                }


            });

            MessagingCenter.Subscribe<AddJobViewModel, int>(this, "UpdateList", (sender, arg) =>
            {

                if (arg == 1)
                {
                    GetPositions();
                        // GetUser();
                    }


            });
        }

    }
}
