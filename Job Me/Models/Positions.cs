using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace JobMe.Models
{
    public class ListaPositions
    {
        public int IDPosition { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string PostedBy { get; set; }
    }

    public class Positions
    {
        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private byte[] _Logo;

        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        public ImageSource Logo2 { get; set; }
        public int TypeofJob { get; set; }

        private int _IDPosition;

        public int IDPosition
        {
            get { return _IDPosition; }
            set { _IDPosition = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private object _School;

        public object School
        {
            get { return _School; }
            set { _School = value; }
        }

        public object Degree { get; set; }

        private Generos _Gender;

        public Salarios Salary { get; set; }
        public Paises Country { get; set; }

        public Generos Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public Ciudades City { get; set; }

        private bool _ChangeResidence;

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public bool ChangeResidence
        {
            get { return _ChangeResidence; }
            set { _ChangeResidence = value; }
        }

        private bool _TravelAvailable;

        public int IDCompany { get; set; }

        public bool TravelAvailable
        {
            get { return _TravelAvailable; }
            set { _TravelAvailable = value; }
        }

        public int IDCity { get; set; }

        private object _GraduationYear;

        public object GraduationYear
        {
            get { return _GraduationYear; }
            set { _GraduationYear = value; }
        }

        private object _MisAreas;

        public object MisAreas
        {
            get { return _MisAreas; }
            set { _MisAreas = value; }
        }

        private object _EmpBSFields;

        public object BSFields
        {
            get { return _EmpBSFields; }
            set { _EmpBSFields = value; }
        }

        private object _Experience;

        public object Experience
        {
            get { return _Experience; }
            set { _Experience = value; }
        }

        private object _Languaje;

        public object Languajes
        {
            get { return _Languaje; }
            set { _Languaje = value; }
        }

        private object _Certifications;

        public object Certifications
        {
            get { return _Certifications; }
            set { _Certifications = value; }
        }

        private string _Company;

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
    }
}