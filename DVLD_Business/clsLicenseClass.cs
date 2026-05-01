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
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        private clsLicenseClass(stLicenseClassInfo info)
        {
            this.LicenseClassID = info.LicenseClassID;
            this.ClassName = info.ClassName;
            this.ClassDescription = info.ClassDescription;
            this.MinimumAllowedAge = info.MinimumAllowedAge;
            this.DefaultValidityLength = info.DefaultValidityLength;
            this.ClassFees = info.ClassFees;
        }

        public static clsLicenseClass Get(int id)
        {
            if (clsDataLicenseClass.Get(id, out stLicenseClassInfo info))
            {
                return new clsLicenseClass(info);
            }
            return null;
        }

        public static clsLicenseClass Get(string name)
        {
            if (clsDataLicenseClass.Get(name, out stLicenseClassInfo info))
            {
                return new clsLicenseClass(info);
            }
            return null;
        }

        public bool Save()
        {
            return Update();
        }

        private bool Update()
        {
            return clsDataLicenseClass.Update(GetInfo());
        }

        public static DataTable GetAll()
        {
            return clsDataLicenseClass.GetAll();
        }

        private stLicenseClassInfo GetInfo()
        {
            stLicenseClassInfo info = new stLicenseClassInfo();
            info.LicenseClassID = this.LicenseClassID;
            info.ClassName = this.ClassName;
            info.ClassDescription = this.ClassDescription;
            info.MinimumAllowedAge = this.MinimumAllowedAge;
            info.DefaultValidityLength = this.DefaultValidityLength;
            info.ClassFees = this.ClassFees;
            return info;
        }
    }
}
