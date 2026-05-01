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
    public class clsTestType
    {
        public enum enTestType { Vision, Written, Street }
        public enTestType TestTypeID { get; private set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        private clsTestType(stTestTypeInfo info)
        {
            this.TestTypeID = (enTestType)info.TestTypeID;
            this.TestTypeTitle = info.TestTypeTitle;
            this.TestTypeDescription = info.TestTypeDescription;
            this.TestTypeFees = info.TestTypeFees;
        }


        public static clsTestType Get(enTestType testTypeId)
        {
            if (clsDataTestType.Get((int)testTypeId, out stTestTypeInfo info))
            {
                return new clsTestType(info);
            }
            return null;
        }

        public bool Save()
        {
            return Update();
        }

        private bool Update()
        {
            return clsDataTestType.Update(GetInfo());
        }

        public static DataTable GetAll()
        {
            return clsDataTestType.GetAll();
        }

        private stTestTypeInfo GetInfo()
        {
            stTestTypeInfo info = new stTestTypeInfo();
            info.TestTypeID = (int)this.TestTypeID;
            info.TestTypeTitle = this.TestTypeTitle;
            info.TestTypeDescription = this.TestTypeDescription;
            info.TestTypeFees = this.TestTypeFees;
            return info;
        }
    }
}
