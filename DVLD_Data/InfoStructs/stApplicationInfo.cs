using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.InfoStructs
{
    public struct stApplicationInfo
    {
        public int ApplicationID;
        public int ApplicantPersonID;
        public DateTime ApplicationDate;
        public DateTime LastStatusDate;
        public int ApplicationTypeID;
        public byte ApplicationStatus;
        public decimal PaidFees;
        public int CreatedByUserID;
    }
}
