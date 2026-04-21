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
    public partial class PersonDetails: Form
    {
        int personId;

        public PersonDetails(int personId)
        {
            InitializeComponent();
            this.personId = personId;
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            uc_PersonDetails1.LoadPerson(personId);
        }

        
    }
}
