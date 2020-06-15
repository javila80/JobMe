using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe.ViewModels.Employee
{
    class RegisterEmployeeViewmodel :BaseViewModel
    {

        private List<CustomCell> _CarouselColllection;
        public List<CustomCell> CarouselColllection
        {
            get { return _CarouselColllection; }
            set
            {
                _CarouselColllection = value;
                OnPropertyChanged();
            }
        }

        private string _Essential;

        public string Essential
        {
            get { return _Essential; }
            set { _Essential = value; OnPropertyChanged(); }
        }

        private string _Interest;

        public string Interest
        {
            get { return _Interest; }
            set { _Interest = value; OnPropertyChanged(); }
        }

        public RegisterEmployeeViewmodel()
        {
            Essential = "Este es la pestaña essential";
            Interest = "Este es la pestaña interest";

            CarouselColllection = new List<CustomCell>();
            CarouselColllection.Add(new CustomCell { TipoHoja = 1 });
            CarouselColllection.Add(new CustomCell { TipoHoja = 2 });
        }
        //Se cargan las pestañas
       
    }
}
