using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Applications.Controls
{
    public partial class ucGeneralApplicationDetails: UserControl
    {
        clsApplication application;
        public ucGeneralApplicationDetails()
        {
            InitializeComponent();
        }

        private void ucApplicationDetails_Load(object sender, EventArgs e)
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            lbl_ID.Text = "???";
            lbl_Fees.Text = "???";
            lbl_Status.Text = "???";
            lbl_StatusDate.Text = "???";
            lbl_CreatedBy.Text = "???";
            lbl_CreatedDate.Text = "???";
            lbl_Person.Text = "???";
            lbl_Type.Text = "???";
        }

        public void LoadApplication(int applicationId)
        {
            application = clsApplication.Get(applicationId);
            LoadData();
        }

        private void LoadData()
        {
            if (application == null)
            {
                MessageBox.Show("This Application Does not exists", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultValues();
                return;
            }

            lbl_ID.Text = application.ApplicationID.ToString();
            lbl_Fees.Text = application.PaidFees.ToString();
            lbl_Status.Text = application.StatusText;
            lbl_StatusDate.Text = application.LastStatusDate.ToShortDateString();
            lbl_CreatedBy.Text = application.CreatedByUserInfo.UserName;
            lbl_CreatedDate.Text = application.ApplicationDate.ToShortDateString();
            lbl_Person.Text = application.ApplicationPersonInfo.FullName;
            lbl_Type.Text = application.ApplicationTypeInfo.ApplicationTypeTitle;

        }
    }
}
