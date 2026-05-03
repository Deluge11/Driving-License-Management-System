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
        enum enLocalMode { Add, Update }
        enLocalMode LocalMode;

        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClass
        {
            get
            {
                return clsLicenseClass.Get(LicenseClassID);
            }
        }


        public clsLocalLicenseApplication() : base()
        {

            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1; ;

            ApplicationTypeID = (int)clsApplicationType.ApplicationType.LocalLicense;
            LocalMode = enLocalMode.Add;
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


        public static clsLocalLicenseApplication GetByLocalId(int id)
        {
            if (clsDataLocalLicenseApplication.GetByLocalId(id, out stLocalLicenseApplicationInfo info))
            {
                return new clsLocalLicenseApplication(info);
            }
            return null;
        }

        public static clsLocalLicenseApplication GetByGeneralId(int id)
        {
            if (clsDataLocalLicenseApplication.GetByGeneralId(id, out stLocalLicenseApplicationInfo info))
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

            switch (LocalMode)
            {
                case enLocalMode.Add:
                    if (Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enLocalMode.Update:
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

        public bool IsPersonApplyOnThisLicense()
        {
            return clsDataLocalLicenseApplication.IsPersonApplyOnThisLicense(ApplicantPersonID, LicenseClassID);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int localApplicationID)
        {
            return clsDataLocalLicenseApplication.Delete(localApplicationID);
        }


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
