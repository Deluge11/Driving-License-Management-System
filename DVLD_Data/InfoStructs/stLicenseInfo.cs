using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.InfoStructs
{
    public struct stLicenseInfo
    {
        public int LicenseID;
        public int ApplicationID;
        public int DriverID;
        public int LicenseClass;
        public DateTime IssueDate;
        public DateTime ExpirationDate;
        public string Notes;
        public decimal PaidFees;
        public bool IsActive;
        public byte IssueReason;
        public int CreatedByUserID;
    }
}
