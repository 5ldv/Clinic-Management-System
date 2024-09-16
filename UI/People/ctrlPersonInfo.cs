using ClinicManagement_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.People
{
    public partial class ctrlPersonInfo : UserControl
    {
        int _PersonID = -1;
        clsPerson _Person;
        public clsPerson GetSelectedPerson { get { return _Person; } }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        public void SetPersonID(int PersonID)
        {
            this._PersonID = PersonID;
            _LoadData();
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if(_Person == null)
                return;

            lblName.Text = _Person.GetFullName;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalID.Text = _Person.NationalIdentificationNumber;
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblBirthDate.Text = _Person.BirthDate.ToShortDateString();
            lblGender.Text = _Person.GetTextGender;
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
        }
        public void ResetControlInfo()
        {
            _PersonID = -1;
            _Person = null;

            lblName.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblNationalID.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblBirthDate.Text = "[????]";
            lblGender.Text = "[????]";
            lblCountry.Text = "[????]";
        }
    }
}
