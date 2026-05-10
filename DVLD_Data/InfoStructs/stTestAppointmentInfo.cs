using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.InfoStructs
{
    public struct stTestAppointmentInfo
    {
        public int TestAppointmentID;
        public int TestTypeID;
        public int LocalDrivingLicenseApplicationID;
        public DateTime AppointmentDate;
        public decimal PaidFees;
        public int CreatedByUserID;
        public bool IsLocked;
        public int RetakeTestApplicationID;
    }
}
