using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DVLD_Business
{
    public class clsPerson
    {
        public stPersonInfo Info { get; set; }
        enum enMode { Add, Update }
        enMode Mode { get; set; }


        public clsPerson()
        {

            Mode = enMode.Add;
        }

        private clsPerson(stPersonInfo info)
        {
            Info = info;
            Mode = enMode.Update;
        }


        public clsPerson GetById(int id)
        {
            if (clsDataPeople.GetPersonById(id, out stPersonInfo info))
            {
                return new clsPerson(info);
            }
            return null;
        }

    }
}
