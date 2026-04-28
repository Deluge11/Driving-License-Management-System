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
    public partial class frm_EditApplicationType : Form
    {
        clsApplicationType ApplicationType;

        public frm_EditApplicationType(int applicationTypeID)
        {
            InitializeComponent();

            ApplicationType = clsApplicationType.Get(applicationTypeID);

            if (ApplicationType == null)
            {
                MessageBox.Show("No application with that Id");
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_EdtiApplicationType_Load(object sender, EventArgs e)
        {
            lbl_ApplicationTypeID.Text = ApplicationType.ApplicationTypeID.ToString();
            tb_Fees.Text = ApplicationType.ApplicationFees.ToString();
            tb_Title.Text = ApplicationType.ApplicationTypeTitle;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplicationType.ApplicationTypeTitle = tb_Title.Text;
            ApplicationType.ApplicationFees = Convert.ToDecimal(tb_Fees.Text);

            if (ApplicationType.Save())
            {
                MessageBox.Show("Done","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("not Saved", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbl_ApplicationTypeID_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
