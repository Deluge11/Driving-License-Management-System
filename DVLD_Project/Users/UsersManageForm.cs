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
    public partial class UsersManageForm : Form
    {
        static DataTable Users = clsUser.GetAll();
        DataTable FilteredUsers = Users.DefaultView.ToTable(false, ColumnsToKeep);

        static string[] ColumnsToKeep = {
                "UserID",
                "PersonID",
                "FullName",
                "UserName",
                "IsActive"
            };

        public UsersManageForm()
        {
            InitializeComponent();
        }

        private void ApplyFilter()
        {
            if (cb_FilterBy.Text == "None")
            {
                FilteredUsers.DefaultView.RowFilter = "";
            }

            if (cb_FilterBy.Text == "IsActive")
            {
                FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] = {1} OR {1} = -1", cb_FilterBy.Text, GetActiveDigit());
                return;
            }

            if (cb_FilterBy.Text == "PersonID" || cb_FilterBy.Text == "UserID")
            {
                FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cb_FilterBy.Text, tb_FilterText.Text.Trim());
            }
            else
            {
                if (string.IsNullOrEmpty(tb_FilterText.Text.Trim()))
                {
                    FilteredUsers.DefaultView.RowFilter = "";
                }
                else
                {
                    FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cb_FilterBy.Text, tb_FilterText.Text.Trim());
                }
            }

        }

        private void ResetUsers()
        {
            Users = clsUser.GetAll();
            FilteredUsers = Users.DefaultView.ToTable(false, ColumnsToKeep);
            dgv_Users.DataSource = FilteredUsers;
        }

        private void UsersManageForm_Load(object sender, EventArgs e)
        {
            dgv_Users.DataSource = FilteredUsers;
            FillActiveComboBox();
            FillFilterComboBox();
            cb_FilterBy.SelectedIndex = 0;
            cb_Active.SelectedIndex = 0;

            ApplyFilter();

        }

        private void FillFilterComboBox()
        {
            cb_FilterBy.Items.Add("None");
            cb_FilterBy.Items.AddRange(ColumnsToKeep);
        }

        private void FillActiveComboBox()
        {
            cb_Active.Items.Add("All");
            cb_Active.Items.Add("Yes");
            cb_Active.Items.Add("No");
        }

        private short GetActiveDigit()
        {
            switch (cb_Active.Text)
            {
                case "Yes":
                    return 1;
                case "No":
                    return 0;
                default:
                    return -1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            AddUpdateUserForm form = new AddUpdateUserForm();
            form.ShowDialog();
            ResetUsers();
        }

        private void cb_FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_FilterBy.Text == "None")
            {
                cb_Active.Visible = false;
                tb_FilterText.Visible = false;
            }
            else if (cb_FilterBy.Text == "IsActive")
            {
                tb_FilterText.Visible = false;
                cb_Active.Visible = true;
                cb_Active.SelectedIndex = 0;
            }
            else
            {
                cb_Active.Visible = false;
                tb_FilterText.Text = "";
                tb_FilterText.Visible = true;
            }
        }

        private void cb_Active_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tb_FilterText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void tb_FilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filterBy = cb_FilterBy.Text;
            if (filterBy == "None")
                return;

            if (filterBy == "PersonID" || filterBy == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmsUsers_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.Delete((int)dgv_Users.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetUsers();
            }
            else
            {
                MessageBox.Show("User Deleted Failed ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUserForm form = new AddUpdateUserForm((int)dgv_Users.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            ResetUsers();
        }


    }
}
