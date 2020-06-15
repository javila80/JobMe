using JobMe.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe.Converter
{
    class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource imgSource = null;
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                imgSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return imgSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class ImagePathConverter : IValueConverter

    {
        public static string GetImageSource(string resourceName)
        {
            var coll = resourceName.Split('.');
            if (coll.Length == 0)
            {
                throw new ArgumentException("The provided resource name is invalid. Example, SampleBrowser.SfChart.Button.png");
            }

            var assemblyName = coll[0] + "." + coll[1] + ".UWP";
            var assetName = coll[2] + "." + coll[3];

            if (Device.RuntimePlatform != Device.UWP)
            {
                return assetName;
            }

            return assemblyName + "\\" + assetName;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return GetImageSource(parameter.ToString());
            }

            return GetImageSource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class SelectionBoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return ImageSource.FromResource("ListViewGridLayout.Images.Selected.png");
            else
                return ImageSource.FromResource("ListViewGridLayout.Images.NotSelected.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InverseZeroVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int && (int)value > 0)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class ZeroVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int && (int)value <= 0)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class TotalItemsCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int && (int)value <= 1)
                return value + " Item |";
            return value + " Items |";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class CurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = (double)value;
            return string.Format("${0:0.00}", d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //[Preserve(AllMembers = true)]
        //public class ListViewBoolToSortImageConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
        //        var sortOptions = (ListViewSortOptions)value;

        //        if (sortOptions == ListViewSortOptions.Ascending)
        //            return ImageSource.FromResource("SortingFiltering.Images.Sort_Ascending.png", assembly);
        //        else if (sortOptions == ListViewSortOptions.Descending)
        //            return ImageSource.FromResource("SortingFiltering.Images.Sort_Decending.png", assembly);
        //        else
        //            return ImageSource.FromResource("SortingFiltering.Images.SortIcon.png", assembly);
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

       
    }
    public class BoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          
            if (value == null)
                return null;


            var isBold = (bool)value;

            if (isBold)
            {
                return value;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                return FontAttributes.None;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                return FontAttributes.Bold;
            }
            
            return FontAttributes.None; ;


            //var isBold = (bool)value;
            //if (isBold)
            //{
            //    return FontAttributes.Bold;
            //}
            //else
            //{
            //    return FontAttributes.None;
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;

            string data = (string)value ;

            if (data == null || data == string.Empty || !data.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.Format("StringToUriConverter expects a string starting with http(s). You gave it '{0}'", value);
                // LogDebug(message);
                return string.Empty;
            }

            return new Uri(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Converting a Uri back to a string isn't supported (yet) ");
        }
    }
}
