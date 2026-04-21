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

namespace DVLD_Project
{
    public partial class PeopleForm : Form
    {
        string[] columnsToKeep = {
                "PersonID",
                "NationalNo",
                "Email",
                "FirstName",
                "SecondName",
                "ThirdName",
                "LastName",
                "Phone",
                "DateOfBirth",
                "Address",
                //"Gendor",
                "GendorName",
            };

        Dictionary<string, Type> colTypes = new Dictionary<string, Type>();

        public PeopleForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.Add("");
            cbFilterBy.Items.AddRange(columnsToKeep);
            LoadColumnTypes();
            RefreshForm();
        }


        private void LoadColumnTypes()
        {
            DataTable dt = clsPerson.GetAll();
            foreach (string colName in columnsToKeep)
            {
                if (dt.Columns.Contains(colName))
                    colTypes[colName] = dt.Columns[colName].DataType;
            }
        }

        private void RefreshForm()
        {
            textBox1.Visible = !string.IsNullOrEmpty(cbFilterBy.Text);
            RefreshPeopleDataGridView();
        }

        private void RefreshPeopleDataGridView()
        {
            DataTable dt = clsPerson.GetAll();

            string filterBy = cbFilterBy.Text;

            foreach (DataColumn col in dt.Columns.OfType<DataColumn>().ToList())
            {
                if (!columnsToKeep.Contains(col.ColumnName))
                {
                    dt.Columns.Remove(col);
                }
            }


            if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(textBox1.Text))
            {
                DataTable dtAfterFilter = dt.Clone();

                foreach (DataRow row in dt.Rows)
                {
                    if (row[filterBy].ToString() == textBox1.Text)
                    {
                        dtAfterFilter.ImportRow(row);
                    }
                }

                dgvPeople.DataSource = dtAfterFilter;

            }
            else
            {
                dgvPeople.DataSource = dt;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenAddPersonForm();
        }


        private void dgvPeople_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dgvPeople.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvPeople.ClearSelection();
                    dgvPeople.Rows[hit.RowIndex].Selected = true;

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;

            int personId = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);

            OpenUpdatePersonForm(personId);
        }


        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[0];
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;

            int personId = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);

            if (clsPerson.Delete(personId))
            {
                MessageBox.Show("Person Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshForm();
        }

        private void sentEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cms_Person_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddPersonForm();
        }

        private void OpenAddPersonForm()
        {
            AddUpdatePerson form = new AddUpdatePerson();
            form.ShowDialog();
            RefreshForm();
        }

        private void OpenUpdatePersonForm(int personId)
        {
            AddUpdatePerson form = new AddUpdatePerson(personId);
            form.ShowDialog();
            RefreshForm();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);

            PersonDetails form = new PersonDetails(personId);

            form.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            RefreshForm();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            string filterBy = cbFilterBy.Text;
            if (string.IsNullOrEmpty(filterBy) || !colTypes.ContainsKey(filterBy))
                return;

            Type colType = colTypes[filterBy];
            if (colType == typeof(int) || colType == typeof(long) || colType == typeof(decimal))
            {
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
