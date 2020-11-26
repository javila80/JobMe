using Acr.UserDialogs;
using JobMe.ViewModels;

using Syncfusion.SfRotator.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobMe.Models;
//using Vision;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PanCardView;
using PanCardView.Enums;
using PanCardView.EventArgs;

namespace JobMe.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterEmployeeView : ContentPage
    {

        MainEmployeeViewModel vm = new MainEmployeeViewModel();
        public RegisterEmployeeView()
        {
            InitializeComponent();

            // VerificaPermisos();
            vm.Navigation = Navigation;
            BindingContext = vm;

        }


        protected override bool OnBackButtonPressed()
        {
            //Deshabilita la navegacion hacia atras
            return true;
            // return base.OnBackButtonPressed();
        }

        private async void VerificaPermisos()
        {

            try
            {



                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    //{
                    //    await DisplayAlert("Need location", "Gunna need to use camera", "OK");
                    //}
                    status = await Permissions.RequestAsync<Permissions.Camera>();
                    //status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                }

                if (status == PermissionStatus.Granted)
                {
                    //Query permission
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("JobMe", ex.Message, "Ok");
                //Something went wrong
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            // 
            UserDialogs.Instance.ShowLoading("Loading...");
            await Task.Delay(500);
            UserDialogs.Instance.HideLoading();
            var z = e.PreviousItem;


        }
        private bool _isLocked;

       // private UserRegistry vm.userlocal = new UserRegistry();

        private int rotatorindex = 0;

        private async void rotator_SelectedIndexChanged(object sender, SelectedIndexChangedEventArgs e)
        {
            try
            {
                if (_isLocked) return;
                _isLocked = true; /* your code here */

                if (rotator.SelectedIndex <= rotatorindex)
                {
                    //Se esta regresando
                    //rotator.EnableSwiping = true;

                    rotatorindex = rotator.SelectedIndex;

                    _isLocked = false;
                    return;

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }


            //rotator.EnableSwiping = false;
            if (rotator.SelectedIndex == 1)
            {
                if (!await vm.ValidaEssential())
                {

                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    var n = await App.Database.GetUserAsync(1);
                    var cn = await App.Database.GetUsersAsync();

                    if (n != null)
                    {
                        vm.userlocal = n;
                    }



                    vm.userlocal.Name = vm.Name;
                    vm.userlocal.IDCountry = vm.Country.IDCountry;
                    vm.userlocal.Country = vm.Country.Country;

                    vm.userlocal.City = vm.City?.City;
                    vm.userlocal.IDCity = vm.City != null ? vm.City.IDCity : 0;

                    vm.userlocal.IDGender = vm.Gender.IDGender;
                    vm.userlocal.Gender = vm.Gender.Gender;
                    vm.userlocal.BirthDate = vm.BirthDate;
                    vm.userlocal.Mail = vm.Mail;
                    vm.userlocal.Password = vm.Password;
                    vm.userlocal.Phone = vm.Phone;
                    vm.userlocal.UserName = vm.UserName;


                    if (n != null)
                    {
                        vm.userlocal.ID = 1;
                        await App.Database.UpdateUserAsync(vm.userlocal);
                    }
                    else
                    {
                        vm.userlocal.ID = 1;
                        await App.Database.SaveUserAsync(vm.userlocal);
                    }



                    rotatorindex = rotator.SelectedIndex;
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }


            }
            else if (rotator.SelectedIndex == 2)
            {
                if (!await vm.ValidaInterest())
                {

                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {

                    vm.userlocal.ID = 1;
                    vm.userlocal.Name = vm.Name;
                    vm.userlocal.IDCountry = vm.Country.IDCountry;
                    vm.userlocal.Country = vm.Country.Country;

                    vm.userlocal.City = vm.City?.City;
                    vm.userlocal.IDCity = vm.City != null ? vm.City.IDCity : 0;

                    vm.userlocal.IDGender = vm.Gender.IDGender;
                    vm.userlocal.Gender = vm.Gender.Gender;
                    vm.userlocal.BirthDate = vm.BirthDate;
                    vm.userlocal.Mail = vm.Mail;
                    vm.userlocal.Password = vm.Password;
                    vm.userlocal.Phone = vm.Phone;
                    vm.userlocal.UserName = vm.UserName;
                    //Interest
                    vm.userlocal.BusinessFields = JsonConvert.SerializeObject(vm.BusinessFields);
                    vm.userlocal.Areas = JsonConvert.SerializeObject(vm.MiArea);
                    vm.userlocal.IDSalary = vm.Salary.IDSalary;
                    vm.userlocal.Salary = vm.Salary.Salary;
                    vm.userlocal.TypeofJob = (int)vm.TypeofJob;
                    vm.userlocal.TravelAvailable = (int)vm.TravelAvailable;
                    vm.userlocal.ChangeResidence = (int)vm.ChangeResidence;





                    await App.Database.UpdateUserAsync(vm.userlocal);
                    rotatorindex = rotator.SelectedIndex;
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex == 3)
            {
                if (!await vm.ValidaAcademics())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {

                    vm.userlocal.IDSchool = vm.School != null ? vm.School.IDSchool : 0;
                    vm.userlocal.School = vm.School != null ? vm.School.School : string.Empty;

                    vm.userlocal.IDSchool1 = vm.School1 != null ? vm.School1.IDSchool : 0;
                    vm.userlocal.School1 = vm.School1 != null ? vm.School1.School : string.Empty;

                    vm.userlocal.IDSchool2 = vm.School2 != null ? vm.School2.IDSchool : 0;
                    vm.userlocal.School2 = vm.School2 != null ? vm.School2.School : string.Empty;

                    vm.userlocal.IDSchool3 = vm.School3 != null ? vm.School3.IDSchool : 0;
                    vm.userlocal.School3 = vm.School3 != null ? vm.School3.School : string.Empty;

                    vm.userlocal.IDSchool4 = vm.School4 != null ? vm.School4.IDSchool : 0;
                    vm.userlocal.School4 = vm.School4 != null ? vm.School4.School : string.Empty;

                    vm.userlocal.IDDegre = vm.Degree != null ? vm.Degree.IDDegree : 0;
                    vm.userlocal.Degree = vm.Degree != null ? vm.Degree.Degree : string.Empty;

                    vm.userlocal.IDDegre1 = vm.Degree1 != null ? vm.Degree1.IDDegree : 0;
                    vm.userlocal.Degree1 = vm.Degree1 != null ? vm.Degree1.Degree : string.Empty;

                    vm.userlocal.IDDegre2 = vm.Degree2 != null ? vm.Degree2.IDDegree : 0;
                    vm.userlocal.Degree2 = vm.Degree2 != null ? vm.Degree2.Degree : string.Empty;

                    vm.userlocal.IDDegre3 = vm.Degree3 != null ? vm.Degree3.IDDegree : 0;
                    vm.userlocal.Degree3 = vm.Degree3 != null ? vm.Degree3.Degree : string.Empty;

                    vm.userlocal.IDDegre4 = vm.Degree4 != null ? vm.Degree4.IDDegree : 0;
                    vm.userlocal.Degree4 = vm.Degree4 != null ? vm.Degree4.Degree : string.Empty;

                    vm.userlocal.IDGY = vm.GraduationYears != null ? vm.GraduationYears.IDGraduationYear : 0;
                    vm.userlocal.GY = vm.GraduationYears != null ? vm.GraduationYears.Year : string.Empty;

                    vm.userlocal.IDGY1 = vm.GraduationYears1 != null ? vm.GraduationYears1.IDGraduationYear : 0;
                    vm.userlocal.GY1 = vm.GraduationYears1 != null ? vm.GraduationYears1.Year : string.Empty;

                    vm.userlocal.IDGY2 = vm.GraduationYears2 != null ? vm.GraduationYears2.IDGraduationYear : 0;
                    vm.userlocal.GY2 = vm.GraduationYears2 != null ? vm.GraduationYears2.Year : string.Empty;

                    vm.userlocal.IDGY3 = vm.GraduationYears3 != null ? vm.GraduationYears3.IDGraduationYear : 0;
                    vm.userlocal.GY3 = vm.GraduationYears3 != null ? vm.GraduationYears3.Year : string.Empty;

                    vm.userlocal.IDGY4 = vm.GraduationYears4 != null ? vm.GraduationYears4.IDGraduationYear : 0;
                    vm.userlocal.GY4 = vm.GraduationYears4 != null ? vm.GraduationYears4.Year : string.Empty;


                    vm.userlocal.Certifications = vm.Certifications != null ? JsonConvert.SerializeObject(vm.Certifications) : string.Empty;
                    vm.userlocal.Languajes = JsonConvert.SerializeObject(vm.Languajes);

                    await App.Database.UpdateUserAsync(vm.userlocal);
                    rotatorindex = rotator.SelectedIndex;
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex == 4)
            {
                if (!await vm.ValidaVideoAcademics())
                {
                    rotator.SetValue(SfRotator.SelectedIndexProperty, rotator.SelectedIndex - 1);
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotatorindex = rotator.SelectedIndex;
                    //rotator.EnableSwiping = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (rotator.SelectedIndex == 5)
            {
                vm.userlocal.Firm = vm.Firm;
                vm.userlocal.Firm1 = vm.Firm1;
                vm.userlocal.Firm2 = vm.Firm2;
                vm.userlocal.Firm3 = vm.Firm3;
                vm.userlocal.Firm4 = vm.Firm4;

                vm.userlocal.JobTitle = vm.JobTitle;
                vm.userlocal.JobTitle1 = vm.JobTitle1;
                vm.userlocal.JobTitle2 = vm.JobTitle2;
                vm.userlocal.JobTitle3 = vm.JobTitle3;
                vm.userlocal.JobTitle4 = vm.JobTitle4;

                vm.userlocal.Experience = JsonConvert.SerializeObject(vm.Experiences);
                vm.userlocal.Experience1 = JsonConvert.SerializeObject(vm.Experiences1);
                vm.userlocal.Experience2 = JsonConvert.SerializeObject(vm.Experiences2);
                vm.userlocal.Experience3 = JsonConvert.SerializeObject(vm.Experiences3);
                vm.userlocal.Experience4 = JsonConvert.SerializeObject(vm.Experiences4);

                vm.userlocal.Mifecha = vm.Mifecha;
                vm.userlocal.Mifecha1 = vm.Mifecha1;
                vm.userlocal.Mifecha2 = vm.Mifecha2;
                vm.userlocal.Mifecha3 = vm.Mifecha3;
                vm.userlocal.Mifecha4 = vm.Mifecha4;
                rotatorindex = rotator.SelectedIndex;
                await App.Database.UpdateUserAsync(vm.userlocal);
            }
            else if (rotator.SelectedIndex != 0)
            {
                rotatorindex = rotator.SelectedIndex;
                UserDialogs.Instance.ShowLoading();
                await Task.Delay(600);
                UserDialogs.Instance.HideLoading();
            }

            //rotator.EnableSwiping = true;



            _isLocked = false;

            //Aqui se podria validar
            ////rotator.EnableSwiping = false;
            //await vm.Validame(sender);

            ////rotator.EnableSwiping = true;
        }

        private async void CardsView_OnItemSwiped(CardsView view, ItemSwipedEventArgs args)
        {

            var indeView = view;

            rotator.IsPanSwipeEnabled = false;
           

            try
            {
                if (_isLocked) return;
                _isLocked = true; /* your code here */

                if (args.Direction == ItemSwipeDirection.Right)
                {
                    //Se esta regresando
                    //rotator.EnableSwiping = true;

                    rotator.IsPanSwipeEnabled = true;

                    _isLocked = false;
                    return;

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }


            //rotator.EnableSwiping = false;
            if (args.Index == 0)
            {
                if (!await vm.ValidaEssential())
                {

                    rotator.SetValue(CardsView.SelectedIndexProperty, indeView.OldIndex);
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    var n = await App.Database.GetUserAsync(1);
                    var cn = await App.Database.GetUsersAsync();

                    if (n != null)
                    {
                        vm.userlocal = n;
                    }



                    vm.userlocal.Name = vm.Name;
                    vm.userlocal.IDCountry = vm.Country.IDCountry;
                    vm.userlocal.Country = vm.Country.Country;

                    vm.userlocal.City = vm.City?.City;
                    vm.userlocal.IDCity = vm.City != null ? vm.City.IDCity : 0;

                    vm.userlocal.IDGender = vm.Gender.IDGender;
                    vm.userlocal.Gender = vm.Gender.Gender;
                    vm.userlocal.BirthDate = vm.BirthDate;
                    vm.userlocal.Mail = vm.Mail;
                    vm.userlocal.Password = vm.Password;
                    vm.userlocal.Phone = vm.Phone;
                    vm.userlocal.UserName = vm.UserName;


                    if (n != null)
                    {
                        vm.userlocal.ID = 1;
                        await App.Database.UpdateUserAsync(vm.userlocal);
                    }
                    else
                    {
                        vm.userlocal.ID = 1;
                        await App.Database.SaveUserAsync(vm.userlocal);
                    }



                    rotatorindex = rotator.SelectedIndex;
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }


            }
            else if (args.Index == 1)
            {
                if (!await vm.ValidaInterest())
                {

                    rotator.SetValue(CardsView.SelectedIndexProperty, indeView.OldIndex);
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
                else
                {

                    vm.userlocal.ID = 1;
                    vm.userlocal.Name = vm.Name;
                    vm.userlocal.IDCountry = vm.Country.IDCountry;
                    vm.userlocal.Country = vm.Country.Country;

                    vm.userlocal.City = vm.City?.City;
                    vm.userlocal.IDCity = vm.City != null ? vm.City.IDCity : 0;

                    vm.userlocal.IDGender = vm.Gender.IDGender;
                    vm.userlocal.Gender = vm.Gender.Gender;
                    vm.userlocal.BirthDate = vm.BirthDate;
                    vm.userlocal.Mail = vm.Mail;
                    vm.userlocal.Password = vm.Password;
                    vm.userlocal.Phone = vm.Phone;
                    vm.userlocal.UserName = vm.UserName;
                    //Interest
                    vm.userlocal.BusinessFields = JsonConvert.SerializeObject(vm.BusinessFields);
                    vm.userlocal.Areas = JsonConvert.SerializeObject(vm.MiArea);
                    vm.userlocal.IDSalary = vm.Salary.IDSalary;
                    vm.userlocal.Salary = vm.Salary.Salary;
                    vm.userlocal.TypeofJob = (int)vm.TypeofJob;
                    vm.userlocal.TravelAvailable = (int)vm.TravelAvailable;
                    vm.userlocal.ChangeResidence = (int)vm.ChangeResidence;


                    await App.Database.UpdateUserAsync(vm.userlocal);
                    rotatorindex = rotator.SelectedIndex;
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (args.Index == 2)
            {
                if (!await vm.ValidaAcademics())
                {
                    rotator.SetValue(CardsView.SelectedIndexProperty, indeView.OldIndex);
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
                else
                {

                    vm.userlocal.IDSchool = vm.School != null ? vm.School.IDSchool : 0;
                    vm.userlocal.School = vm.School != null ? vm.School.School : string.Empty;

                    vm.userlocal.IDSchool1 = vm.School1 != null ? vm.School1.IDSchool : 0;
                    vm.userlocal.School1 = vm.School1 != null ? vm.School1.School : string.Empty;

                    vm.userlocal.IDSchool2 = vm.School2 != null ? vm.School2.IDSchool : 0;
                    vm.userlocal.School2 = vm.School2 != null ? vm.School2.School : string.Empty;

                    vm.userlocal.IDSchool3 = vm.School3 != null ? vm.School3.IDSchool : 0;
                    vm.userlocal.School3 = vm.School3 != null ? vm.School3.School : string.Empty;

                    vm.userlocal.IDSchool4 = vm.School4 != null ? vm.School4.IDSchool : 0;
                    vm.userlocal.School4 = vm.School4 != null ? vm.School4.School : string.Empty;

                    vm.userlocal.IDDegre = vm.Degree != null ? vm.Degree.IDDegree : 0;
                    vm.userlocal.Degree = vm.Degree != null ? vm.Degree.Degree : string.Empty;

                    vm.userlocal.IDDegre1 = vm.Degree1 != null ? vm.Degree1.IDDegree : 0;
                    vm.userlocal.Degree1 = vm.Degree1 != null ? vm.Degree1.Degree : string.Empty;

                    vm.userlocal.IDDegre2 = vm.Degree2 != null ? vm.Degree2.IDDegree : 0;
                    vm.userlocal.Degree2 = vm.Degree2 != null ? vm.Degree2.Degree : string.Empty;

                    vm.userlocal.IDDegre3 = vm.Degree3 != null ? vm.Degree3.IDDegree : 0;
                    vm.userlocal.Degree3 = vm.Degree3 != null ? vm.Degree3.Degree : string.Empty;

                    vm.userlocal.IDDegre4 = vm.Degree4 != null ? vm.Degree4.IDDegree : 0;
                    vm.userlocal.Degree4 = vm.Degree4 != null ? vm.Degree4.Degree : string.Empty;

                    vm.userlocal.IDGY = vm.GraduationYears != null ? vm.GraduationYears.IDGraduationYear : 0;
                    vm.userlocal.GY = vm.GraduationYears != null ? vm.GraduationYears.Year : string.Empty;

                    vm.userlocal.IDGY1 = vm.GraduationYears1 != null ? vm.GraduationYears1.IDGraduationYear : 0;
                    vm.userlocal.GY1 = vm.GraduationYears1 != null ? vm.GraduationYears1.Year : string.Empty;

                    vm.userlocal.IDGY2 = vm.GraduationYears2 != null ? vm.GraduationYears2.IDGraduationYear : 0;
                    vm.userlocal.GY2 = vm.GraduationYears2 != null ? vm.GraduationYears2.Year : string.Empty;

                    vm.userlocal.IDGY3 = vm.GraduationYears3 != null ? vm.GraduationYears3.IDGraduationYear : 0;
                    vm.userlocal.GY3 = vm.GraduationYears3 != null ? vm.GraduationYears3.Year : string.Empty;

                    vm.userlocal.IDGY4 = vm.GraduationYears4 != null ? vm.GraduationYears4.IDGraduationYear : 0;
                    vm.userlocal.GY4 = vm.GraduationYears4 != null ? vm.GraduationYears4.Year : string.Empty;


                    vm.userlocal.Certifications = vm.Certifications != null ? JsonConvert.SerializeObject(vm.Certifications) : string.Empty;
                    vm.userlocal.Languajes = JsonConvert.SerializeObject(vm.Languajes);

                    await App.Database.UpdateUserAsync(vm.userlocal);
                    rotatorindex = rotator.SelectedIndex;
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (args.Index == 3)
            {
                if (!await vm.ValidaVideoAcademics())
                {
                    rotator.SetValue(CardsView.SelectedIndexProperty, indeView.OldIndex);
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
                else
                {
                    rotatorindex = rotator.SelectedIndex;
                    rotator.IsPanSwipeEnabled = true;
                    _isLocked = false;
                    return;
                }
            }
            else if (args.Index == 4)
            {
                vm.userlocal.Firm = vm.Firm;
                vm.userlocal.Firm1 = vm.Firm1;
                vm.userlocal.Firm2 = vm.Firm2;
                vm.userlocal.Firm3 = vm.Firm3;
                vm.userlocal.Firm4 = vm.Firm4;

                vm.userlocal.JobTitle = vm.JobTitle;
                vm.userlocal.JobTitle1 = vm.JobTitle1;
                vm.userlocal.JobTitle2 = vm.JobTitle2;
                vm.userlocal.JobTitle3 = vm.JobTitle3;
                vm.userlocal.JobTitle4 = vm.JobTitle4;

                vm.userlocal.Experience = JsonConvert.SerializeObject(vm.Experiences);
                vm.userlocal.Experience1 = JsonConvert.SerializeObject(vm.Experiences1);
                vm.userlocal.Experience2 = JsonConvert.SerializeObject(vm.Experiences2);
                vm.userlocal.Experience3 = JsonConvert.SerializeObject(vm.Experiences3);
                vm.userlocal.Experience4 = JsonConvert.SerializeObject(vm.Experiences4);

                vm.userlocal.Mifecha = vm.Mifecha;
                vm.userlocal.Mifecha1 = vm.Mifecha1;
                vm.userlocal.Mifecha2 = vm.Mifecha2;
                vm.userlocal.Mifecha3 = vm.Mifecha3;
                vm.userlocal.Mifecha4 = vm.Mifecha4;
                rotatorindex = rotator.SelectedIndex;
                await App.Database.UpdateUserAsync(vm.userlocal);
            }
            //else if (indeView.OldIndex != 0)
            //{
            //    rotatorindex = rotator.SelectedIndex;
            //    UserDialogs.Instance.ShowLoading();
            //    await Task.Delay(600);
            //    UserDialogs.Instance.HideLoading();
            //}

            rotator.IsPanSwipeEnabled = true;



            _isLocked = false;
        }
    }
}