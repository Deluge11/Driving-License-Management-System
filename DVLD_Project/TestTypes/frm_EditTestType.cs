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

namespace DVLD_Project.TestTypes
{
    public partial class frm_EditTestType : Form
    {
        clsTestType TestType;
        public frm_EditTestType(int testTypeID)
        {
            InitializeComponent();

            TestType = clsTestType.Get((clsTestType.enTestType)testTypeID);

            if (TestType == null)
            {
                MessageBox.Show("There is no Test Type with that ID");
                this.Close();
            }
        }

        private void frm_EditTestType_Load(object sender, EventArgs e)
        {
            lbl_TestTypeId.Text = ((int)TestType.TestTypeID).ToString();
            tb_Description.Text = TestType.TestTypeDescription;
            tb_Fees.Text = TestType.TestTypeFees.ToString();
            tb_Title.Text = TestType.TestTypeTitle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestType.TestTypeTitle = tb_Title.Text;
            TestType.TestTypeFees = Convert.ToDecimal(tb_Fees.Text);
            TestType.TestTypeDescription = tb_Description.Text;

            if (TestType.Save())
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
        }
    }
}
