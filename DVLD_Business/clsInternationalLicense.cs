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
        public static int ExpiryYears = 5;

        public enum enLocalMode { Add, Update }
        public enLocalMode LocalMode { get; protected set; }

        public int InternationalLicenseID { get; private set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense License
        {
            get
            {
                return clsLicense.GetByLicenseId(IssuedUsingLocalLicenseID);
            }
        }
        //public int DriverID { set; get; }
        //public DateTime IssueDate { set; get; }
        //public DateTime ExpirationDate { set; get; }
        //public bool IsActive { set; get; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = DateTime.UtcNow.AddYears(ExpiryYears);
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


        public override bool Save()
        {
            if (!base.Save())
            {
                return false;
            }

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
            return clsDataInternationalLicense.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataInternationalLicense.Add(GetInfo(), out int licenseId))
            {
                this.InternationalLicenseID = licenseId;
                return true;
            }
            return false;
        }

        public static clsInternationalLicense GetByInternationalLicenseId(int licenseId)
        {
            if (clsDataInternationalLicense.GetByInternationalLicenseId(licenseId, out stInternationalLicense info))
            {
                return new clsInternationalLicense(info);
            }
            return null;
        }

        public static clsInternationalLicense GetByLocalLicenseId(int licenseId)
        {
            if (clsDataInternationalLicense.GetByLocalLicenseId(licenseId, out stInternationalLicense info))
            {
                return new clsInternationalLicense(info);
            }
            return null;
        }

        public static bool IsDriverHaveInternationalLicense(int driverId)
        {
            return clsDataInternationalLicense.IsDriverHaveInternationalLicense(driverId);
        }

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
