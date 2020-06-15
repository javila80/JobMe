using JobMe.Converter;
using JobMe.Models;
using JobMe.Views;
using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JobMe.ViewModels
{

    class ActivityViewModel : BaseViewModel
    {

        public INavigation Navigation { get; set; }
        public ICommand CardTappedCommand { get; set; }

        private ObservableCollection<Positions> myVar;

        public ObservableCollection<Positions> Data
        {
            get { return myVar; }
            set { myVar = value; OnPropertyChanged(); }
        }

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

        public ICommand RefreshCommand { get; set; }
        public ActivityViewModel()
        {
            RefreshCommand = new Command(Refresh);
            Threshold = (uint)(App.ScreenWidth / 3);

            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Command<DraggingCardEventArgs>(OnDraggingCommand);

            GetPositionsbyCandidate();

        }

         private async void Refresh(object obj)
        {
            IsRefreshing = true;
            int idemployee = (int)Preferences.Get("UserID", 0);
            //Data = null;
           

                Data = await Services.PositionService.GetPositionsbyCandidateAsync(idemployee);

            IsRefreshing = false;
        
        }

        public async void GetPositionsbyCandidate()
        {

            int idemployee = (int)Preferences.Get("UserID", 0);

           
                   
             Data = await Services.PositionService.GetPositionsbyCandidateAsync(idemployee);


            
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

        private bool _IsLastItem;

        public bool IsLastItem
        {
            get { return _IsLastItem; }
            set { _IsLastItem = value; OnPropertyChanged(); }
        }

        public int Contador { get; set; }

        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }

        private async void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            Contador += 1;

            if (Contador % 3 == 0)
            {
                // await Application.Current.MainPage.DisplayAlert("JobMe", "Videos con publicidad", "Ok");
                await Navigation.PushModalAsync(new VideoPublicidad());
            }

            if (Contador == Data.Count)
            {
                IsLastItem = true;
            }
            //Like
            if (eventArgs.Direction == SwipeCardDirection.Right)
            {

                //await Navigation.PushAsync(new VideoPublicidad()) ;

                //Agregar a la tabla de positions liked
                try
                {
                    Positions item = (Positions)eventArgs.Item;

                    var x = item.IDPosition;

                    int userid = (int)Preferences.Get("UserID", 0);

                    Services.EmployerService.AddPositionsLikedAsync(userid, x);

                   
                }
                catch (Exception)
                {

                    // throw;
                }

            }
        }

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

    }
}
