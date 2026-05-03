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

namespace DVLD_Project.Applications.Controls
{
    public partial class ucLocalDrivingApplicationDetails : UserControl
    {
        clsLocalLicenseApplication application;
        public int LocalDrivingLicenseApplicationId
        {
            get
            {
                return application == null ? -1 : application.LocalDrivingLicenseApplicationID;
            }
        }

        public ucLocalDrivingApplicationDetails()
        {
            InitializeComponent();
        }

        private void ucApplicationDetails_Load(object sender, EventArgs e)
        {
        }

        private void SetDefaultValues()
        {
            lbl_ApplicationID.Text = "???";
            lbl_LicenseName.Text = "???";
            lbl_PassedTests.Text = "???";
            ucGeneralApplicationDetails.LoadApplication(-1);
        }

        public void LoadApplicationByLocalApplicationId(int applicationId)
        {
            application = clsLocalLicenseApplication.GetByLocalId(applicationId);
            LoadData();
        }

        public void LoadApplicationByGeneralApplicationId(int applicationId)
        {
            application = clsLocalLicenseApplication.GetByGeneralId(applicationId);
            LoadData();
        }


        private void LoadData()
        {
            if (application == null)
            {
                SetDefaultValues();
                MessageBox.Show("This Application Does not exists", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
            else
            {
                lbl_ApplicationID.Text = application.LocalDrivingLicenseApplicationID.ToString();
                lbl_LicenseName.Text = application.LicenseClass.ClassName;
                lbl_PassedTests.Text = "0/3";
                ucGeneralApplicationDetails.LoadApplication(application.ApplicationID);
            }

        }
    }
}
