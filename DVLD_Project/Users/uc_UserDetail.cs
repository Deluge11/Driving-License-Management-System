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

namespace DVLD_Project.Users
{
    public partial class uc_UserDetail : UserControl
    {
        clsUser User;

        public uc_UserDetail()
        {
            InitializeComponent();
        }

        private void uc_UserDetails_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (User == null)
            {
                uc_PersonDetails1.LoadPerson(-1);
                lbl_UserId.Text = "???";
                lbl_Username.Text = "???";
                lbl_IsActive.Text = "???";
            }
            else
            {
                uc_PersonDetails1.LoadPerson(User.PersonID);
                lbl_UserId.Text = User.UserID.ToString();
                lbl_Username.Text = User.UserName;
                lbl_IsActive.Text = User.IsActive ? "Yes" : "No";
            }
        }

        public void LoadUser(int userId)
        {
            User = clsUser.Get(userId);

            if (User == null)
            {
                MessageBox.Show("User not Exists", "No Found");
            }

            RefreshForm();
        }


    }
}
