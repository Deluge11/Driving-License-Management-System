using DVLD_Data;
using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; private set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public bool IsLocked { get; set; }
        public clsApplication ReTestApplication
        {
            get
            {
                return clsApplication.Get(RetakeTestApplicationID);
            }
        }

        public clsLocalLicenseApplication LocalDrivingLicenseApplication
        {
            get
            {
                return clsLocalLicenseApplication.GetByLocalId(LocalDrivingLicenseApplicationID);
            }
        }

        public clsTest Test
        {
            get
            {
                return clsTest.GetByTestAppointment(this.TestAppointmentID);
            }
        }
        enum enMode { Add, Update }
        enMode Mode { get; set; }


        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = 0;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.UtcNow;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;

            Mode = enMode.Add;
        }

        private clsTestAppointment(stTestAppointmentInfo info)
        {
            TestAppointmentID = info.TestAppointmentID;
            TestTypeID = (clsTestType.enTestType)info.TestTypeID;
            LocalDrivingLicenseApplicationID = info.LocalDrivingLicenseApplicationID;
            AppointmentDate = info.AppointmentDate;
            PaidFees = info.PaidFees;
            CreatedByUserID = info.CreatedByUserID;
            IsLocked = info.IsLocked;
            RetakeTestApplicationID = info.RetakeTestApplicationID;

            Mode = enMode.Update;
        }


        public static DataTable GetTestAppointments(int localApplicationId, clsTestType.enTestType TestType)
        {
            return clsDataTestAppointments.Get(localApplicationId, (int)TestType);
        }

        public static clsTestAppointment Get(int id)
        {
            if (clsDataTestAppointments.Get(id, out stTestAppointmentInfo info))
            {
                return new clsTestAppointment(info);
            }
            return null;
        }

        public bool Save()
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
            return clsDataTestAppointments.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataTestAppointments.Add(GetInfo(), out int testAppointmentId))
            {
                this.TestAppointmentID = testAppointmentId;
                return true;
            }
            return false;
        }


        //public static bool Exists(int personId)
        //{
        //    return clsDataPeople.Exists(personId);
        //}

        public static DataTable GetAll()
        {
            return clsDataTestAppointments.GetAll();
        }

        private stTestAppointmentInfo GetInfo()
        {
            stTestAppointmentInfo info = new stTestAppointmentInfo();

            info.TestAppointmentID = TestAppointmentID;
            info.TestTypeID = (int)TestTypeID;
            info.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            info.AppointmentDate = AppointmentDate;
            info.PaidFees = PaidFees;
            info.CreatedByUserID = CreatedByUserID;
            info.IsLocked = IsLocked;
            info.RetakeTestApplicationID = RetakeTestApplicationID;

            return info;
        }
    }
}
