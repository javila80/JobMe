using JobMe.Models;
using JobMe.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityEmpresaView : ContentView
    {
        private ActivityEmpresaViewModel vm = new ActivityEmpresaViewModel();

        public ActivityEmpresaView()
        {
            vm.Navigation = Navigation;
            BindingContext = vm;
            InitializeComponent();
        }

        private SearchBar searchBar = null;

        private void filterText_TextChanged(object sender, TextChangedEventArgs e)
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

                    if (!string.IsNullOrEmpty(searchBar.Text))
                    {
                        var x = vm.ListPositions.Where(j => j.PostedBy.ToUpperInvariant().Contains(searchBar.Text.ToUpperInvariant()) ||
                                                       j.Name.ToUpperInvariant().Contains(searchBar.Text.ToUpperInvariant())).ToList();

                        ObservableCollection<ListaPositions> model = new ObservableCollection<ListaPositions>(x);
                        //dirVM.ListaDirectorio.Clear();
                        listView.ItemsSource = model;
                    }
                    else
                    {
                        listView.ItemsSource = vm.ListPositions;
                    }
                }
            });
        }
    }
}