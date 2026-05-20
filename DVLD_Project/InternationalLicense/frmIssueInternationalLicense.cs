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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.InternationalLicense
{
    public partial class frmIssueInternationalLicense : Form
    {
        clsInternationalLicense NewInternationalLicense;

        int LicenseId;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            btn_Issue.Enabled = false;
        }

        private void ucLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            LicenseId = obj;
            btn_Issue.Enabled = CanIssueInternationalLicense() && NewInternationalLicense == null;
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (!CanIssueInternationalLicense())
            {
                return;
            }

            clsApplication application = new clsApplication();
            clsLicense localLicense = clsLicense.GetByLicenseId(LicenseId);
            clsApplicationType appType = clsApplicationType.Get(clsApplicationType.ApplicationType.NewInternationalLicense);

            application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            application.ApplicantPersonID = localLicense.Driver.PersonID;
            application.ApplicationTypeID = appType.ApplicationTypeID;
            application.PaidFees = appType.ApplicationFees;
            application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!application.Save())
            {
                return;
            }

            NewInternationalLicense = new clsInternationalLicense();
            NewInternationalLicense.IssuedUsingLocalLicenseID = LicenseId;
            NewInternationalLicense.ApplicationID = application.ApplicationID;
            NewInternationalLicense.DriverID = localLicense.DriverID;
            NewInternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            NewInternationalLicense.PaidFees = appType.ApplicationFees;

            if (NewInternationalLicense.Save())
            {
                MessageBox.Show($"International License Issued Successfully Id = {NewInternationalLicense.InternationalLicenseID}");
                ucInternationalDetails1.LoadLicense(NewInternationalLicense.InternationalLicenseID);
                btn_Issue.Enabled = false;
            }
            else
            {
                MessageBox.Show($"International License Issued Failed");
            }
        }

        private void btn_Issue_Validating(object sender, CancelEventArgs e)
        {

        }

        private bool CanIssueInternationalLicense()
        {
            clsLicense localLicense = clsLicense.GetByLicenseId(LicenseId);

            if (localLicense == null)
            {
                MessageBox.Show("Null License");
                return false;
            }

            if (clsInternationalLicense.IsDriverHaveInternationalLicense(localLicense.DriverID))
            {
                MessageBox.Show("This Driver Have International License");
                return false;
            }

            if (!localLicense.IsActive)
            {
                MessageBox.Show("This License In Not Active");
                return false;
            }

            if (localLicense.IsExpired)
            {
                MessageBox.Show("This License Expired");
                return false;
            }

            if (localLicense.IsDetained)
            {
                MessageBox.Show("This License In Not Active");
                return false;
            }

            return true;
        }
    }
}
