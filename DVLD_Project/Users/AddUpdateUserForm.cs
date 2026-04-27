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
    public partial class AddUpdateUserForm : Form
    {
        clsUser User;
        enum enMode { Add, Update }
        enMode Mode;
        public AddUpdateUserForm()
        {
            InitializeComponent();

            Mode = enMode.Add;
            User = new clsUser();
        }

        public AddUpdateUserForm(int userId)
        {
            InitializeComponent();

            if ((User = clsUser.Get(userId)) == null)
            {
                MessageBox.Show("User Not Exists");
                this.Close();
                return;
            }

            Mode = enMode.Update;
        }

        private void SetFormValues()
        {
            if (Mode == enMode.Add)
            {
                lbl_Title.Text = "Add New User";
                lbl_UserId.Text = "???";
                tb_UserName.Text = "";
                tb_Password.Text = "";
                tb_ConfirmPassword.Text = "";
                cb_IsActive.Checked = false;
            }
            else
            {
                lbl_Title.Text = "Update User";
                lbl_UserId.Text = User.UserID.ToString();
                tb_UserName.Text = User.UserName;
                tb_Password.Text = User.Password;
                tb_ConfirmPassword.Text = User.Password;
                cb_IsActive.Checked = User.IsActive;
                uc_PersonDetails.LoadPersonInfo(User.PersonID);
                uc_PersonDetails.FilterEnabled = false;
                uc_PersonDetails.AddPersonEnabled = false;
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            SetFormValues();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (!CanGoNext())
            {
                tc_AddNewUser.SelectedIndex = 0;
            }
            else
            {
                tc_AddNewUser.SelectedIndex = 1;

            }
        }

        private void tc_AddNewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_AddNewUser.SelectedIndex == 1 && !CanGoNext())
            {
                tc_AddNewUser.SelectedIndex = 0;
            }

            btn_Next.Visible = tc_AddNewUser.SelectedIndex == 0;
        }

        private bool CanGoNext()
        {
            clsPerson Person = uc_PersonDetails.Person;

            if (Person == null)
            {
                MessageBox.Show("Required Person Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Person.IsUser() && Mode == enMode.Add)
            {
                MessageBox.Show("This Person Is User Already", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Invalid Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.Add)
                User.PersonID = uc_PersonDetails.PersonId;

            User.UserName = tb_UserName.Text.Trim();
            User.Password = tb_Password.Text.Trim();
            User.IsActive = cb_IsActive.Checked;

            if (User.Save())
            {
                MessageBox.Show("User Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
                SetFormValues();
            }
            else
            {
                MessageBox.Show("User Save Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxRequired(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "Required Field!");
            }
            else
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
            }
        }

        private void tb_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb_ConfirmPassword, "Required Field!");
                return;
            }
            else
            {
                errorProvider1.SetError(tb_ConfirmPassword, "");
                e.Cancel = false;

            }

            if (tb_ConfirmPassword.Text.Trim() != tb_Password.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tb_ConfirmPassword, "Invalid Confirm Password!");
            }
            else
            {
                errorProvider1.SetError(tb_ConfirmPassword, "");
                e.Cancel = false;

            }
        }

        private void uc_PersonDetails_Validating(object sender, CancelEventArgs e)
        {
            if (uc_PersonDetails.Person == null)
            {
                errorProvider1.SetError(uc_PersonDetails, "Person Details Required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(uc_PersonDetails, "");
                e.Cancel = false;
            }
        }
    }
}
