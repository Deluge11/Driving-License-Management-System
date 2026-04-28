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

namespace DVLD_Project.ApplicationTypes
{
    public partial class frmManageApplicationTypes: Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshForm()
        {
            dgv_ApplicationTypes.DataSource = clsApplicationType.GetAll();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_EditApplicationType((int)dgv_ApplicationTypes.CurrentRow.Cells[0].Value).ShowDialog();
            RefreshForm();
        }
    }
}
