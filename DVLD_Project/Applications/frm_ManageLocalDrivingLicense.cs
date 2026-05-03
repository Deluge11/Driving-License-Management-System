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
            if (clsLocalLicenseApplication.DeleteLocalDrivingLicenseApplication((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value))
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

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationDetails form = new frmLocalDrivingLicenseApplicationDetails();
            form.LoadByLocalApplication((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }
    }
}
