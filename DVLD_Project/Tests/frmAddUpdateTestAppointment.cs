using DVLD.Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static DVLD_Business.clsApplicationType;

namespace DVLD_Project.Applications
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        clsTestAppointment TestAppointment;
        public frmAddUpdateTestAppointment(clsTestType.enTestType TestType, int localDrivingLicenseId)
        {
            InitializeComponent();

            TestAppointment = new clsTestAppointment();
            TestAppointment.TestTypeID = TestType;
            TestAppointment.LocalDrivingLicenseApplicationID = localDrivingLicenseId;
            TestAppointment.PaidFees = clsTestType.Get(TestType).TestTypeFees;
            TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            TestAppointment.IsLocked = false;

            clsLocalLicenseApplication Application = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseId);

            if (Application == null)
            {
                MessageBox.Show("Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (Application.GetTestTrails(TestAppointment.TestTypeID) > 0)
            {
                clsApplication reTestApp = new clsApplication();
                reTestApp.ApplicationTypeID = ApplicationType.RetakeTest;
                reTestApp.ApplicantPersonID = Application.ApplicantPersonID;
                reTestApp.PaidFees = clsApplicationType.Get(ApplicationType.RetakeTest).ApplicationFees;
                reTestApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!reTestApp.Save())
                {
                    MessageBox.Show("ReTest Application Create Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                TestAppointment.RetakeTestApplicationID = reTestApp.ApplicationID;
            }

        }

        public frmAddUpdateTestAppointment(int testAppointmentId)
        {
            InitializeComponent();

            TestAppointment = clsTestAppointment.Get(testAppointmentId);

            if (TestAppointment == null)
            {
                MessageBox.Show("Test appointment not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void frmAddUpdateTestAppointment_Load(object sender, EventArgs e)
        {
            dtpAppDate.MinDate = DateTime.UtcNow;

            clsLocalLicenseApplication Application = TestAppointment.LocalDrivingLicenseApplication;
            lbl_LocalAppID.Text = Application.LocalDrivingLicenseApplicationID.ToString();
            lbl_Class.Text = Application.LicenseClass.ClassName;
            lbl_Name.Text = Application.ApplicationPersonInfo.FirstName;
            lbl_Trial.Text = Application.GetTestTrails(TestAppointment.TestTypeID).ToString();
            lbl_AppFees.Text = TestAppointment.PaidFees.ToString();

            if (TestAppointment.RetTestApplication != null)
            {
                lbl_ReAppId.Text = TestAppointment.RetakeTestApplicationID.ToString();
                lbl_RAppFees.Text = TestAppointment.RetTestApplication.PaidFees.ToString();
                lbl_TotalFees.Text = (TestAppointment.PaidFees + TestAppointment.RetTestApplication.PaidFees).ToString();
                gb_ReTest.Enabled = true;
            }
            else
            {
                gb_ReTest.Enabled = false;
            }

            if (TestAppointment.IsLocked)
            {
                btn_Save.Enabled = false;
                dtpAppDate.Enabled = false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TestAppointment.AppointmentDate = dtpAppDate.Value;

            if (TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment Saved Successfully", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test Appointment Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
