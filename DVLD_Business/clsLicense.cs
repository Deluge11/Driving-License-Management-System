using DVLD_Data;
using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode { Add, Update }
        public enum enIssueReason { New, ReNew, DamagedReplacement, LostReplacement }
        public enMode Mode { get; protected set; }
        public enIssueReason IssueReason { get; set; }

        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreateByUser
        {
            get
            {
                return clsUser.Get(CreatedByUserID);
            }
        }

        public clsDriver Driver
        {
            get
            {
                return clsDriver.GetById(DriverID);
            }
        }

        public clsApplication Application
        {
            get
            {
                return clsApplication.Get(ApplicationID);
            }
        }

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }

        public bool IsExpired
        {
            get
            {
                return DateTime.Now > ExpirationDate;
            }
        }

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
            IssueReason = (enIssueReason)info.IssueReason;
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

        public static DataTable GetByDriverId(int driverId)
        {
            return clsDataLicense.GetByDriverId(driverId);
        }

        public clsDetainedLicense Detain(int createByUser, decimal fees)
        {
            if (IsDetained)
            {
                return null;
            }

            clsDetainedLicense detainInfo = new clsDetainedLicense();

            detainInfo.DetainDate = DateTime.Now;
            detainInfo.CreatedByUserID = createByUser;
            detainInfo.LicenseID = this.LicenseID;
            detainInfo.CreatedByUserID = createByUser;
            detainInfo.FineFees = fees;

            if (!detainInfo.Save())
            {
                return null;
            }

            return detainInfo;
        }

        public bool Release(int createByUser)
        {
            clsDetainedLicense DetainInfo = clsDetainedLicense.GetByLicenseId(this.LicenseID);

            if (DetainInfo == null)
            {
                return false;
            }

            clsApplicationType appType = clsApplicationType.Get(clsApplicationType.ApplicationType.ReleaseDentainedLicense);
            clsApplication application = new clsApplication();

            application.PaidFees = appType.ApplicationFees;
            application.ApplicantPersonID = Driver.PersonID;
            application.ApplicationTypeID = appType.ApplicationTypeID;
            application.CreatedByUserID = createByUser;

            if (!application.Save())
            {
                return false;
            }

            DetainInfo.ReleaseDate = DateTime.Now;
            DetainInfo.ReleasedByUserID = createByUser;
            DetainInfo.ReleaseApplicationID = application.ApplicationID;
            DetainInfo.IsReleased = true;

            if (!DetainInfo.Save())
            {
                return false;
            }

            return true;
        }

        public clsLicense ReNewLicense(int createdByUser)
        {
            if (!IsExpired)
            {
                return null;
            }

            clsApplicationType appType = clsApplicationType.Get(clsApplicationType.ApplicationType.RenewLicense);
            clsApplication renewApp = new clsApplication();

            renewApp.ApplicantPersonID = this.Application.ApplicantPersonID;
            renewApp.ApplicationTypeID = appType.ApplicationTypeID;
            renewApp.PaidFees = appType.ApplicationFees;
            renewApp.CreatedByUserID = createdByUser;

            if (!renewApp.Save())
            {
                return null;
            }

            clsLicenseClass licenseClass = clsLicenseClass.Get(this.LicenseClass);
            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = renewApp.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClass = licenseClass.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
            newLicense.PaidFees = licenseClass.ClassFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = enIssueReason.ReNew;
            newLicense.CreatedByUserID = createdByUser;

            this.IsActive = false;

            if (!Save() || !newLicense.Save())
            {
                return null;
            }

            return newLicense;
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
            info.IssueReason = (byte)IssueReason;
            info.CreatedByUserID = CreatedByUserID;

            return info;
        }


    }
}
