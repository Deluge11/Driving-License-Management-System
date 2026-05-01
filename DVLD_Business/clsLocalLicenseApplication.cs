using DVLD_Data.InfoStructs;
using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalLicenseApplication : clsApplication
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }

        enum enMode { Add, Update }
        enMode Mode;

        public clsLocalLicenseApplication() : base()
        {

            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1; ;

            ApplicationTypeID = (int)clsApplicationType.ApplicationType.LocalLicense;
            Mode = enMode.Add;
        }

        private clsLocalLicenseApplication(stLocalLicenseApplicationInfo info)
        {
            clsApplication application = clsApplication.Get(info.ApplicationID);

            LocalDrivingLicenseApplicationID = info.LocalDrivingLicenseApplicationID;
            LicenseClassID = info.LicenseClassID;

            ApplicationID = application.ApplicationID;
            ApplicantPersonID = application.ApplicantPersonID;
            ApplicationDate = application.ApplicationDate;
            LastStatusDate = application.LastStatusDate;
            ApplicationTypeID = application.ApplicationTypeID;
            ApplicationStatus = application.ApplicationStatus;
            PaidFees = application.PaidFees;
            CreatedByUserID = application.CreatedByUserID;
            Mode = enMode.Update;

        }


        public static clsLocalLicenseApplication GetLocalLicenseApplication(int id)
        {
            if (clsDataLocalLicenseApplication.Get(id, out stLocalLicenseApplicationInfo info))
            {
                return new clsLocalLicenseApplication(info);
            }
            return null;
        }

        public override bool Save()
        {
            if (!base.Save())
            {
                return false;
            }

            switch (this.Mode)
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
            return clsDataLocalLicenseApplication.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataLocalLicenseApplication.Add(GetInfo(), out int applicationID))
            {
                this.LocalDrivingLicenseApplicationID = applicationID;
                return true;
            }
            return false;
        }

        public bool ExistsWithLicense()
        {
            return clsDataLocalLicenseApplication.ExistsWithLicense(ApplicantPersonID, LicenseClassID);
        }

        //public static bool Delete(int userID)
        //{
        //    return clsDataApplication.Delete(userID);
        //}

        //public static bool Exists(int userID)
        //{
        //    return clsDataApplication.Exists(userID);
        //}

        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsDataLocalLicenseApplication.GetAll();
        }

        private stLocalLicenseApplicationInfo GetInfo()
        {
            stLocalLicenseApplicationInfo info = new stLocalLicenseApplicationInfo();

            info.LocalDrivingLicenseApplicationID = this.LocalDrivingLicenseApplicationID;
            info.ApplicationID = this.ApplicationID;
            info.LicenseClassID = this.LicenseClassID;

            return info;
        }


    }
}
