using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
//using UIKit;
using Xamarin.Forms;

namespace JobMe.Models
{
    public class UserRegistry
    {
        [PrimaryKey]
        public int ID { get; set; }

        public int UserID { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int IDCountry { get; set; }

        public string Country { get; set; }

        public int IDCity { get; set; }
        public string City { get; set; }

        public int IDGender { get; set; }

        public string Gender { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string BusinessFields { get; set; }

        public string Areas { get; set; }
        public int IDSalary { get; set; }

        public string Salary { get; set; }

        public int TypeofJob  { get; set; }

        public int TravelAvailable { get; set; }
        public int ChangeResidence  { get; set; }

        public int IDSchool { get; set; }
        public string School { get; set; }
        public int IDSchool1 { get; set; }
        public string School1 { get; set; }
        public int IDSchool2 { get; set; }
        public string School2 { get; set; }
        public int IDSchool3 { get; set; }
        public string School3 { get; set; }
        public int IDSchool4 { get; set; }
        public string School4 { get; set; }

        public int IDDegre { get; set; }
        public string Degree { get; set; }

        public int IDDegre1 { get; set; }
        public string Degree1 { get; set; }

        public int IDDegre2 { get; set; }
        public string Degree2 { get; set; }

        public int IDDegre3 { get; set; }
        public string Degree3 { get; set; }

        public int IDDegre4 { get; set; }
        public string Degree4 { get; set; }

        public string Certifications { get; set; }
        public string Languajes { get; set; }

        public int IDGY { get; set; }
        public string GY  { get; set; }

        public int IDGY1 { get; set; }
        public string GY1 { get; set; }

        public int IDGY2 { get; set; }
        public string GY2 { get; set; }

        public int IDGY3 { get; set; }
        public string GY3 { get; set; }

        public int IDGY4 { get; set; }
        public string GY4 { get; set; }

        public string JobTitle { get; set; }
        public string JobTitle1 { get; set; }
        public string JobTitle2 { get; set; }
        public string JobTitle3 { get; set; }
        public string JobTitle4 { get; set; }

        public string Firm { get; set; }
        public string Firm1 { get; set; }
        public string Firm2 { get; set; }
        public string Firm3 { get; set; }
        public string Firm4 { get; set; }

        public string Experience { get; set; }
        public string Experience1 { get; set; }
        public string Experience2 { get; set; }
        public string Experience3 { get; set; }
        public string Experience4 { get; set; }

        public string Mifecha { get; set; }
        public string Mifecha1 { get; set; }
        public string Mifecha2 { get; set; }
        public string Mifecha3 { get; set; }
        public string Mifecha4 { get; set; }

    }
}
