using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class frmUserDetails: Form
    {
        public frmUserDetails()
        {
            InitializeComponent();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {

        }

        public void LoadUser(int userId)
        {
            uc_UserDetail1.LoadUser(userId);
        }

        private void uc_UserDetail1_Load(object sender, EventArgs e)
        {

        }
    }
}
