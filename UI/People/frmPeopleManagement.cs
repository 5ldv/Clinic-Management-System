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
    public partial class frmPeopleManagement : Form
    {

        public frmPeopleManagement()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            dgvPeople.DataSource = clsPerson.GetPeople();
            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].Width = 60;
                dgvPeople.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPeople.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            lblPeopleCount.Text = dgvPeople.Rows.Count.ToString();
        }
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _LoadData();
        }
        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmAddEditPerson frm = new frmAddEditPerson(SelectedPersonID);
            frm.ShowDialog();
            _LoadData();

        }
        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            clsPerson PersonToDelete = clsPerson.Find(SelectedPersonID);

            if (MessageBox.Show($"Are you sure you want to delete person named\n[{PersonToDelete.GetFullName}] with ID: [{SelectedPersonID}]?",
                "Delete Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            if (PersonToDelete.Delete())
            {
                MessageBox.Show("Person deleted successfully.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Failed to delete the person due to an error.",
                    "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmPersonInfo frm = new frmPersonInfo(SelectedPersonID);
            frm.ShowDialog();
        }
        private void dgvPeople_SelectionChanged(object sender, EventArgs e)
        {
            btnUpdatePerson.Enabled = (dgvPeople.SelectedRows.Count > 0);
            btnDeletePerson.Enabled = (dgvPeople.SelectedRows.Count > 0);
            btnPersonInfo.Enabled = (dgvPeople.SelectedRows.Count > 0);
        }
    }
}
