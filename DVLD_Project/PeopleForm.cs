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
        public PeopleForm()
        {
            InitializeComponent();


            RefreshForm();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }



        private void RefreshForm()
        {
            RefreshPeopleDataGridVeiw();
        }

        private void RefreshPeopleDataGridVeiw()
        {
            DataTable dt = clsPerson.GetAll();

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

            foreach (DataColumn col in dt.Columns.OfType<DataColumn>().ToList())
            {
                if (!columnsToKeep.Contains(col.ColumnName))
                {
                    dt.Columns.Remove(col);
                }
            }

            dgvPeople.DataSource = dt;
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
    }
}
