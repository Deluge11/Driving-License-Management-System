using DVLD_Business;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DVLD_Project.Classes;

namespace DVLD_Project
{
    public partial class AddUpdatePerson : Form
    {
        public delegate void DataBack(object sender, int personId);

        public event DataBack OnDataBack;

        clsPerson Person = null;


        enum enMode { Add, Update }
        enum enGender { Male, Female }
        enMode Mode;

        public AddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.Add;
            Person = new clsPerson();

        }

        public AddUpdatePerson(int personId)
        {
            InitializeComponent();

            Person = clsPerson.Get(personId);

            if (Person == null)
            {
                MessageBox.Show("Person Not Exists");
                this.Close();
                return;
            }
            Mode = enMode.Update;

        }

        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            SetDefaultValues();

            if (Mode == enMode.Update)
                _LoadData();
        }

        private void SetDefaultValues()
        {
            _FillCountryComboBox();
            dtpBirthOfDate.MaxDate = DateTime.Now.AddYears(-18);
            dtpBirthOfDate.MinDate = DateTime.Now.AddYears(-90);
            dtpBirthOfDate.Value = dtpBirthOfDate.MaxDate;
           

            rbMale.Checked = true;

            ll_RemoveImage.Visible = pbPersonImage.ImageLocation != null;

            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

        }
        private void _LoadData()
        {
            if (Mode == enMode.Add)
            {
                lblTitle.Text = "Add New Person";

            }
            else
            {
                lblTitle.Text = "Edit Person";
            }

            lblPersonId.Text = Person.PersonID.ToString();
            tbNationalNo.Text = Person.NationalNo;
            tbAddress.Text = Person.Address;
            tbEmail.Text = Person.Email;
            tbFirstName.Text = Person.FirstName;
            tbSecondName.Text = Person.SecondName;
            tbThirdName.Text = Person.ThirdName;
            tbLastName.Text = Person.LastName;
            tbPhone.Text = Person.Phone;
            dtpBirthOfDate.Value = Person.DateOfBirth;

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Get(Person.NationalityCountryId).CountryName);


            if (Person.Gender == (short)enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (Person.ImagePath != null)
            {
                pbPersonImage.ImageLocation = clsUtil.GetImageFullPath(Person.ImagePath);
            }

            ll_RemoveImage.Visible = Person.ImagePath != null;
        }

        private void _FillCountryComboBox()
        {
            DataTable dt = clsCountry.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some field are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!HandleImageSave())
            {
                MessageBox.Show("Cannot Save The Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Person.NationalNo = tbNationalNo.Text.Trim();
            Person.Address = tbAddress.Text.Trim();
            Person.Email = tbEmail.Text.Trim();
            Person.FirstName = tbFirstName.Text.Trim();
            Person.SecondName = tbSecondName.Text.Trim();
            Person.ThirdName = tbThirdName.Text.Trim();
            Person.LastName = tbLastName.Text.Trim();
            Person.Phone = tbPhone.Text.Trim();
            Person.DateOfBirth = dtpBirthOfDate.Value;

            Person.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            Person.NationalityCountryId = clsCountry.Get(cbCountry.SelectedItem.ToString()).CountryID;

            Person.ImagePath = pbPersonImage.ImageLocation;

            if (Person.Save())
            {
                lblPersonId.Text = Person.PersonID.ToString();

                MessageBox.Show("Info Saved Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;

                OnDataBack?.Invoke(this, Person.PersonID);
            }
            else
            {
                MessageBox.Show("Info Not Saved", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _LoadData();
        }

        private bool HandleImageSave()
        {
            if (Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(Person.ImagePath))
                {
                    try
                    {
                        File.Delete(clsUtil.GetImageFullPath(Person.ImagePath));
                    }
                    catch (IOException)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                {
                    string sourceImagePath = pbPersonImage.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref sourceImagePath))
                    {
                        pbPersonImage.ImageLocation = sourceImagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Image Not Saved !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }


            return true;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Images|*.png;*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                pbPersonImage.ImageLocation = selectedFilePath;
                ll_RemoveImage.Visible = true;
            }

        }


        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(Person.NationalNo))
            {
                e.Cancel = true;
                tbNationalNo.Focus();
                errorProvider1.SetError(tbNationalNo, "Required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNo, "");
            }

            if (Person.NationalNo != tbNationalNo.Text.Trim() && clsPerson.Exists(tbNationalNo.Text))
            {
                e.Cancel = true;
                tbNationalNo.Focus();
                errorProvider1.SetError(tbNationalNo, "National No exists!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNo, "");
            }
        }


        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = tbEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
                return;

            if (!clsValidatoin.ValidateEmail(email))
            {
                e.Cancel = true;
                tbEmail.Focus();
                errorProvider1.SetError(tbEmail, "Invalid Email!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, "");
            }
        }

        private void tbRequired(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                tb.Focus();
                errorProvider1.SetError(tb, "Required Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, "");
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void RefreshImage()
        {
            if (pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = rbFemale.Checked ? Resources.Female_512 : Resources.Male_512;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ll_RemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            ll_RemoveImage.Visible = false;
            RefreshImage();
        }


    }
}
