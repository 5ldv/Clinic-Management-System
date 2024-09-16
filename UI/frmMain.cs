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
using UI.People;

namespace UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void LoadForm(Form frm)
        {

            if (MainPanel.Controls.Count > 0)
                MainPanel.Controls.RemoveAt(0);

            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(frm);
            MainPanel.Tag = frm;
            frm.Show();
        }
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDepartmentsManagement());
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            LoadForm(new frmPeopleManagement());
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
