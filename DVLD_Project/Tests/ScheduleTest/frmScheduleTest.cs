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

namespace DVLD_Project.Tests.Controls
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest()
        {
            InitializeComponent();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

        }

        public void ScheduleNewTestAppointment(int localDrivingLicenseAppId,clsTestType.enTestType TestType)
        {
            ucScheduleTestAppointment1.TestTypeID = TestType;
            ucScheduleTestAppointment1.ScheduleNewTestAppointment(localDrivingLicenseAppId);
        }

        public void UpdateTestAppointment(int testAppointment)
        {
            ucScheduleTestAppointment1.UpdateTestAppointment(testAppointment);
        }

        private void ucScheduleTestAppointment1_Load(object sender, EventArgs e)
        {

        }
    }
}
