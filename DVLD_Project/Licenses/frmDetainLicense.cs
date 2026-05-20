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

namespace DVLD_Project.Licenses
{
    public partial class frmDetainLicense : Form
    {
        clsLicense CurrentLicense;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void ucLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            CurrentLicense = clsLicense.GetByLicenseId(obj);

            btn_Detain.Enabled = false;
            lbl_LicenseId.Text = "???";

            if (CurrentLicense == null)
            {
                MessageBox.Show("License Dont Exists");
                return;
            }

            if (CurrentLicense.IsDetained)
            {
                MessageBox.Show("License Detained Already");
                return;
            }

            if (!CurrentLicense.IsActive)
            {
                MessageBox.Show("License Is Not Active");
                return;
            }

            if (CurrentLicense.IsExpired)
            {
                MessageBox.Show("License Is Expired");
                return;
            }

            btn_Detain.Enabled = true;
            lbl_LicenseId.Text = CurrentLicense.LicenseID.ToString();
        }

        private void btn_Detain_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_Fees.Text, out int fees))
            {
                MessageBox.Show("Fees Only Accept Digits");
                return;
            }

            clsDetainedLicense DetainInfo = CurrentLicense.Detain(clsGlobal.CurrentUser.UserID, fees);

            if (DetainInfo != null)
            {
                MessageBox.Show("Detain Success");
                ucLicenseDetailsWithFilter1.Enabled = false;
                lbl_DetainID.Text = DetainInfo.DetainID.ToString();
                ucLicenseDetailsWithFilter1.LoadLicense(CurrentLicense.LicenseID);
                btn_Detain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Detain Failed");
            }

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lbl_CreateBy.Text = clsGlobal.CurrentUser.UserName;
            lbl_DetainDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}
