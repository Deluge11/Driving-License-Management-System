using DVLD_Data;
using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public enum enMode { Add, Update }
        public enMode Mode { get; protected set; }

        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;

            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID =null;

            Mode = enMode.Add;
        }

        private clsDetainedLicense(stDetainedLicenseInfo info)
        {
            DetainID = info.DetainID;
            LicenseID = info.LicenseID;
            DetainDate = info.DetainDate;
            ReleaseDate = info.ReleaseDate;
            FineFees = info.FineFees;
            CreatedByUserID = info.CreatedByUserID;
            IsReleased = info.IsReleased;
            ReleasedByUserID = info.ReleasedByUserID;
            ReleaseApplicationID = info.ReleaseApplicationID;
            Mode = enMode.Update;
        }


        public static clsDetainedLicense GetByLicenseId(int licenseId)
        {
            if (clsDataDetainedLicense.GetByLicenseId(licenseId, out stDetainedLicenseInfo info))
            {
                return new clsDetainedLicense(info);
            }
            return null;
        }


        public virtual bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return Update();

                default:
                    return false;
            }
        }

        private bool Update()
        {
            return clsDataDetainedLicense.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataDetainedLicense.Add(GetInfo(), out int detainedId))
            {
                this.DetainID = detainedId;
                return true;
            }
            return false;
        }

        public static DataTable GetAll()
        {
            return clsDataLicense.GetAll();
        }

        public static bool IsLicenseDetained(int licenseId)
        {
            return clsDataDetainedLicense.IsLicenseDetained(licenseId);
        }


        private stDetainedLicenseInfo GetInfo()
        {
            stDetainedLicenseInfo info = new stDetainedLicenseInfo();
            info.DetainID = this.DetainID;
            info.LicenseID = this.LicenseID;
            info.DetainDate = this.DetainDate;
            info.ReleaseDate = this.ReleaseDate;
            info.FineFees = this.FineFees;
            info.CreatedByUserID = this.CreatedByUserID;
            info.IsReleased = this.IsReleased;
            info.ReleasedByUserID = this.ReleasedByUserID;
            info.ReleaseApplicationID = this.ReleaseApplicationID;

            return info;
        }


    }
}
