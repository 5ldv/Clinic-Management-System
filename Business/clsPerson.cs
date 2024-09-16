using System;
using System.Data;
using ClinicManagement_DataAccess;

namespace ClinicManagement_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string NationalIdentificationNumber { set; get; }
        public DateTime BirthDate { set; get; }
        public bool Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public byte CountryID { set; get; }
        public string GetFullName
        {
            get
            {
                string FullName = "";

                FullName += FirstName + " ";
                FullName += SecondName + " ";

                if (ThirdName != "")
                    FullName += ThirdName + " ";

                FullName += LastName + " ";

                return FullName;
            }
        }
        public string GetTextGender
        {
            get
            {
                return Gender == false ? "Male" : "Female";
            }
        }
        public string GetCountryName
        {
            get
            {
                return clsCountry.Find(CountryID).CountryName;
            }
        }
        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalIdentificationNumber = "";
            this.BirthDate = DateTime.MinValue;
            this.Gender = false;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryID = 0;
            Mode = enMode.AddNew;
        }
        private clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalIdentificationNumber, DateTime BirthDate, bool Gender, string Address, string Phone, string Email, byte CountryID)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalIdentificationNumber = NationalIdentificationNumber;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            Mode = enMode.Update;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = (int)clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalIdentificationNumber, this.BirthDate, this.Gender, this.Address, this.Phone, this.Email, this.CountryID);
            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalIdentificationNumber, this.BirthDate, this.Gender, this.Address, this.Phone, this.Email, this.CountryID);
        }
        public bool Delete()
        {
            return clsPersonData.DeletePerson(this.PersonID);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public static bool DoesPersonExist(int PersonID)
        {
            return clsPersonData.DoesPersonExist(PersonID);
        }
        public static clsPerson Find(int PersonID)
        {
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string NationalIdentificationNumber = "";
            DateTime BirthDate = DateTime.MinValue;
            bool Gender = false;
            string Address = "";
            string Phone = "";
            string Email = "";
            byte CountryID = 0;

            bool IsFound = clsPersonData.GetPersonByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalIdentificationNumber, ref BirthDate, ref Gender, ref Address, ref Phone, ref Email, ref CountryID);

            if (IsFound)
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalIdentificationNumber, BirthDate, Gender, Address, Phone, Email, CountryID);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static DataTable GetPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }
}
