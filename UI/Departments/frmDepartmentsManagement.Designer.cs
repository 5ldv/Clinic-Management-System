namespace UI
{
    partial class frmDepartmentsManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.btnUpdateDepartment = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDepartmentsCount = new System.Windows.Forms.Label();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(86)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(223, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "DEPARTMENTS MANAGEMENT";
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(119)))), ((int)(((byte)(161)))));
            this.btnDeleteDepartment.Enabled = false;
            this.btnDeleteDepartment.FlatAppearance.BorderSize = 0;
            this.btnDeleteDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDepartment.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDepartment.Location = new System.Drawing.Point(744, 107);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(314, 66);
            this.btnDeleteDepartment.TabIndex = 2;
            this.btnDeleteDepartment.Text = "DELETE DEPARTMENT";
            this.btnDeleteDepartment.UseVisualStyleBackColor = false;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnDeleteDepartment_Click);
            // 
            // btnUpdateDepartment
            // 
            this.btnUpdateDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(119)))), ((int)(((byte)(161)))));
            this.btnUpdateDepartment.Enabled = false;
            this.btnUpdateDepartment.FlatAppearance.BorderSize = 0;
            this.btnUpdateDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDepartment.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDepartment.Location = new System.Drawing.Point(408, 107);
            this.btnUpdateDepartment.Name = "btnUpdateDepartment";
            this.btnUpdateDepartment.Size = new System.Drawing.Size(314, 66);
            this.btnUpdateDepartment.TabIndex = 2;
            this.btnUpdateDepartment.Text = "UPDATE DEPARTMENT";
            this.btnUpdateDepartment.UseVisualStyleBackColor = false;
            this.btnUpdateDepartment.Click += new System.EventHandler(this.btnUpdateDepartment_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(119)))), ((int)(((byte)(161)))));
            this.btnAddDepartment.FlatAppearance.BorderSize = 0;
            this.btnAddDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDepartment.ForeColor = System.Drawing.Color.White;
            this.btnAddDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDepartment.Location = new System.Drawing.Point(72, 107);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(314, 66);
            this.btnAddDepartment.TabIndex = 2;
            this.btnAddDepartment.Text = "ADD DEPARTMENT";
            this.btnAddDepartment.UseVisualStyleBackColor = false;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(86)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(65, 761);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "TOTAL DEPARTMENTS:";
            // 
            // lblDepartmentsCount
            // 
            this.lblDepartmentsCount.AutoSize = true;
            this.lblDepartmentsCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(86)))), ((int)(((byte)(127)))));
            this.lblDepartmentsCount.Location = new System.Drawing.Point(362, 761);
            this.lblDepartmentsCount.Name = "lblDepartmentsCount";
            this.lblDepartmentsCount.Size = new System.Drawing.Size(69, 40);
            this.lblDepartmentsCount.TabIndex = 1;
            this.lblDepartmentsCount.Text = "N/A";
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Location = new System.Drawing.Point(72, 213);
            this.dgvDepartments.MultiSelect = false;
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(986, 545);
            this.dgvDepartments.TabIndex = 3;
            this.dgvDepartments.SelectionChanged += new System.EventHandler(this.dgvDepartments_SelectionChanged);
            // 
            // frmDepartmentsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 807);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.btnUpdateDepartment);
            this.Controls.Add(this.btnDeleteDepartment);
            this.Controls.Add(this.lblDepartmentsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDepartmentsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDepartmentsManagement";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDepartmentsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Button btnUpdateDepartment;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDepartmentsCount;
        private System.Windows.Forms.DataGridView dgvDepartments;
    }
}