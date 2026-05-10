using DVLD_Data;
using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public int CreatedByUserID { get; set; }
        public string Notes { get; set; }


        enum enMode { Add, Update }
        enMode Mode { get; set; }


        public clsTest()
        {
            TestID = 0;
            TestAppointmentID = 0;
            TestResult = false;
            CreatedByUserID = 0;
            Notes = "";

            Mode = enMode.Add;
        }

        private clsTest(stTestInfo info)
        {
            TestID = info.TestID;
            TestAppointmentID = info.TestAppointmentID;
            TestResult = info.TestResult;
            CreatedByUserID = info.CreatedByUserID;
            Notes = info.Notes;

            Mode = enMode.Update;
        }

        public static clsTest Get(int id)
        {
            if (clsDataTest.Get(id, out stTestInfo info))
            {
                return new clsTest(info);
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
            return clsDataTest.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataTest.Add(GetInfo(), out int testId))
            {
                this.TestID = testId;
                return true;
            }
            return false;
        }


        private stTestInfo GetInfo()
        {
            stTestInfo info = new stTestInfo();

            info.TestID = TestID;
            info.TestAppointmentID = TestAppointmentID;
            info.TestResult = TestResult;
            info.CreatedByUserID = CreatedByUserID;
            info.Notes = Notes;

            return info;
        }

    }
}
