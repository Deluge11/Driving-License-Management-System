using DVLD_Data.InfoStructs;
using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; private set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        private clsApplicationType(stApplicationTypeInfo info)
        {
            this.ApplicationTypeID = info.ApplicationTypeID;
            this.ApplicationTypeTitle = info.ApplicationTypeTitle;
            this.ApplicationFees = info.ApplicationFees;
        }


        public static clsApplicationType Get(int id)
        {
            if (clsDataApplicationType.Get(id, out stApplicationTypeInfo info))
            {
                return new clsApplicationType(info);
            }
            return null;
        }

        public bool Save()
        {
            return Update();
        }

        private bool Update()
        {
            return clsDataApplicationType.Update(GetInfo());
        }

        public static DataTable GetAll()
        {
            return clsDataApplicationType.GetAll();
        }

        private stApplicationTypeInfo GetInfo()
        {
            stApplicationTypeInfo info = new stApplicationTypeInfo();
            info.ApplicationTypeID = this.ApplicationTypeID;
            info.ApplicationTypeTitle = this.ApplicationTypeTitle;
            info.ApplicationFees = this.ApplicationFees;
            return info;
        }
    }
}
