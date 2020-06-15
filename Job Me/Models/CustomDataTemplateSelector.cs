using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JobMe.Models
{
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate VideoTemplate { get; set; }
        public DataTemplate CardTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

            

            if ( ((CardDataModel)item).Tipo == "Video")
            {
                
                return VideoTemplate;
            }
            else
            {
             
                return CardTemplate;
            }
        }
    }
}
