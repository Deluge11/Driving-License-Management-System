using DVLD.Classes;
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
    public partial class frmCreateLocalDrivingLicense : Form
    {
        clsLocalLicenseApplication LocalDrivingLicenseApp;
        clsLicenseClass LicenseClass;
        clsDriver Driver;

        public frmCreateLocalDrivingLicense(int localDrivingLicenseAppId)
        {
            InitializeComponent();
            LocalDrivingLicenseApp = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseAppId);
            LicenseClass = clsLicenseClass.Get(LocalDrivingLicenseApp.LicenseClassID);
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (!LocalDrivingLicenseApp.DoesPassAllTests())
            {
                MessageBox.Show("This Person Doesnt pass all tests");
                return;
            }

            int licenseId = LocalDrivingLicenseApp.IssueLicenseForFirstTime(clsGlobal.CurrentUser.UserID);
            if (licenseId != -1)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show("Failed");
            }


            this.Close();
        }

        private void frmCreateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            if (LocalDrivingLicenseApp == null)
            {
                this.Close();
                MessageBox.Show("License Not Exists");
                return;
            }

            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(LocalDrivingLicenseApp.ApplicationID);


        }
    }
}
