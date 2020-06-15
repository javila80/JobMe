using Acr.UserDialogs;
using JobMe.Models;
using JobMe.ViewModels;
using JobMe.ViewModels.Employer;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditJobView : ContentPage
    {

        //EditJobViewModel vm = new EditJobViewModel();
        ///
        // EmpresaHomeViewModel vm = new EmpresaHomeViewModel(true);

        AddJobViewModel vm = new AddJobViewModel(0);
        public EditJobView()
        {

            vm.Navigation = Navigation;
            BindingContext = vm;
            InitializeComponent();
        }

        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {



                searchBar = (sender as SearchBar);
                if (listView.DataSource != null)
                {
                    ObservableCollection<ListaPositions> z = vm.ListPositions;

                    //si no hay que buscar
                    //if (string.IsNullOrEmpty(vm.Find))
                    //{
                    //    dirVM.ListaDirectorio = dir;
                    //    return;
                    //}

                    var x = vm.ListPositions.Where(j => j.PostedBy.ToUpperInvariant().Contains(searchBar.Text.ToUpperInvariant()) ||
                                                        j.Name.ToUpperInvariant().Contains(searchBar.Text.ToUpperInvariant())).ToList();

                    ObservableCollection<ListaPositions> model = new ObservableCollection<ListaPositions>(x);
                    //dirVM.ListaDirectorio.Clear();
                    listView.ItemsSource = model;

                }

            });
        }

        //private bool FilterContacts(object obj)
        //{
        //    if (searchBar == null || searchBar.Text == null)
        //        return true;

        //    var contacts = obj as   ListaPositions;

        //    if (contacts.Name.ToLower().Contains(searchBar.Text.ToLower()) || contacts.PostedBy.ToLower().Contains(searchBar.Text.ToLower())
        //         || contacts.Description.ToLower().Contains(searchBar.Text.ToLower()))
        //        return true;
        //    else
        //        return false;
        //}

        //private void DataSource_FilterChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    //Contacts is model class 
        //    ObservableCollection<ListaPositions> contacts = new ObservableCollection<ListaPositions>();
        //    // Get the filtered items
        //    var items = (sender as DataSource).DisplayItems;
        //    foreach (var item in items)
        //        contacts.Add(item as ListaPositions);
        //}

        protected override void OnAppearing()
        {
            vm.ListView = listView;

            int idcompany = (int)Preferences.Get("idCompany", 0);
            int userid = (int)Preferences.Get("UserID", 0);

            Device.BeginInvokeOnMainThread(async () =>
            {
                listView.ItemsSource = await Services.PositionService.GetPositionsAsync(idcompany, userid);
                vm.ListPositions = await Services.PositionService.GetPositionsAsync(idcompany, userid);
                IsBusy = false;
            });


            //   listView.RefreshView();
            base.OnAppearing();
        }

        private void listView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            vm.ItemIndex = -1;
        }

        private void listView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            vm.ItemIndex = e.ItemIndex;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var x = (TappedEventArgs)e;
                var z = (ListaPositions)x.Parameter;

                if (await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    CancelText = "Cancel",
                    OkText = "Ok",
                    Message = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "¿Estás seguro de eliminar la vacante?" : "Are you sure you want to delete the position ?",

                }))
                {

                    //// Agregar el metodo de borrado de position
                    if (await Services.PositionService.DeletePositionAsync(z.IDPosition))
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe!",
                            App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Se elimino correctamente la vacante" : "Position successfully deleted",
                            "OK");

                        MessagingCenter.Send<EditJobView, int>(this, "UpdateList", 1);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("JobMe!", "Error deleting position", "OK");
                    }
                    Device.BeginInvokeOnMainThread(() =>
                    {

                        if (vm.ItemIndex >= 0)
                            vm.ListPositions.RemoveAt(vm.ItemIndex);


                        listView.ItemsSource = vm.ListPositions;
                    });

                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe!", "Error deleting position", "OK");
                //throw;
            }
           

            listView.ResetSwipe();
           
            



        }
    }
}