using System;
using System.Data;
using ClinicManagement_DataAccess;

namespace ClinicManagement_Business
{
    public class clsCountry
    {
        public byte CountryID { set; get; }
        public string CountryName { set; get; }

        private clsCountry(byte CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static clsCountry Find(byte CountryID)
        {
            string CountryName = "";

            bool IsFound = clsCountryData.GetCountryByID(CountryID, ref CountryName);

            if(IsFound)
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }
        public static clsCountry Find(string CountryName)
        {
            byte CountryID = 0;

            bool IsFound = clsCountryData.GetCountryByCountryName(ref CountryID, CountryName);

            if (IsFound)
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }
        public static DataTable GetCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
