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
using UI.Departments;

namespace UI
{
    public partial class frmDepartmentsManagement : Form
    {
        public frmDepartmentsManagement()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            DataTable dtDepartments = clsDepartment.GetDepartments();
            dgvDepartments.DataSource = dtDepartments;

            if (dgvDepartments.Rows.Count > 0)
            {
                dgvDepartments.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDepartments.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void frmDepartmentsManagement_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            frmAddEditDepartment frm = new frmAddEditDepartment();
            frm.ShowDialog();
            _LoadData();

        }
        private void btnUpdateDepartment_Click(object sender, EventArgs e)
        {
            short DepartmentID = short.Parse(dgvDepartments.CurrentRow.Cells[0].Value.ToString());
            frmAddEditDepartment frm = new frmAddEditDepartment(DepartmentID);
            frm.ShowDialog();
            _LoadData();
        }
        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            short DepartmentID = short.Parse(dgvDepartments.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("Are you sure you want to delete this department?",
                "Confirm Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (clsDepartment.DeleteDepartment(DepartmentID))
            {
                MessageBox.Show("The department has been successfully deleted.",
                    "Deletion Successful", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("An error occurred while deleting the department. Please try again.",
                    "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            btnUpdateDepartment.Enabled = (dgvDepartments.SelectedRows.Count > 0);
            btnDeleteDepartment.Enabled = (dgvDepartments.SelectedRows.Count > 0);
        }
    }
}
