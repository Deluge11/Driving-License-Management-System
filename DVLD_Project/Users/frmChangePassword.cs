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

namespace DVLD_Project.Users
{
    public partial class frmChangePassword : Form
    {
        clsUser User;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uc_UserDetail1_Load(object sender, EventArgs e)
        {

        }

        public void LoadUser(int userId)
        {
            User = clsUser.Get(userId);

            if (User == null)
            {
                uc_UserDetail1.LoadUser(-1);

            }
            else
            {
                uc_UserDetail1.LoadUser(userId);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (User == null)
            {
                MessageBox.Show("User Not Selected Yet!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldPassword = tb_OldPassword.Text.Trim();
            string newPassword = tb_NewPassword.Text.Trim();
            string confirmPassword = tb_ConfirmPassword.Text.Trim();

            if (oldPassword != User.Password)
            {
                MessageBox.Show("Wrong Old Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New Password Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Confirm Password Wrong", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User.Password = newPassword;

            if (User.Save())
            {
                MessageBox.Show("User Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
