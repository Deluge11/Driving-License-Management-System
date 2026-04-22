using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Project
{
    public partial class uc_PersonDetailsWithFilter : UserControl
    {
        public int PersonId
        {
            get
            {
                return uc_PersonDetails == null ? -1 : uc_PersonDetails.Person.PersonID;
            }
        }

        public clsPerson Person
        {
            get
            {
                return uc_PersonDetails.Person;
            }
        }

        enum enMode { ById, ByNationalNo }
        enMode enFilterMode;
        public uc_PersonDetailsWithFilter()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _SetFilterByNationalNo();
        }

        private void _SetFilterByPersonId()
        {
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("Person Id");
            enFilterMode = enMode.ById;
        }

        private void _SetFilterByNationalNo()
        {
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("National No");
            enFilterMode = enMode.ByNationalNo;
        }

        private void _FillComboBox()
        {
            cbFilterBy.Items.Add("Person Id");
            cbFilterBy.Items.Add("National No");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (enFilterMode == enMode.ById)
            {
                if (int.TryParse(text, out int personId))
                {
                    uc_PersonDetails.LoadPerson(personId);
                }
                else
                {
                    // Message Box Error
                }
            }
            else
            {
                uc_PersonDetails.LoadPerson(text);
            }
        }

        private void Load_DataBack(object sender, int personId)
        {
            uc_PersonDetails.LoadPerson(personId);
            _SetFilterByPersonId();
            textBox1.Text = personId.ToString();
        }

        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson();

            form.OnDataBack += Load_DataBack;

            form.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Person Id")
            {
                _SetFilterByPersonId();
            }
            else
            {
                _SetFilterByNationalNo();
            }
        }
    }
}
