using JobMe.ViewModels;
using JobMe.ViewModels.Employer;
using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static JobMe.ViewModels.AddJobViewModel;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJobView : ContentPage
    {


        public AddJobView()
        {
            AddJobViewModel vm = new AddJobViewModel();
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;

        }

        //public AddJobView()
        //{
        //    EmpresaHomeViewModel vm = new EmpresaHomeViewModel();
        //    InitializeComponent();
        //    vm.Navigation = Navigation;
        //    BindingContext = vm;

        //}
        //
        public AddJobView(int idposition)
        {
         // EmpresaHomeViewModel vm = new EmpresaHomeViewModel(idposition);
            AddJobViewModel vm = new AddJobViewModel(idposition);
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;


        }

        protected override void OnAppearing()
        {

            
            base.OnAppearing();
        }
    }
}