using DVLD_Business;
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

namespace DVLD_Project
{
    public partial class AddUpdatePerson : Form
    {
        clsPerson Person = null;
        string OriginalImagePath;
        enum enMode { Add, Update }
        enMode Mode;

        public AddUpdatePerson()
        {
            InitializeComponent();

            Person = new clsPerson();
            Mode = enMode.Add;

        }

        public AddUpdatePerson(int personId)
        {
            InitializeComponent();

            Person = clsPerson.GetById(personId);

            if (Person == null)
            {
                Person = new clsPerson();
                Mode = enMode.Add;
            }
            else
            {
                Mode = enMode.Update;
            }
        }

        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            _FillCountryComboBox();
            dtpBirthOfDate.MaxDate = DateTime.Now.AddYears(-18);
            dtpBirthOfDate.MinDate = DateTime.Now.AddYears(-90);

            OriginalImagePath = Person.ImagePath;
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (Mode == enMode.Add)
                _AddForm();
            else
                _UpdateForm();

            llbl_RemoveImage.Visible = Person.ImagePath != null;
            RefreshImage();
        }

        private void _AddForm()
        {
            rbMale.Checked = true;
            lblTitle.Text = "Add New Person";
            lblPersonId.Text = "N/A";
        }

        private void _UpdateForm()
        {
            lblTitle.Text = "Edit Person";
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

            cbCountry.SelectedItem = clsCountry.Get(Person.NationalityCountryId).CountryName;


            if (Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            if (Person.ImagePath != null)
            {
                string imageFullPath = GetImageFullPath(Person.ImagePath);

                if (File.Exists(imageFullPath))
                {
                    pbPersonImage.Image = LoadImageWithoutLock(imageFullPath);
                    pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void _FillCountryComboBox()
        {
            DataTable dt = clsCountry.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }

            cbCountry.SelectedItem = "Jordan";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Person.NationalNo = tbNationalNo.Text;
            Person.Address = tbAddress.Text;
            Person.Email = tbEmail.Text;
            Person.FirstName = tbFirstName.Text;
            Person.SecondName = tbSecondName.Text;
            Person.ThirdName = tbThirdName.Text;
            Person.LastName = tbLastName.Text;
            Person.Phone = tbPhone.Text;
            Person.DateOfBirth = dtpBirthOfDate.Value;

            Person.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            Person.NationalityCountryId = clsCountry.Get(cbCountry.SelectedItem.ToString()).CountryID;


            if (Person.Save())
            {
                if (Person.ImagePath != OriginalImagePath)
                {
                    if (!string.IsNullOrEmpty(Person.ImagePath))
                    {
                        string newImageFullPath = GetImageFullPath(Person.ImagePath);

                        using (Bitmap temp = new Bitmap(pbPersonImage.Image))
                        {
                            temp.Save(newImageFullPath, ImageFormat.Png);
                        }
                    }

                    if (!string.IsNullOrEmpty(OriginalImagePath))
                    {
                        string oldImageFullPath = GetImageFullPath(OriginalImagePath);

                        if (File.Exists(oldImageFullPath))
                        {
                            var oldImage = pbPersonImage.Image;
                            pbPersonImage.Image = null;
                            oldImage?.Dispose();
                            File.Delete(oldImageFullPath);
                        }

                    }

                    OriginalImagePath = Person.ImagePath;
                }

                MessageBox.Show("Info Saved Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Info Not Saved", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshForm();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Images|*.png|All Files|*.*";
            openFileDialog.Title = "Select PNG Image";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pbPersonImage.Image != null)
                {
                    pbPersonImage.Image.Dispose();
                    pbPersonImage.Image = null;
                }

                using (var img = Image.FromFile(openFileDialog.FileName))
                {
                    pbPersonImage.Image = new Bitmap(img);
                }

                Person.ImagePath = pbPersonImage.Image != null ? Guid.NewGuid().ToString() + ".png" : null;
                pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            }

            RefreshForm();
        }

        private Image LoadImageWithoutLock(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return new Bitmap(Image.FromStream(fs));
            }
        }

        private string GetExtension(string path)
        {
            int index = path.Length;
            List<char> buffer = new List<char>(5);

            while (path[--index] != '.')
            {
                buffer.Insert(0, path[index]);
            }

            return buffer.ToString();
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbFirstName_Leave(object sender, EventArgs e)
        {

        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (Person.NationalNo != tbNationalNo.Text && clsPerson.GetByNationalNo(tbNationalNo.Text) != null)
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

            if (!IsValidEmail(email))
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

        private bool IsValidEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex >= email.Length - 1)
                return false;

            int dotIndex = email.IndexOf('.', atIndex + 1);
            if (dotIndex <= 0 || dotIndex >= email.Length - 1)
                return false;

            string beforeAt = email.Substring(0, atIndex);
            string betweenAtDot = email.Substring(atIndex + 1, dotIndex - atIndex - 1);
            string afterDot = email.Substring(dotIndex + 1);

            return !string.IsNullOrWhiteSpace(beforeAt) &&
                   !string.IsNullOrWhiteSpace(betweenAtDot) &&
                   !string.IsNullOrWhiteSpace(afterDot);
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
            if (Person.ImagePath != null)
                return;

            pbPersonImage.Image = rbFemale.Checked ? image_collector.Images["Female.png"] : image_collector.Images["Male.png"];

            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private string GetImageFullPath(string path)
        {
            return Path.Combine(clsSystemSettings.ImageFolderPath, path);
        }



        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbl_RemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pbPersonImage.Image != null)
            {
                pbPersonImage.Image.Dispose();
                pbPersonImage.Image = null;
                Person.ImagePath = null;
            }

            RefreshForm();
        }


    }
}
