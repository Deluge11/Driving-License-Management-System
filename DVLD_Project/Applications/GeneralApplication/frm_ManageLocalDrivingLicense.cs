using DVLD_Business;
using DVLD_Project.Licenses;
using DVLD_Project.Tests;
using DVLD_Project.Tests.ManageTestAppointments;
using DVLD_Project.Tests.ManageTestAppointments.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications
{
    public partial class frm_ManageLocalDrivingLicense : Form
    {
        DataTable dtLocalDrivingLicense = clsLocalLicenseApplication.GetAllLocalLicenseApplications();

        public frm_ManageLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frm_ManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            dtLocalDrivingLicense = clsLocalLicenseApplication.GetAllLocalLicenseApplications();
            dgv_LocalDrivingLicense.DataSource = dtLocalDrivingLicense;
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_AddUpdateLocalDrivingLicenseApplication((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value).ShowDialog();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication application = clsLocalLicenseApplication.GetByLocalId((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);

            if (application == null)
            {
                MessageBox.Show("Application Doesn't Exists", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (application.ApplicationStatus != clsApplication.enApplicationStatus.New)
            {
                MessageBox.Show("Cant Cancel This Application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            if (application.Cancel())
                MessageBox.Show("This Application Cancelled And Saved", "Application Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cancel Failed", "Application Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void btn_AddLocalDrivingApplication_Click(object sender, EventArgs e)
        {
            new frm_AddUpdateLocalDrivingLicenseApplication().ShowDialog();
            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication application = clsLocalLicenseApplication.GetByLocalId((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);

            if (application == null)
            {
                MessageBox.Show("Application Doesn't exists", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            if (application.DeleteLocalDrivingLicenseApplication())
            {
                MessageBox.Show("Application Deleted Successfully", "Application Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_ManageLocalDrivingLicense_Load(null, null);
            }
            else
            {
                MessageBox.Show("Cant Deleted Application", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cms_LocalDrivingLicenseApplication_Opening(object sender, CancelEventArgs e)
        {
            clsLocalLicenseApplication application = clsLocalLicenseApplication.GetByLocalId((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);

            if (application == null)
            {
                return;
            }

            if (application.ApplicationStatus == clsApplication.enApplicationStatus.Completed)
            {
                showLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                showLicenseToolStripMenuItem.Enabled = false;
            }

            if (application.ApplicationStatus != clsApplication.enApplicationStatus.New)
            {
                deleteApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                sechduleTestsToolStripMenuItem.Enabled = true;
            }

            if (application.DoesPassAllTests())
            {
                createDrivingLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                createDrivingLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLocalDrivingLicenseApplicationDetails((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value).ShowDialog();
        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication application = clsLocalLicenseApplication.GetByLocalId((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);

            bool isPassedViewTest = application.DoesPassTestType(clsTestType.enTestType.Vision);
            bool isPassedWrittenTest = application.DoesPassTestType(clsTestType.enTestType.Written);
            bool isPassedStreetTest = application.DoesPassTestType(clsTestType.enTestType.Street);

            viewTestToolStripMenuItem.Enabled = !isPassedViewTest;
            writtenTestToolStripMenuItem.Enabled = isPassedViewTest && !isPassedWrittenTest;
            drivingTestToolStripMenuItem.Enabled = isPassedWrittenTest && !isPassedStreetTest;
        }

        private void viewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageTestAppointment((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value, clsTestType.enTestType.Vision).ShowDialog();
            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageTestAppointment((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value,clsTestType.enTestType.Written).ShowDialog();
            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void drivingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageTestAppointment((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value, clsTestType.enTestType.Street).ShowDialog();
            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void createDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCreateLocalDrivingLicense((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value).ShowDialog();
            frm_ManageLocalDrivingLicense_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLocalDrivingLicenseDetails((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value).ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLicensesHistory(clsLocalLicenseApplication.GetByLocalId((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value).ApplicantPersonID).ShowDialog();
        }
    }
}
