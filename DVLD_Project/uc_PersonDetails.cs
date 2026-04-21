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

namespace DVLD_Project
{
    public partial class uc_PersonDetails : UserControl
    {
        clsPerson Person;
        public uc_PersonDetails()
        {
            InitializeComponent();
        }

        private void uc_PersonDetails_Load(object sender, EventArgs e)
        {

        }

        public void LoadPerson(int personId)
        {
            Person = clsPerson.GetById(personId);
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

                if (Person.ImagePath != null && File.Exists(Person.ImagePath))
                {
                    using (FileStream fs = new FileStream(Person.ImagePath, FileMode.Open, FileAccess.Read))
                    {
                        pb_personimage.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pb_personimage.Image = Person.Gender == 1 ? imageList1.Images["Female.png"] : imageList1.Images["Male.png"];

                }
                pb_personimage.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void lbl_gender_Click(object sender, EventArgs e)
        {

        }
    }
}
