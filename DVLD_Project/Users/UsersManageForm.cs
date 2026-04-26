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

namespace DVLD_Project.Users
{
    public partial class UsersManageForm : Form
    {
        enum enActiveFilter { No = 0, Yes = 1, All = -1 }

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
            switch (cb_FilterBy.Text)
            {
                case "None":
                    ResetFilter();
                    break;

                case "IsActive":

                    if (GetActive() == enActiveFilter.All)
                    {
                        ResetFilter();
                    }
                    else
                    {
                        FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cb_FilterBy.Text, (int)GetActive());
                    }
                    break;

                case "PersonID":
                    if (string.IsNullOrEmpty(tb_FilterText.Text.Trim()))
                    {
                        ResetFilter();
                    }
                    else
                    {
                        FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cb_FilterBy.Text, tb_FilterText.Text.Trim());
                    }

                    break;

                case "UserID":
                    if (string.IsNullOrEmpty(tb_FilterText.Text.Trim()))
                    {
                        ResetFilter();
                    }
                    else
                    {
                        FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", cb_FilterBy.Text, tb_FilterText.Text.Trim());
                    }
                    break;

                default:
                    if (string.IsNullOrEmpty(tb_FilterText.Text.Trim()))
                    {
                        ResetFilter();
                    }
                    else
                    {
                        FilteredUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cb_FilterBy.Text, tb_FilterText.Text.Trim());
                    }
                    break;

            }



        }

        private void ResetFilter()
        {
            FilteredUsers.DefaultView.RowFilter = "";
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

        private enActiveFilter GetActive()
        {
            switch (cb_Active.Text)
            {
                case "Yes":
                    return enActiveFilter.Yes;
                case "No":
                    return enActiveFilter.No;
                default:
                    return enActiveFilter.All;
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
                btn_ApplyFilter.Visible = false;
                cb_Active.Visible = false;
                tb_FilterText.Visible = false;
            }
            else if (cb_FilterBy.Text == "IsActive")
            {
                btn_ApplyFilter.Visible = true;
                tb_FilterText.Visible = false;
                cb_Active.Visible = true;
                cb_Active.SelectedIndex = 0;
            }
            else
            {
                btn_ApplyFilter.Visible = true;
                tb_FilterText.Visible = true;
                cb_Active.Visible = false;
                tb_FilterText.Text = "";
            }

            ApplyFilter();
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
            if (cb_FilterBy.Text == "PersonID" || cb_FilterBy.Text == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmsUsers_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUserForm form = new AddUpdateUserForm();
            form.ShowDialog();
            ResetUsers();
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
                MessageBox.Show("User Deleted Failed ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUserForm form = new AddUpdateUserForm((int)dgv_Users.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            ResetUsers();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails form = new frmUserDetails();
            form.LoadUser((int)dgv_Users.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            ResetUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword form = new frmChangePassword();
            form.LoadUser((int)dgv_Users.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }
    }
}
