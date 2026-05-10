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

namespace DVLD_Project.Applications
{
    public partial class frmLocalDrivingLicenseApplicationDetails: Form
    {
        int applicationId;
        public frmLocalDrivingLicenseApplicationDetails(int applicationID)
        {
            InitializeComponent();
        }

        private void ucLocalDrivingApplicationDetails1_Load(object sender, EventArgs e)
        {
            ucLocalDrivingApplicationDetails.LoadApplicationByLocalApplicationId(applicationId);
        }
    }
}
