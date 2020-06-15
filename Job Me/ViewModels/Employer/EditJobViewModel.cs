using JobMe.Models;
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
    class EditJobViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private ObservableCollection<ListaPositions> _ListPos;

        public ObservableCollection<ListaPositions> ListPositions
        {
            get { return _ListPos; }
            set
            {
                _ListPos = value;
                OnPropertyChanged();
            }
        }

        private Command<Object> tappedCommand;

        public Command DeleteCommand { get; set; }
        public Command<object> TappedCommand
        {
            get { return tappedCommand; }
            set { tappedCommand = value; }
        }

        private async void GetPositions()
        {
            IsBusy = true;

            int idcompany = (int)Preferences.Get("idCompany", 0);

            ListPositions = await Services.PositionService.GetPositionsAsync(idcompany);
            await Task.Delay(500);

            IsBusy = false;
        }

        private async void TappedCommandMethod(object obj)
        {
            var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

            ListaPositions p = (ListaPositions)x;

            //   Navigation.PushAsync(new EditJobView() { Title="Edit Position"  });

            var secondPage = new AddJobView(p.IDPosition) { Title = "Edit Position" };

            await Navigation.PushAsync(secondPage);

            //AddJobViewModel(p.IDPosition);

        }

        private async  void DeleteCommandMethod(object obj)
        {
            //var x = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;

            var x = (Positions)obj;

            if (ItemIndex >= 0)
                ListPositions.RemoveAt(ItemIndex);

            //Agregar el metodo de borrado de position
            if (await Services.PositionService.DeletePositionAsync(x.IDPosition))
            {
                await Application.Current.MainPage.DisplayAlert("JobMe!",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se elimino correctemente la vacante" :  "Position successfully deleted",
                    "OK");
                ListView.ResetSwipe();
                MessagingCenter.Send<EditJobViewModel, int>(this, "UpdateList", 1);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("JobMe!",
                    App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Ocurrió un error al eliminar la vacante" :  "Error deleting position",
                    "OK");
            }
          
            //sfListView.ResetSwipe();
          

        }

        private Syncfusion.ListView.XForms.SfListView _ListView;

        public Syncfusion.ListView.XForms.SfListView ListView
        {
            get { return _ListView; }
            set { _ListView = value;  OnPropertyChanged(); }
        }


        private int _itemIndex = -1;

        public int ItemIndex
        {
            get { return _itemIndex ; }
            set { _itemIndex = value; OnPropertyChanged(); }
        }

        public EditJobViewModel()
        {

            GetPositions();

            TappedCommand = new Command<object>(TappedCommandMethod);
            DeleteCommand = new Command<object>(DeleteCommandMethod);
        }
    }
}
