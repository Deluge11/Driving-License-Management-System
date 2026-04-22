using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class FindPersonForm : Form
    {
        public delegate void DataBackEventHandler(object sender, int personId);
        public event DataBackEventHandler DataBack;
        public FindPersonForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, uc_PersonDetailsWithFilter1.PersonId);
        }
    }
}
