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

namespace DVLD_Project.Licenses
{
    public partial class ucLocalDrivingLicenseDetails : UserControl
    {
        public ucLocalDrivingLicenseDetails()
        {
            InitializeComponent();
        }

        private void ucLocalDrivingLicenseDetails_Load(object sender, EventArgs e)
        {

        }

        public void LoadLicense(int licenseId)
        {
            clsLicense License = clsLicense.GetByLicenseId(licenseId);

            if (License == null)
            {
                lbl_ClassName.Text = "???";
                lbl_Dateofbrith.Text = "???";
                lbl_DriverID.Text = "???";
                lbl_ExpireDate.Text = "???";
                lbl_FullName.Text = "???";
                lbl_Gender.Text = "???";
                lbl_IsActive.Text = "???";
                lbl_IsDetained.Text = "???";
                lbl_IssuedDate.Text = "???";
                lbl_IssueReason.Text = "???";
                lbl_LicenseID.Text = "???";
                lbl_NationalNo.Text = "???";
            }
            else
            {
                clsPerson Person = clsPerson.Get(clsDriver.GetById(License.DriverID).PersonID);
                lbl_ClassName.Text = clsLicenseClass.Get(License.LicenseClass).ClassName;
                lbl_DriverID.Text = License.DriverID.ToString();
                lbl_Dateofbrith.Text = Person.DateOfBirth.ToShortDateString();
                lbl_IssuedDate.Text = License.IssueDate.ToShortDateString();
                lbl_ExpireDate.Text = License.ExpirationDate.ToShortDateString();
                lbl_FullName.Text = Person.FullName;
                lbl_Gender.Text = Person.Gender == 0 ? "Male" : "Female";
                lbl_NationalNo.Text = Person.NationalNo;
                lbl_IsActive.Text = License.IsActive ? "Yes" : "No";
                lbl_IsDetained.Text = License.IsDetained ? "Yes" : "No";
                lbl_IssueReason.Text = License.IssueReason.ToString();
                lbl_LicenseID.Text = License.LicenseID.ToString();
            }
        }

    }
}
