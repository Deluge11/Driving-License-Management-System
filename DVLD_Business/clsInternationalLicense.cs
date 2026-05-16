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
    public class clsInternationalLicense : clsLicense
    {
        public enum enLocalMode { Add, Update }
        public enLocalMode LocalMode { get; protected set; }

        public int InternationalLicenseID { get; private set; }
        public int IssuedUsingLocalLicenseID { get; set; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = DateTime.UtcNow;
            IsActive = true;
            CreatedByUserID = 0;

            LocalMode = enLocalMode.Add;
        }

        private clsInternationalLicense(stInternationalLicense info)
        {
            InternationalLicenseID = info.InternationalLicenseID;
            ApplicationID = info.ApplicationID;
            DriverID = info.DriverID;
            IssuedUsingLocalLicenseID = info.IssuedUsingLocalLicenseID;
            IssueDate = info.IssueDate;
            ExpirationDate = info.ExpirationDate;
            IsActive = info.IsActive;
            CreatedByUserID = info.CreatedByUserID;

            LocalMode = enLocalMode.Update;
        }


        //public virtual bool Save()
        //{
        //    switch (Mode)
        //    {
        //        case enMode.Add:
        //            if (Add())
        //            {
        //                Mode = enMode.Update;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        case enMode.Update:
        //            return Update();

        //        default:
        //            return false;
        //    }
        //}

        //private bool Update()
        //{
        //    return clsDataLicense.Update(GetInfo());
        //}

        //private bool Add()
        //{
        //    if (clsDataLicense.Add(GetInfo(), out int licenseId))
        //    {
        //        this.LicenseID = licenseId;
        //        return true;
        //    }
        //    return false;
        //}

        public static DataTable GetAllInternationalLicenses()
        {
            return clsDataInternationalLicense.GetAll();
        }

        public static DataTable GetAllInternationalLicenses(int driverId)
        {
            return clsDataInternationalLicense.GetAll(driverId);
        }

        private stInternationalLicense GetInfo()
        {
            stInternationalLicense info = new stInternationalLicense();

           info.InternationalLicenseID = InternationalLicenseID;
           info.ApplicationID = ApplicationID;
           info.DriverID = DriverID;
           info.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
           info.IssueDate = IssueDate;
           info.ExpirationDate = ExpirationDate;
           info.IsActive = IsActive;
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
