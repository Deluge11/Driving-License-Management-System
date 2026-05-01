using DVLD_Business;
using DVLD_Project.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.TestTypes
{
    public partial class frm_ManageTestTypes : Form
    {
        DataTable TestTypes = clsTestType.GetAll();
        public frm_ManageTestTypes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_ManageTestTypes_Load(object sender, EventArgs e)
        {
            TestTypes = clsTestType.GetAll();
            dgv_TestTypes.DataSource = TestTypes;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_EditTestType((int)dgv_TestTypes.CurrentRow.Cells[0].Value).ShowDialog();
            frm_ManageTestTypes_Load(null, null);
        }
    }
}
