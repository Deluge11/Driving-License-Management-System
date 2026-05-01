using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.InfoStructs
{
    public struct stLicenseClassInfo
    {
        public int LicenseClassID;
        public string ClassName;
        public string ClassDescription;
        public byte MinimumAllowedAge;
        public byte DefaultValidityLength;
        public decimal ClassFees;
    }
}
