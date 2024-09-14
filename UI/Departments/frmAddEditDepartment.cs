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

namespace UI.Departments
{
    public partial class frmAddEditDepartment : Form
    {
        enum enMode { AddMode = 0, EditMode = 1 }
        enMode enCurrentFormMode;
        clsDepartment _Department;
        short _DepartmentID = -1;
        public frmAddEditDepartment()
        {
            InitializeComponent();
            enCurrentFormMode = enMode.AddMode;

        }
        public frmAddEditDepartment(short DepartmentID)
        {
            InitializeComponent();
            enCurrentFormMode = enMode.EditMode;
            this._DepartmentID = DepartmentID;
        }
        private void frmAddEditDepartment_Load(object sender, EventArgs e)
        {
            if (enCurrentFormMode == enMode.AddMode)
            {
                lblHeader.Text = "ADD DEPARTMENT";
                btnSave.Text = "SAVE DEPARTMENT";
            }
            else
            {
                lblHeader.Text = "EDIT DEPARTMENT";
                btnSave.Text = "SAVE CHANGES";
            }
            _LoadDepartment();
        }
        private void _LoadDepartment()
        {
            if (enCurrentFormMode == enMode.AddMode)
            {
                _Department = new clsDepartment();
                return;
            }

            _Department = clsDepartment.Find(_DepartmentID);

            if (_Department != null)
            {
                txtDepartmentID.Text = _Department.DepartmentID.ToString();
                txtDepartmentName.Text = _Department.DepartmentName;
                txtDepartmentLocation.Text = _Department.Location;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please ensure all required fields are filled before proceeding.",
                                 "Validation Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }


            _Department.DepartmentName = txtDepartmentName.Text;
            _Department.Location = txtDepartmentLocation.Text;
            if (_Department.Save())
            {
                MessageBox.Show("Department details have been successfully saved.",
                                "Save Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                if (enCurrentFormMode == enMode.AddMode)
                    txtDepartmentID.Text = _Department.DepartmentID.ToString();

                enCurrentFormMode = enMode.EditMode;
            }
            else
            {
                MessageBox.Show("An error occurred while saving the department details. Please try again.",
                                "Save Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


    }
}
