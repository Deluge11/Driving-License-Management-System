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
using DVLD.Classes;

namespace DVLD_Project.InternationalLicense
{
    public partial class ucInternationalDetails : UserControl
    {
        clsInternationalLicense InternationalLicense;
        public ucInternationalDetails()
        {
            InitializeComponent();
        }

        private void ucInternationalDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadLicense(int licenseId)
        {
            InternationalLicense = clsInternationalLicense.GetByInternationalLicenseId(licenseId);
            LoadData();
        }

        private void LoadData()
        {
            if(InternationalLicense == null)
            {
                lbl_Fees.Text = clsApplicationType.Get(clsApplicationType.ApplicationType.NewInternationalLicense).ApplicationFees.ToString();
                lbl_ApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbl_IssueDate.Text = DateTime.Now.ToShortDateString();
                lbl_CreateBy.Text = clsGlobal.CurrentUser.UserName;
                lbl_ExpiryDate.Text = "???";
                lbl_ILApplicationID.Text = "";
                lbl_ILLicenseID.Text = "???";
                lbl_LocalLicenseID.Text = "???";
            }
            else
            {
                lbl_ILApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lbl_ApplicationDate.Text = InternationalLicense.Application.ApplicationDate.ToShortDateString();
                lbl_IssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
                lbl_ExpiryDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();
                lbl_CreateBy.Text = InternationalLicense.CreateByUser.UserName;
                lbl_Fees.Text = InternationalLicense.PaidFees.ToString();
                lbl_ILLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                lbl_LocalLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            }
        }
    }
}
