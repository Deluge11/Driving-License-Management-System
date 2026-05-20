using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.InternationalLicense
{
    public partial class ucLicenseDetailsWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int licenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(licenseID);
            }
        }

        public ucLicenseDetailsWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicense(int LicenseId)
        {
            ucLocalDrivingLicenseDetails1.LoadLicense(LicenseId);
        }

        private void btn_FindLicense_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tb_FilterBox.Text, out int licenseId))
            {
                ucLocalDrivingLicenseDetails1.LoadLicense(licenseId);
                OnLicenseSelected.Invoke(licenseId);
            }
            else
            {
                ucLocalDrivingLicenseDetails1.LoadLicense(-1);
                OnLicenseSelected.Invoke(-1);
            }
        }

        private void ucLicenseDetailsWithFilter_Load(object sender, EventArgs e)
        {
            ucLocalDrivingLicenseDetails1.LoadLicense(-1);
        }
    }
}
