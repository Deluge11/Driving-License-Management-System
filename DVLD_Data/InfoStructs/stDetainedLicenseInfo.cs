using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.InfoStructs
{
    public struct stDetainedLicenseInfo
    {
        public int DetainID;
        public int LicenseID;
        public DateTime DetainDate;
        public decimal FineFees;
        public int CreatedByUserID;
        public bool IsReleased;
        public DateTime? ReleaseDate;
        public int? ReleasedByUserID;
        public int? ReleaseApplicationID;
    }
}
