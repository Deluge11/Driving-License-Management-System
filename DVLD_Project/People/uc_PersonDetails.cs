using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using System.IO;
using DVLD_Project.Classes;
using DVLD_Project.Properties;

namespace DVLD_Project
{
    public partial class uc_PersonDetails : UserControl
    {
        public clsPerson Person;
        public uc_PersonDetails()
        {
            InitializeComponent();
        }

        private void uc_PersonDetails_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        public void LoadPerson(int personId)
        {
            Person = clsPerson.Get(personId);
            RefreshForm();
        }

        public void LoadPerson(string nationalNo)
        {
            Person = clsPerson.Get(nationalNo);
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (Person == null)
            {
                lbl_personId.Text = "???";
                lbl_name.Text = "???";
                lbl_nationalno.Text = "???";
                lbl_gender.Text = "???";
                lbl_phone.Text = "???";
                lbl_date.Text = "???";
                lbl_email.Text = "???";
                lbl_country.Text = "???";
                lbl_address.Text = "???";

                pb_personimage.Image = imageList1.Images["Male.png"];

            }
            else
            {
                lbl_personId.Text = Person.PersonID.ToString();
                lbl_name.Text = Person.FirstName + ' ' + Person.LastName;
                lbl_nationalno.Text = Person.NationalNo;
                lbl_gender.Text = Person.Gender == 0 ? "Male" : "Female";
                lbl_phone.Text = Person.Phone;
                lbl_date.Text = Person.DateOfBirth.ToShortDateString();
                lbl_email.Text = Person.Email;
                lbl_country.Text = clsCountry.Get(Person.NationalityCountryId).CountryName;
                lbl_address.Text = Person.Address;

                pb_personimage.Image = Person.Gender == 0 ? Resources.Male_512 : Resources.Female_512;

                if (Person.ImagePath != null && File.Exists(clsUtil.GetImageFullPath(Person.ImagePath)))
                {
                    pb_personimage.ImageLocation = clsUtil.GetImageFullPath(Person.ImagePath);
                }
            }
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void lbl_gender_Click(object sender, EventArgs e)
        {

        }

        private void ll_EditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Person != null)
            {
                AddUpdatePerson form = new AddUpdatePerson(Person.PersonID);
                form.ShowDialog();
                RefreshForm();
            }
            else
            {
                // Message Box
            }

        }

        private void pb_personimage_Click(object sender, EventArgs e)
        {

        }
    }
}
