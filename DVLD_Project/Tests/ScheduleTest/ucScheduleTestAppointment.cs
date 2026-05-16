using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_Business;
using static DVLD_Business.clsApplicationType;
using DVLD_Project.Properties;
using static DVLD_Business.clsTestType;

namespace DVLD_Project.Tests.ScheduleTest
{
    public partial class ucScheduleTestAppointment : UserControl
    {
        clsTestAppointment TestAppointment;
        clsApplication ReTestApplication;


        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.Vision;
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.Vision:
                            lbl_Title.Text = "Vision Test";
                            break;

                    case clsTestType.enTestType.Written:
                            lbl_Title.Text = "Written Test";
                            break;

                    case clsTestType.enTestType.Street:
                            lbl_Title.Text = "Street Test";
                            break;
                }
            }
        }

        public ucScheduleTestAppointment()
        {
            InitializeComponent();
        }

        private void ucScheduleTestAppointment_Load(object sender, EventArgs e)
        {
            dtpAppDate.MinDate = DateTime.Compare(DateTime.UtcNow, TestAppointment.AppointmentDate) < 0 ?
                DateTime.UtcNow : TestAppointment.AppointmentDate;
        }

        public void ScheduleNewTestAppointment(int localDrivingLicenseId)
        {
            clsLocalLicenseApplication Application = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseId);

            if (Application == null)
            {
                MessageBox.Show("Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestAppointment = new clsTestAppointment();
            TestAppointment.TestTypeID = TestTypeID;
            TestAppointment.LocalDrivingLicenseApplicationID = localDrivingLicenseId;
            TestAppointment.PaidFees = clsTestType.Get(TestTypeID).TestTypeFees;
            TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            TestAppointment.IsLocked = false;

            if (Application.GetTestTrails(TestAppointment.TestTypeID) > 0)
            {
                ReTestApplication = new clsApplication();
                ReTestApplication.ApplicationTypeID = ApplicationType.RetakeTest;
                ReTestApplication.ApplicantPersonID = Application.ApplicantPersonID;
                ReTestApplication.PaidFees = clsApplicationType.Get(ApplicationType.RetakeTest).ApplicationFees;
                ReTestApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }

            LoadData();
        }

        public void UpdateTestAppointment(int testAppointmentId)
        {
            TestAppointment = clsTestAppointment.Get(testAppointmentId);

            if (TestAppointment == null)
            {
                MessageBox.Show("Test appointment not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReTestApplication = TestAppointment.ReTestApplication;
            TestTypeID = TestAppointment.TestTypeID;

            LoadData();
        }

        private void LoadData()
        {
            lbl_Title.Text = TestAppointment.TestTypeID.ToString() + " Test";

            clsLocalLicenseApplication Application = TestAppointment.LocalDrivingLicenseApplication;
            lbl_LocalAppID.Text = Application.LocalDrivingLicenseApplicationID.ToString();
            lbl_Class.Text = Application.LicenseClass.ClassName;
            lbl_Name.Text = Application.ApplicationPersonInfo.FirstName;
            lbl_Trial.Text = Application.GetTestTrails(TestAppointment.TestTypeID).ToString();
            lbl_AppFees.Text = TestAppointment.PaidFees.ToString();

            if (ReTestApplication != null)
            {
                lbl_ReAppId.Text = ReTestApplication.ApplicationID.ToString();
                lbl_RAppFees.Text = ReTestApplication.PaidFees.ToString();
                lbl_TotalFees.Text = (TestAppointment.PaidFees + ReTestApplication.PaidFees).ToString();
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
            if (ReTestApplication != null && !ReTestApplication.Save())
            {
                MessageBox.Show("ReTest Application Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestAppointment.AppointmentDate = dtpAppDate.Value;

            if (ReTestApplication != null)
            {
                TestAppointment.RetakeTestApplicationID = ReTestApplication.ApplicationID;
            }

            if (TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment Saved Successfully", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Test Appointment Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
