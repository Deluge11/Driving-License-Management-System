using DVLD.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            if (clsGlobal.GetStoredCredential(ref username, ref password))
            {
                tb_Password.Text = password;
                tb_Username.Text = username;
                cb_RemeberMe.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Invalid Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = tb_Username.Text.Trim();
            string password = tb_Password.Text.Trim();

            clsUser user = clsUser.Get(username, password);

            if (user == null)
            {
                MessageBox.Show("Wrong User Name Or Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!user.IsActive)
            {
                MessageBox.Show("This User is not Active", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cb_RemeberMe.Checked)
            {
                clsGlobal.RememberUsernameAndPassword(username, password);
            }

            clsGlobal.CurrentUser = user;

            HomeForm form = new HomeForm();
            form.Show();


        }

        private void textbox_Required(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string username = textBox.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Required Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void tb_Username_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
