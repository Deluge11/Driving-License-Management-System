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
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

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

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gb_Filter.Enabled = _FilterEnabled;
            }
        }

        private bool _AddPersonEnabled = true;
        public bool AddPersonEnabled
        {
            get
            {
                return _AddPersonEnabled;
            }
            set
            {
                _AddPersonEnabled = value;
                btn_AddPerson.Enabled = _AddPersonEnabled;
            }
        }

        public uc_PersonDetailsWithFilter()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            cbFilterBy.SelectedIndex = 1;
        }

        private void _FillComboBox()
        {
            cbFilterBy.Items.Add("Person Id");
            cbFilterBy.Items.Add("National No");
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            textBox1.Text = PersonID.ToString();
            FindNow();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person Id":
                    uc_PersonDetails.LoadPerson(int.Parse(textBox1.Text));

                    break;

                case "National No":
                    uc_PersonDetails.LoadPerson(textBox1.Text);
                    break;

                default:
                    break;
            }

            if (FilterEnabled)
                OnPersonSelected?.Invoke(uc_PersonDetails.Person != null ? uc_PersonDetails.Person.PersonID : -1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void Load_DataBack(object sender, int personId)
        {
            uc_PersonDetails.LoadPerson(personId);
            textBox1.Text = personId.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson();

            form.OnDataBack += Load_DataBack;

            form.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
