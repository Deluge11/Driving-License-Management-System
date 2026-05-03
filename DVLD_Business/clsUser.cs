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
    public class clsUser
    {
        public int UserID { get; private set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson Person { get; }

        enum enMode { Add, Update }
        enMode Mode { get; set; }


        public clsUser()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            Mode = enMode.Add;
        }

        private clsUser(stUserInfo info)
        {
            this.PersonID = info.PersonID;
            this.UserID = info.UserID;
            this.UserName = info.UserName;
            this.Password = info.Password;
            this.IsActive = info.IsActive;
            this.Person = clsPerson.Get(PersonID);

            Mode = enMode.Update;
        }


        public static clsUser Get(int id)
        {
            if (clsDataUser.GetByUserId(id, out stUserInfo info))
            {
                return new clsUser(info);
            }
            return null;
        }

        public static clsUser Get(string username)
        {
            if (clsDataUser.GetByUserName(username, out stUserInfo info))
            {
                return new clsUser(info);
            }
            return null;
        }

        public static clsUser Get(string username, string password)
        {
            if (clsDataUser.GetByUsernameAndPassword(username, password, out stUserInfo info))
            {
                return new clsUser(info);
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
            return clsDataUser.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataUser.Add(GetInfo(), out int userID))
            {
                this.UserID = userID;
                return true;
            }
            return false;
        }

        public static bool Delete(int userID)
        {
            return clsDataUser.Delete(userID);
        }

        public static bool Exists(int userID)
        {
            return clsDataUser.Exists(userID);
        }

        public static DataTable GetAll()
        {
            return clsDataUser.GetAll();
        }

        private stUserInfo GetInfo()
        {
            stUserInfo info = new stUserInfo();

            info.PersonID = this.PersonID;
            info.UserName = this.UserName;
            info.Password = this.Password;
            info.UserID = this.UserID;
            info.IsActive = this.IsActive;

            return info;
        }
    }
}
