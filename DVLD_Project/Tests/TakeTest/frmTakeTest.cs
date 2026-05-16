using DVLD.Classes;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Tests
{
    public partial class frmTakeTest : Form
    {
        clsTestAppointment TestAppointment;
        clsTest Test;

        public frmTakeTest(int testAppointmentId)
        {
            InitializeComponent();

            TestAppointment = clsTestAppointment.Get(testAppointmentId);
        }

        private void frmScheduledTest_Load(object sender, EventArgs e)
        {
            if (TestAppointment == null)
            {
                MessageBox.Show("Test appointment not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            Test = TestAppointment.Test;

            if (Test == null)
            {
                Test = new clsTest();
                Test.TestAppointmentID = TestAppointment.TestAppointmentID;
                Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }
            else
            {
                btn_Save.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            lbl_LocalAppID.Text = TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbl_Class.Text = TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbl_Name.Text = TestAppointment.LocalDrivingLicenseApplication.ApplicationPersonInfo.FullName;
            lbl_TestDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lbl_TestFees.Text = TestAppointment.PaidFees.ToString();
            lbl_Trial.Text = TestAppointment.LocalDrivingLicenseApplication.GetTestTrails(TestAppointment.TestTypeID).ToString();
            lbl_TestID.Text = Test.TestID == -1 ? "Unknown" : Test.TestID.ToString();
            if (Test.TestResult)
            {
                rbPass.Checked = true;
            }
            else
            {
                rbFail.Checked = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!rbFail.Checked && !rbPass.Checked)
            {
                MessageBox.Show("Select test result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Test.TestResult = rbPass.Checked;

            if (Test.Save())
            {
                TestAppointment.IsLocked = true;
                btn_Save.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
            {
                MessageBox.Show("Test Result Not Saved", "bad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TestAppointment.Save())
            {
                MessageBox.Show("Test appointment Locked Successfully", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmScheduledTest_Load(null, null);
            }
            else
            {
                MessageBox.Show("Test appointment Not Locked", "bad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
