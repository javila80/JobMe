using JobMe.Models;
using JobMe.ViewModels;
using JobMe.ViewModels.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static JobMe.ViewModels.AddJobViewModel;

namespace JobMe.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpresaHomeView : ContentView    
    {
             
        EmpresaHomeViewModel vm = new EmpresaHomeViewModel();

        public EmpresaHomeView()
        {
            InitializeComponent();

           BindingContext = vm;
                  

        }

     

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            /*new NavigationPage(new AddJobView()) { BarBackgroundColor = Color.Blue ,BarTextColor = Color.Yellow }*/
          
           Navigation.PushAsync(new AddJobView() { Title = App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Agregar vacante" :  "Add Jobs" });
            
            // Navigation.PushAsync(new AddJobView() { Title="Add Jobs"  });
            
            //var x =  
            //mainVisible = false;
            //vis = true;

        }

        //Editar las vacantes
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditJobView() { Title= App.Idioma.TwoLetterISOLanguageName == MyIdioma.Español ? "Editar puestos" :  "Edit Position"  });
            //mainVisible = false;
            //frameVisible = true;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Credit() { });
        }
    }
}