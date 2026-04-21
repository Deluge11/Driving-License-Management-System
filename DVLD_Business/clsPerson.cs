using DVLD_Data;
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
    public class clsPerson
    {
        public int PersonID { get; private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryId { get; set; }
        public string ImagePath { get; set; }

        enum enMode { Add, Update }
        enMode Mode { get; set; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryId = 0;
            this.ImagePath = null;

            Mode = enMode.Add;
        }

        private clsPerson(stPersonInfo info)
        {
            this.PersonID = info.PersonID;
            this.NationalNo = info.NationalNo;
            this.FirstName = info.FirstName;
            this.SecondName = info.SecondName;
            this.ThirdName = info.ThirdName;
            this.LastName = info.LastName;
            this.DateOfBirth = info.DateOfBirth;
            this.Gender = info.Gender;
            this.Address = info.Address;
            this.Phone = info.Phone;
            this.Email = info.Email;
            this.NationalityCountryId = info.NationalityCountryId;
            this.ImagePath = info.ImagePath;

            Mode = enMode.Update;
        }


        public static clsPerson GetById(int id)
        {
            if (clsDataPeople.GetById(id, out stPersonInfo info))
            {
                return new clsPerson(info);
            }
            return null;
        }

        public static clsPerson GetByNationalNo(string nationalNo)
        {
            if (clsDataPeople.GetByNationalNo(nationalNo, out stPersonInfo info))
            {
                return new clsPerson(info);
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
            return clsDataPeople.Update(GetInfo());
        }

        private bool Add()
        {
            if (clsDataPeople.Add(GetInfo(), out int personId))
            {
                this.PersonID = personId;
                return true;
            }
            return false;
        }

        public static bool Delete(int personId)
        {
            return clsDataPeople.Delete(personId);
        }

        public static bool Exists(int personId)
        {
            return clsDataPeople.Exists(personId);
        }

        public static bool Exists(string nationalNo)
        {
            return clsDataPeople.Exists(nationalNo);
        }
        public static DataTable GetAll()
        {
            return clsDataPeople.GetAll();
        }

        private stPersonInfo GetInfo()
        {
            stPersonInfo info = new stPersonInfo();

            info.PersonID = this.PersonID;
            info.NationalNo = this.NationalNo;
            info.FirstName = this.FirstName;
            info.SecondName = this.SecondName;
            info.ThirdName = this.ThirdName;
            info.LastName = this.LastName;
            info.DateOfBirth = this.DateOfBirth;
            info.Gender = this.Gender;
            info.Address = this.Address;
            info.Phone = this.Phone;
            info.Email = this.Email;
            info.NationalityCountryId = this.NationalityCountryId;
            info.ImagePath = this.ImagePath;

            return info;
        }
    }
}
