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
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            clsLocalLicenseApplication application = clsLocalLicenseApplication.GetLocalLicenseApplication((int)dgv_LocalDrivingLicense.CurrentRow.Cells[0].Value);


            if (application.Cancel())
                MessageBox.Show("This Application have been cancelled", "Application Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cant Cancel This Application", "Application Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            frm_ManageLocalDrivingLicense_Load(null,null);
        }
    }
}
