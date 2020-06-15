using System;
using System.Collections.Generic;
using System.Text;

namespace JobMe.Models
{
    class CardDataModel : BaseCls
    {

         private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        private string _Puesto;

        public string Puesto
        {
            get { return _Puesto; }
            set
            {
                _Puesto = value;
                OnPropertyChanged();
            }
        }


        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                _Descripcion = value;
                OnPropertyChanged();
            }
        }


        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set
            {
                _Tipo = value;
                OnPropertyChanged();
            }
        }
    }
}
