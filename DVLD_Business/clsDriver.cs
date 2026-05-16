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
    public class clsDriver
    {
        enum enMode { Add, Update }
        enMode Mode { get; set; }

        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.UtcNow;

            Mode = enMode.Add;
        }

        private clsDriver(stDriverInfo info)
        {
            DriverID = info.DriverID;
            PersonID = info.PersonID;
            CreatedByUserID = info.CreatedByUserID;
            CreatedDate = info.CreatedDate;

            Mode = enMode.Update;
        }


        public static clsDriver GetById(int id)
        {
            if (clsDataDriver.GetById(id, out stDriverInfo info))
            {
                return new clsDriver(info);
            }
            return null;
        }

        public static clsDriver GetByPersonId(int id)
        {
            if (clsDataDriver.GetByPersonId(id, out stDriverInfo info))
            {
                return new clsDriver(info);
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
            return clsDataDriver.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataDriver.Add(GetInfo(), out int driverId))
            {
                this.DriverID = driverId;
                return true;
            }
            return false;
        }

        public static DataTable GetAll()
        {
            return clsDataDriver.GetAll();
        }

        private stDriverInfo GetInfo()
        {
            stDriverInfo info = new stDriverInfo();

            info.DriverID = this.DriverID;
            info.PersonID = this.PersonID;
            info.CreatedByUserID = this.CreatedByUserID;
            info.CreatedDate = this.CreatedDate;

            return info;
        }
    }
}
