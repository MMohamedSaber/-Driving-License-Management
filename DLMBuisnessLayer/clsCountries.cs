using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLMDataAccessLayer;

namespace cc
{
    public  class clsCountries
    {

      public   int ID=-1;
       public string CountryName= "" ;
       public  clsCountries(int id,string countryname)
        {
            this.ID = id;
            this.CountryName = countryname;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

        public static clsCountries Find(string countryname)
        {
            int CountryID = -1;
             
            if(clsCountriesDataAccess.GetCountryInfoByName(ref CountryID,ref countryname))
            {
                return new clsCountries(CountryID, countryname);

            }
            else
            {
                return null;
            }



        }
        public static clsCountries Find(int CountryID)
        {
            string countryname = "";

            if (clsCountriesDataAccess.GetCountryInfoBybyID(ref CountryID, ref countryname))
            {
                return new clsCountries(CountryID, countryname);

            }
            else
            {
                return null;
            }



        }

    }
}
