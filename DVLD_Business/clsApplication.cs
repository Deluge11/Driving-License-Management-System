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
    public class clsApplication
    {
        public int ApplicationID { get; protected set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        public enum enMode { Add, Update }
        public enMode Mode { get; protected set; }


        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            this.ApplicationDate = DateTime.UtcNow;
            this.LastStatusDate = DateTime.UtcNow;
            this.ApplicationStatus = enApplicationStatus.New;

            Mode = enMode.Add;
        }

        private clsApplication(stApplicationInfo info)
        {
            this.ApplicationID = info.ApplicationID;
            this.ApplicantPersonID = info.ApplicantPersonID;
            this.ApplicationDate = info.ApplicationDate;
            this.LastStatusDate = info.LastStatusDate;
            this.ApplicationTypeID = info.ApplicationTypeID;
            this.ApplicationStatus = (enApplicationStatus)info.ApplicationStatus;
            this.PaidFees = info.PaidFees;
            this.CreatedByUserID = info.CreatedByUserID;

            Mode = enMode.Update;
        }


        public static clsApplication Get(int id)
        {
            if (clsDataApplication.GetById(id, out stApplicationInfo info))
            {
                return new clsApplication(info);
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
            return clsDataApplication.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataApplication.Add(GetInfo(), out int applicationID))
            {
                this.ApplicationID = applicationID;
                return true;
            }
            return false;
        }

        public bool Cancel()
        {
            if (this.ApplicationStatus != enApplicationStatus.New)
            {
                return false;
            }

            this.ApplicationStatus = enApplicationStatus.Cancelled;
            return this.Save();
        }

        public static bool Delete(int userID)
        {
            return clsDataApplication.Delete(userID);
        }

        public static bool Exists(int userID)
        {
            return clsDataApplication.Exists(userID);
        }

        public static DataTable GetAll()
        {
            return clsDataApplication.GetAll();
        }

        private stApplicationInfo GetInfo()
        {
            stApplicationInfo info = new stApplicationInfo();

            info.ApplicationID = this.ApplicationID;
            info.ApplicantPersonID = this.ApplicantPersonID;
            info.ApplicationDate = this.ApplicationDate;
            info.LastStatusDate = this.LastStatusDate;
            info.ApplicationTypeID = this.ApplicationTypeID;
            info.ApplicationStatus = (byte)this.ApplicationStatus;
            info.PaidFees = this.PaidFees;
            info.CreatedByUserID = this.CreatedByUserID;

            return info;
        }
    }
}
