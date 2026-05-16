using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses
{
    public partial class frmLocalDrivingLicenseDetails : Form
    {
        int LicenseId;

        public frmLocalDrivingLicenseDetails(int localApplicationLicense)
        {
            InitializeComponent();
            LicenseId = clsLicense.GetByApplicationId(clsLocalLicenseApplication.GetByLocalId(localApplicationLicense).ApplicationID).LicenseID;
        }

        private void ucLocalDrivingLicenseDetails1_Load(object sender, EventArgs e)
        {

        }

        private void frmLocalDrivingLicenseDetails_Load(object sender, EventArgs e)
        {
            ucLocalDrivingLicenseDetails1.LoadLicense(LicenseId);
        }

    }
}
