using DVLD.Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmScheduledTest : Form
    {
        clsTestAppointment TestAppointment;
        public frmScheduledTest(int testAppointmentId)
        {
            InitializeComponent();

            TestAppointment = clsTestAppointment.Get(testAppointmentId);


            if (TestAppointment == null)
            {
                MessageBox.Show("Test appointment not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmScheduledTest_Load(object sender, EventArgs e)
        {
            lbl_LocalAppID.Text = TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbl_Class.Text = TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbl_Name.Text = TestAppointment.LocalDrivingLicenseApplication.ApplicationPersonInfo.FullName;
            lbl_TestDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lbl_TestFees.Text = TestAppointment.PaidFees.ToString();
            lbl_Trial.Text = TestAppointment.LocalDrivingLicenseApplication.GetTestTrails(TestAppointment.TestTypeID).ToString();
            lbl_TestID.Text = "Unknown";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!rbFail.Checked && !rbPass.Checked)
            {
                MessageBox.Show("Select test result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest test = new clsTest();

            test.TestAppointmentID = TestAppointment.TestAppointmentID;
            test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            test.TestResult = rbPass.Checked;

            if (test.Save())
            {
                TestAppointment.IsLocked = true;

                MessageBox.Show("Test Saved Successfully", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test Result Not Saved", "bad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TestAppointment.Save())
            {
                MessageBox.Show("Test appointment Locked Successfully", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test appointment Not Locked", "bad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
