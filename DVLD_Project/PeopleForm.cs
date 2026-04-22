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
        static DataTable FullDataTable = clsPerson.GetAll();

        DataTable _dtPeople = FullDataTable.DefaultView.ToTable(false, columnsToKeep);

        static string[] columnsToKeep = {
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
                "GendorName",
            };

        Dictionary<string, Type> colTypes = new Dictionary<string, Type>();

        public PeopleForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;

            cbFilterBy.Items.Add("");
            cbFilterBy.Items.AddRange(columnsToKeep);
            cbFilterBy.SelectedIndex = 0;
            LoadColumnTypes();
            dgvPeople.DataSource = _dtPeople;
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


        private void RefreshPeople()
        {
            _dtPeople = clsPerson.GetAll().DefaultView.ToTable(false, columnsToKeep);
        }

        private void ApplyFilter()
        {
            string filterBy = cbFilterBy.Text;

            string value = textBox1.Text.Trim();

            if (filterBy == "" || string.IsNullOrEmpty(value))
            {
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }

            if (filterBy == columnsToKeep[0])
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterBy, value);
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterBy, value);
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

            int personId = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);

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

            RefreshPeople();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddPersonForm();
        }

        private void OpenAddPersonForm()
        {
            AddUpdatePerson form = new AddUpdatePerson();
            form.ShowDialog();
            RefreshPeople();
        }

        private void OpenUpdatePersonForm(int personId)
        {
            AddUpdatePerson form = new AddUpdatePerson(personId);
            form.ShowDialog();
            RefreshPeople();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PersonDetails(Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value)).ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = cbFilterBy.Text != "";
            textBox1.Clear();
            ApplyFilter();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
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
