using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CV : ContentPage
    {

        private Stream m_pdfDocumentStream;

        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
       //public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer. 
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                OnPropertyChanged();
            }

        }
        public CV(Stream pdf)
        {
            InitializeComponent();


            m_pdfDocumentStream = pdf;

            BindingContext = this;
        }

        public CV(int userid)
        {
            InitializeComponent();

            LoadCVNew(userid);

            BindingContext = this;
        }


        private async void LoadPDF(int userid)
        {

            try
            {

                byte[] CV = await Services.UserService.GetCVAsync(userid);


                if (CV != null && CV.Length > 0)
                {

                    Stream streamCV = new MemoryStream(CV);

                    PdfDocumentStream = streamCV;

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
                }


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "Error al obtener el CV de este usuario", "Ok");

                //throw new Exception( ex.Message);
            }

        }

        private async void LoadPDFModel(int userid)
        {

            try
            {

                var z = await Services.UserService.GetCVModelAsync(userid);


                if (z.CV != null && z.CV.Length > 0)
                {

                    if (!string.IsNullOrEmpty(z.CVName))
                    {
                        switch (z.CVName.Substring(z.CVName.Length - 3).ToUpper())
                        {
                            case "PDF":

                                //SfPdfViewer sfPdf = new SfPdfViewer()
                                //{
                                //    InputFileStream = new MemoryStream(z.CV),
                                //    VerticalOptions = LayoutOptions.FillAndExpand

                                //};

                                //mainGrid.Children.Add(sfPdf, 0, 0);

                                Stream streamCV = new MemoryStream(z.CV);
                                //cvimage.IsVisible = false;
                                //pdfViewerControl.IsVisible = true;
                                PdfDocumentStream = streamCV;
                                return;
                            case "JPG":

                                //SfImage img = new SfImage()
                                //{
                                //    Source = ImageSource.FromStream(() => new MemoryStream(z.CV)),
                                //    VerticalOptions = LayoutOptions.FillAndExpand
                                //};
                                //mainGrid.Children.Add(img, 0, 0);
                                //pdfViewerControl.IsVisible = false;
                                //cvimage.IsVisible = true;
                                //cvimage.Source = ImageSource.FromStream(() => new MemoryStream(z.CV));
                                return;
                            default:

                                break;
                        }
                    }
                    else
                    {
                        Stream streamCV = new MemoryStream(z.CV);
                        //cvimage.IsVisible = false;
                        // pdfViewerControl.IsVisible = true;
                        PdfDocumentStream = streamCV;
                    }





                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
                }


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "Error al obtener el CV de este usuario", "Ok");

                //throw new Exception( ex.Message);
            }

        }

        private async void LoadCVNew(int userid)
        {

            try
            {

                var z = await Services.UserService.GetCVModelAsync(userid);


                if (z.CV != null && z.CV.Length > 0)
                {

                    if (!string.IsNullOrEmpty(z.CVName))
                    {
                        switch (z.CVName.Substring(z.CVName.Length - 3).ToUpper())
                        {
                            case "PDF":
                                var pdfv = new SfPdfViewer()
                                {
                                    PreserveSignaturePadOrientation = true,
                                };

                                Stream streamCV = new MemoryStream(z.CV);
                                pdfv.InputFileStream = streamCV;

                                mainGrid.Children.Add(pdfv);
                                return;
                            case "JPG":

                                SfImage img = new SfImage()
                                {
                                    Source = ImageSource.FromStream(() => new MemoryStream(z.CV)),
                                    VerticalOptions = LayoutOptions.FillAndExpand
                                };
                                mainGrid.Children.Add(img, 0, 0);

                                return;
                            default:
                                
                                await Application.Current.MainPage.DisplayAlert("JobMe", "Formato de archivo no soportado", "Ok");
                                await Navigation.PopAsync();
                                break;


                        }
                    }
                    else
                    {
                        var pdfv = new SfPdfViewer()
                        {
                            PreserveSignaturePadOrientation = true,
                        };

                        Stream streamCV = new MemoryStream(z.CV);
                        pdfv.InputFileStream = streamCV;

                        mainGrid.Children.Add(pdfv);
                        return;
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
                }

            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("JobMe", "No se encontro el CV de este usuario", "Ok");
            }

        }

    }

}
