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
    public partial class frmReleaseLicense : Form
    {
        clsLicense CurrentLicense;
        clsDetainedLicense DetainInfo;
        clsApplicationType ReleaseAppType = clsApplicationType.Get(clsApplicationType.ApplicationType.ReleaseDentainedLicense);

        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            btn_Release.Enabled = false;
            lbl_CreateBy.Text = clsGlobal.CurrentUser.UserName;
            lbl_AppFees.Text = ReleaseAppType.ApplicationFees.ToString();
        }

        private void ucLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            CurrentLicense = clsLicense.GetByLicenseId(obj);

            lbl_FineFees.Text = "???";
            lbl_TotalFees.Text = "???";
            lbl_LicenseID.Text = "???";
            lbl_DetainID.Text = "???";
            lbl_DetainDate.Text = "???";
            btn_Release.Enabled = false;

            if (CurrentLicense == null)
            {
                MessageBox.Show("License Dont exists");
                return;
            }

            DetainInfo = clsDetainedLicense.GetByLicenseId(CurrentLicense.LicenseID);

            if (DetainInfo == null)
            {
                MessageBox.Show("License Not Detained");
                return;
            }

            lbl_FineFees.Text = DetainInfo.FineFees.ToString();
            lbl_TotalFees.Text = (DetainInfo.FineFees + ReleaseAppType.ApplicationFees).ToString();
            lbl_DetainID.Text = DetainInfo.DetainID.ToString();
            lbl_DetainDate.Text = DetainInfo.DetainDate.ToShortDateString();
            lbl_LicenseID.Text = CurrentLicense.LicenseID.ToString();
            btn_Release.Enabled = true;
        }

        private void btn_Release_Click(object sender, EventArgs e)
        {
            if (CurrentLicense.Release(clsGlobal.CurrentUser.UserID))
            {
                ucLicenseDetailsWithFilter1.LoadLicense(CurrentLicense.LicenseID);
                ucLicenseDetailsWithFilter1.Enabled = false;
                btn_Release.Enabled = false;
                lbl_ApplicationId.Text = DetainInfo.ReleaseApplicationID.ToString();

                MessageBox.Show("Release Success");
            }
            else
            {
                MessageBox.Show("Release Failed");
            }
        }
    }
}
