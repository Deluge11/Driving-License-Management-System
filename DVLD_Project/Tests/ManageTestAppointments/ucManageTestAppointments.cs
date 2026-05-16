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
using DVLD_Project.Applications;
using static System.Net.Mime.MediaTypeNames;
using DVLD_Project.Tests.Controls;
using System.Runtime.InteropServices;

namespace DVLD_Project.Tests.ManageTestAppointments.Controls
{
    public partial class ucManageTestAppointments : UserControl
    {
        protected clsLocalLicenseApplication LDLA;
        protected virtual string Title { get; }
        protected virtual clsTestType.enTestType TestType { get; }

        public ucManageTestAppointments()
        {
            InitializeComponent();
        }

        private void ucManageTestAppointments_Load(object sender, EventArgs e)
        {
            lbl_Title.Text = Title;
        }

        public void LoadApplication(int localDrivingLicenseAppId)
        {
            LDLA = clsLocalLicenseApplication.GetByLocalId(localDrivingLicenseAppId);
            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(localDrivingLicenseAppId);
            RefreshTestAppointments();
        }

        private void RefreshTestAppointments()
        {
            dgv_TestAppointments.DataSource = clsTestAppointment.GetTestAppointments(LDLA.LocalDrivingLicenseApplicationID, TestType);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (LDLA.IsThereActiveTestAppointment(TestType))
            {
                MessageBox.Show("There is already an open test appointment", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LDLA.DoesPassTestType(TestType))
            {
                MessageBox.Show("This Test Passed Already", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest form = new frmScheduleTest();
            form.ScheduleNewTestAppointment(LDLA.LocalDrivingLicenseApplicationID, TestType);
            RefreshTestAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest form = new frmScheduleTest();
            form.UpdateTestAppointment((int)dgv_TestAppointments.CurrentRow.Cells[0].Value);
            RefreshTestAppointments();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTakeTest((int)dgv_TestAppointments.CurrentRow.Cells[0].Value).ShowDialog();
            RefreshTestAppointments();
        }
    }
}
