using DVLD.Classes;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project.Applications
{
    public partial class frm_AddUpdateLocalDrivingLicenseApplication : Form
    {
        clsLocalLicenseApplication Application;

        enum enMode { Add, Update }
        enMode Mode;

        public frm_AddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            Application = new clsLocalLicenseApplication();
            Application.ApplicationTypeID = (int)clsApplicationType.ApplicationType.LocalLicense;
            Mode = enMode.Add;

        }

        public frm_AddUpdateLocalDrivingLicenseApplication(int applicationID)
        {
            InitializeComponent();

            Application = clsLocalLicenseApplication.GetByLocalId(applicationID);

            if (Application == null)
            {
                MessageBox.Show($"There is no application with id = {applicationID}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            Mode = enMode.Update;
        }

        private void frm_AddLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            FillLicenseComboBox();
            SetDefaultValues();

            if (Mode == enMode.Update)
            {
                LoadData();
            }
        }

        private void FillLicenseComboBox()
        {
            foreach (DataRow row in clsLicenseClass.GetAll().Rows)
            {
                cb_LicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void SetDefaultValues()
        {
            if (Mode == enMode.Add)
            {
                lbl_Title.Text = "New Local Driving License Application";
                lbl_ApplicationCreatedBy.Text = clsGlobal.CurrentUser.Person.FirstName;
                lbl_ApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbl_Fees.Text = clsApplicationType.Get((int)clsApplicationType.ApplicationType.LocalLicense).ApplicationFees.ToString();
                cb_LicenseClass.SelectedIndex = 3;
            }
            else
            {
                lbl_Title.Text = "Update Local Driving License Application";
                uc_PersonDetails.FilterEnabled = false;
                uc_PersonDetails.AddPersonEnabled = false;
            }
        }

        private void LoadData()
        {
            uc_PersonDetails.LoadPersonInfo(Application.ApplicantPersonID);
            lbl_AppicationID.Text = Application.ApplicationID.ToString();
            lbl_ApplicationCreatedBy.Text = clsUser.Get(Application.CreatedByUserID).UserName;
            lbl_ApplicationDate.Text = Application.ApplicationDate.ToShortDateString();
            tc_AddUpdateApplicationDetails.Controls[1].Enabled = false;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (uc_PersonDetails.Person != null)
            {
                tc_AddUpdateApplicationDetails.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show($"Select Person First", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Invalid Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.Add)
            {
                Application.ApplicantPersonID = uc_PersonDetails.PersonId;
                Application.PaidFees = clsApplicationType.Get(Application.ApplicationTypeID).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }
            else
            {
                Application.LastStatusDate = DateTime.UtcNow;
            }

            int newLicenseClassID = clsLicenseClass.Get(cb_LicenseClass.Text).LicenseClassID;

            if (newLicenseClassID != Application.LicenseClassID)
            {
                Application.LicenseClassID = newLicenseClassID;

                if (!Application.IsPersonApplyOnThisLicense())
                {
                    MessageBox.Show($"This Person Cant Apply On this License Because May he had New Application or Completed One", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (Application.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show($"Saved Successfully", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbl_Title.Text = "Update Local Driving License Application";
                uc_PersonDetails.FilterEnabled = false;
                uc_PersonDetails.AddPersonEnabled = false;
                lbl_AppicationID.Text = Application.ApplicationID.ToString();
            }
            else
            {
                MessageBox.Show($"Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tc_AddUpdateApplicationDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_AddUpdateApplicationDetails.SelectedIndex == 1 && uc_PersonDetails.Person == null)
            {
                tc_AddUpdateApplicationDetails.SelectedIndex = 0;
                MessageBox.Show($"Select Person First", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_Next.Visible = tc_AddUpdateApplicationDetails.SelectedIndex == 0;

            //SetDefaultValues();

        }

        private void tp_PersonalDetails_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (uc_PersonDetails.Person == null)
            {
                e.Cancel = true;
                ep_1.SetError(uc_PersonDetails, "Need To Select Person!");
            }
            else
            {
                e.Cancel = false;
                ep_1.SetError(uc_PersonDetails, "");
            }
        }

        private void cb_LicenseClass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cb_LicenseClass.Text))
            {
                e.Cancel = true;
                ep_1.SetError(cb_LicenseClass, "Need To Select License Class!");
            }
            else
            {
                e.Cancel = false;
                ep_1.SetError(cb_LicenseClass, "");
            }
        }

        private void uc_PersonDetails_OnPersonSelected(int obj)
        {
            Application.ApplicantPersonID = obj;
            tc_AddUpdateApplicationDetails.Controls[1].Enabled = Application.ApplicantPersonID != -1;
        }
    }
}
