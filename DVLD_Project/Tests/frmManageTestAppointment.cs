using DVLD.Classes;
using DVLD_Business;
using DVLD_Project.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmManageTestAppointment : Form
    {
        clsTestType.enTestType TestType;
        clsLocalLicenseApplication application;
        DataTable dtTestAppointments;
        public frmManageTestAppointment(int localDrivingLicenseApplicationId, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            application = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseApplicationId);

            if (application == null)
            {
                MessageBox.Show("There is no application with this id");
                return;
            }

            this.TestType = TestType;
        }

        private void frmViewTestAppointmentDetails_Load(object sender, EventArgs e)
        {
            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(application.LocalDrivingLicenseApplicationID);
            RefreshTestAppointments();
            lbl_Title.Text = GetTestTypeName() + " Test Appointment";
        }

        private string GetTestTypeName()
        {
            switch (TestType)
            {
                case clsTestType.enTestType.Vision:
                    return "Vision";
                case clsTestType.enTestType.Written:
                    return "Written";
                case clsTestType.enTestType.Street:
                    return "Street";
                default:
                    return "Unknown";
            }
        }

        private void RefreshTestAppointments()
        {
            dtTestAppointments = clsTestAppointment.GetTestAppointments(application.LocalDrivingLicenseApplicationID, TestType);
            dgv_TestAppointments.DataSource = dtTestAppointments;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (application.IsThereActiveTestAppointment(TestType))
            {
                MessageBox.Show("There is already an open test appointment", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (application.DoesPassTestType(TestType))
            {
                MessageBox.Show("This Test Passed Already", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddUpdateTestAppointment form = new frmAddUpdateTestAppointment(TestType, application.LocalDrivingLicenseApplicationID);
            form.ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateTestAppointment form = new frmAddUpdateTestAppointment((int)dgv_TestAppointments.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduledTest form = new frmScheduledTest((int)dgv_TestAppointments.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }
    }
}