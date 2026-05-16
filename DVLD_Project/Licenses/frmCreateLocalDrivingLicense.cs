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

            if (LocalDrivingLicenseApp == null)
            {
                this.Close();
                return;
            }

            if (LocalDrivingLicenseApp.ApplicationPersonInfo.IsDriver())
            {
                Driver = clsDriver.GetByPersonId(LocalDrivingLicenseApp.ApplicantPersonID);
            }
            else
            {
                Driver = new clsDriver();
                Driver.PersonID = LocalDrivingLicenseApp.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }

            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(localDrivingLicenseAppId);
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (!LocalDrivingLicenseApp.DoesPassAllTests())
            {
                MessageBox.Show("This Person Doesnt pass all tests");
                return;
            }

            if (!LocalDrivingLicenseApp.ApplicationPersonInfo.IsDriver() && !Driver.Save())
            {
                MessageBox.Show("Driver Not Created");
                return;
            }

            if (LocalDrivingLicenseApp.ApplicationStatus != clsApplication.enApplicationStatus.New)
            {
                MessageBox.Show("Local Driving License Application Is Closed");
                return;
            }

            clsLicense license = new clsLicense();
            license.ApplicationID = LocalDrivingLicenseApp.ApplicationID;
            license.IssueDate = DateTime.UtcNow;
            license.ExpirationDate = DateTime.UtcNow.AddYears(LicenseClass.DefaultValidityLength);
            license.PaidFees = LicenseClass.ClassFees;
            license.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            license.IsActive = true;
            license.Notes = "";
            license.LicenseClass = LicenseClass.LicenseClassID;
            license.DriverID = Driver.DriverID;

            if (license.Save())
            {
                MessageBox.Show("License Created Successfully");
                LocalDrivingLicenseApp.SetComplete();
            }
            else
            {
                MessageBox.Show("License Not Created");
            }

            this.Close();
        }
    }
}
