using DVLD.Classes;
using DVLD_Business;
using DVLD_Project.Applications;
using DVLD_Project.Tests.Controls;
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
        clsLocalLicenseApplication application;

        clsTestType.enTestType TestTypeID = clsTestType.enTestType.Vision;
        public frmManageTestAppointment(int localDrivingLicenseApplicationId, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            application = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseApplicationId);

            if (application == null)
            {
                MessageBox.Show("There is no application with this id");
                return;
            }

            this.TestTypeID = TestType;
        }

        private void frmViewTestAppointmentDetails_Load(object sender, EventArgs e)
        {
            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(application.LocalDrivingLicenseApplicationID);
            RefreshTestAppointments();


            switch (TestTypeID)
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


        private void RefreshTestAppointments()
        {
            dgv_TestAppointments.DataSource = clsTestAppointment.GetTestAppointments(application.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (application.IsThereActiveTestAppointment(TestTypeID))
            {
                MessageBox.Show("There is already an open test appointment", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (application.DoesPassTestType(TestTypeID))
            {
                MessageBox.Show("This Test Passed Already", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest form = new frmScheduleTest();
            form.ScheduleNewTestAppointment(application.LocalDrivingLicenseApplicationID, TestTypeID);
            form.ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest form = new frmScheduleTest();
            form.UpdateTestAppointment((int)dgv_TestAppointments.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTakeTest((int)dgv_TestAppointments.CurrentRow.Cells[0].Value).ShowDialog();
            frmViewTestAppointmentDetails_Load(null, null);
        }
    }
}