namespace DVLD_Project.Applications
{
    partial class frm_ManageLocalDrivingLicense
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_LocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.cms_LocalDrivingLicenseApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddLocalDrivingApplication = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalDrivingLicense)).BeginInit();
            this.cms_LocalDrivingLicenseApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Local Driving License";
            // 
            // dgv_LocalDrivingLicense
            // 
            this.dgv_LocalDrivingLicense.AllowUserToAddRows = false;
            this.dgv_LocalDrivingLicense.AllowUserToDeleteRows = false;
            this.dgv_LocalDrivingLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_LocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LocalDrivingLicense.ContextMenuStrip = this.cms_LocalDrivingLicenseApplication;
            this.dgv_LocalDrivingLicense.Location = new System.Drawing.Point(38, 167);
            this.dgv_LocalDrivingLicense.Name = "dgv_LocalDrivingLicense";
            this.dgv_LocalDrivingLicense.ReadOnly = true;
            this.dgv_LocalDrivingLicense.RowHeadersWidth = 62;
            this.dgv_LocalDrivingLicense.RowTemplate.Height = 28;
            this.dgv_LocalDrivingLicense.Size = new System.Drawing.Size(1055, 370);
            this.dgv_LocalDrivingLicense.TabIndex = 1;
            // 
            // cms_LocalDrivingLicenseApplication
            // 
            this.cms_LocalDrivingLicenseApplication.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_LocalDrivingLicenseApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.sechduleTestsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cms_LocalDrivingLicenseApplication.Name = "cms_LocalDrivingLicenseApplication";
            this.cms_LocalDrivingLicenseApplication.Size = new System.Drawing.Size(310, 229);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(309, 32);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // btn_AddLocalDrivingApplication
            // 
            this.btn_AddLocalDrivingApplication.Location = new System.Drawing.Point(1018, 93);
            this.btn_AddLocalDrivingApplication.Name = "btn_AddLocalDrivingApplication";
            this.btn_AddLocalDrivingApplication.Size = new System.Drawing.Size(75, 57);
            this.btn_AddLocalDrivingApplication.TabIndex = 2;
            this.btn_AddLocalDrivingApplication.Text = "Add";
            this.btn_AddLocalDrivingApplication.UseVisualStyleBackColor = true;
            // 
            // frm_ManageLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 603);
            this.Controls.Add(this.btn_AddLocalDrivingApplication);
            this.Controls.Add(this.dgv_LocalDrivingLicense);
            this.Controls.Add(this.label1);
            this.Name = "frm_ManageLocalDrivingLicense";
            this.Text = "frm_ManageLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frm_ManageLocalDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalDrivingLicense)).EndInit();
            this.cms_LocalDrivingLicenseApplication.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_LocalDrivingLicense;
        private System.Windows.Forms.Button btn_AddLocalDrivingApplication;
        private System.Windows.Forms.ContextMenuStrip cms_LocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}