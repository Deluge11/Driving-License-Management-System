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
    public class clsLicense
    {
        public enum enMode { Add, Update }
        public enMode Mode { get; protected set; }

        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = DateTime.UtcNow;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;


            Mode = enMode.Add;
        }

        private clsLicense(stLicenseInfo info)
        {
            LicenseID = info.LicenseID;
            ApplicationID = info.ApplicationID;
            DriverID = info.DriverID;
            LicenseClass = info.LicenseClass;
            IssueDate = info.IssueDate;
            ExpirationDate = info.ExpirationDate;
            Notes = info.Notes;
            PaidFees = info.PaidFees;
            IsActive = info.IsActive;
            IssueReason = info.IssueReason;
            CreatedByUserID = info.CreatedByUserID;

            Mode = enMode.Update;
        }


        public static clsLicense GetByLicenseId(int id)
        {
            if (clsDataLicense.GetByLicenseId(id, out stLicenseInfo info))
            {
                return new clsLicense(info);
            }
            return null;
        }

        public static clsLicense GetByApplicationId(int id)
        {
            if (clsDataLicense.GetByApplicationId(id, out stLicenseInfo info))
            {
                return new clsLicense(info);
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
            return clsDataLicense.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataLicense.Add(GetInfo(), out int licenseId))
            {
                this.LicenseID = licenseId;
                return true;
            }
            return false;
        }

        public static DataTable GetAll()
        {
            return clsDataLicense.GetAll();
        }

        public static DataTable GetAll(int driverId)
        {
            return clsDataLicense.GetAll(driverId);
        }

        private stLicenseInfo GetInfo()
        {
            stLicenseInfo info = new stLicenseInfo();

            info.LicenseID = LicenseID;
            info.ApplicationID = ApplicationID;
            info.DriverID = DriverID;
            info.LicenseClass = LicenseClass;
            info.IssueDate = IssueDate;
            info.ExpirationDate = ExpirationDate;
            info.Notes = Notes;
            info.PaidFees = PaidFees;
            info.IsActive = IsActive;
            info.IssueReason = IssueReason;
            info.CreatedByUserID = CreatedByUserID;

            return info;
        }














        /*
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }
        */
    }
}
