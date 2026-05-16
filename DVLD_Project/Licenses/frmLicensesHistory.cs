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
    public partial class frmLicensesHistory : Form
    {
        clsDriver Driver;

        public frmLicensesHistory(int personId)
        {
            InitializeComponent();

            Driver = clsDriver.GetByPersonId(personId);

            if (Driver == null)
            {

            }

        
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            uc_PersonDetailsWithFilter.FilterEnabled = false;
            uc_PersonDetailsWithFilter.AddPersonEnabled = false;
            uc_PersonDetailsWithFilter.LoadPersonInfo(Driver.PersonID);
            dgv_LocalLicense.DataSource = clsLicense.GetAll(Driver.DriverID);
            dgv_InternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses(Driver.DriverID);
        }
    }
}
