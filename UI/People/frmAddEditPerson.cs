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
using UI.Global;

namespace UI.People
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode { AddMode = 0, EditMode = 1 }
        enMode enCurrentMode;
        clsPerson _Person;
        int _PersonID;
        public frmAddEditPerson()
        {
            InitializeComponent();
            enCurrentMode = enMode.AddMode;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            enCurrentMode = enMode.EditMode;
            this._PersonID = PersonID;
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {

            if (enCurrentMode == enMode.AddMode)
            {
                lblHeader.Text = "ADD PERSON";
                btnSave.Text = "ADD";
            }
            else
            {
                lblHeader.Text = "EDIT PERSON";
                btnSave.Text = "SAVE";
            }
            _LoadData();
        }
        private void _SetDateBirthValueConstrins()
        {
            dtpBirthDate.MinDate = DateTime.Now.AddYears(-100);
            dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
        }
        private void _LoadCountriesToCombobox()
        {
            DataTable dtCountries = clsCountry.GetCountries();

            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }


        }
        private void _LoadData()
        {
            _LoadCountriesToCombobox();
            _SetDateBirthValueConstrins();
            if (enCurrentMode == enMode.AddMode)
            {
                _Person = new clsPerson();
                return;
            }
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
                return;

            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalID.Text = _Person.NationalIdentificationNumber;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            dtpBirthDate.Value = _Person.BirthDate;

            if (_Person.Gender)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }

            else
            {
                rbMale.Checked = false;
                rbFemale.Checked = true;
            }
            cbCountries.SelectedText.Contains(_Person.GetCountryName);
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.GetCountryName);
        }
        private void _Save()
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields contain invalid or missing data. " +
                    "Please correct the highlighted fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalIdentificationNumber = txtNationalID.Text.Trim();
            _Person.BirthDate = dtpBirthDate.Value;

            if (rbMale.Checked)
                _Person.Gender = false;
            else
                _Person.Gender = true;

            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.CountryID = clsCountry.Find(cbCountries.SelectedItem.ToString()).CountryID;
            _Person.Address = txtAddress.Text.Trim();



            if (_Person.Save())
            {
                if (enCurrentMode == enMode.AddMode)
                    lblPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Person Saved successfully!", "Save Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save the person.", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidateEmptyTextbox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }
        private void ValidateEmailTextbox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()) || clsValidation.ValidateEmail(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "Invalid email format. Please enter a valid email address (e.g., example@domain.com).");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }
        private void ValidateNameTextboxes(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (!clsValidation.ValidateName(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "Invalid name format. Please enter a valid name with letters");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
