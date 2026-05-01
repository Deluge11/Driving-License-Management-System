using DVLD.Classes;
using DVLD_Project.Applications;
using DVLD_Project.ApplicationTypes;
using DVLD_Project.Classes;
using DVLD_Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class HomeForm : Form
    {
        LoginForm loginForm;

        public HomeForm(LoginForm form)
        {
            InitializeComponent();
            this.loginForm = form;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleForm form = new PeopleForm();

            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersManageForm form = new UsersManageForm();
            form.ShowDialog();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails form = new frmUserDetails();
            form.LoadUser(clsGlobal.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword form = new frmChangePassword();
            form.LoadUser(clsGlobal.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes form = new frmManageApplicationTypes();
            form.ShowDialog();
        }

        private void drivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_AddUpdateLocalDrivingLicenseApplication().ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_ManageLocalDrivingLicense().ShowDialog();
        }
    }
}
