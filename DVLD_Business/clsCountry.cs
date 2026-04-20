using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {


        public int CountryID { get; set; }
        public string CountryName { get; set; }


        public clsCountry()
        {

        }

        public clsCountry(stCountryInfo info)
        {
            CountryID = info.CountryID;
            CountryName = info.CountryName;
        }

        public static DataTable GetAll()
        {
            return clsDataCountry.GetAll();
        }

        public static clsCountry Get(string countryName)
        {
            if (clsDataCountry.Get(countryName, out stCountryInfo info))
            {
                return new clsCountry(info);
            }

            return null;
        }

        public static clsCountry Get(int id)
        {
            if (clsDataCountry.Get(id, out stCountryInfo info))
            {
                return new clsCountry(info);
            }

            return null;
        }

    }
}
