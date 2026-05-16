namespace DVLD_Project.Licenses
{
    partial class frmLicensesHistory
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
            this.tc_License = new System.Windows.Forms.TabControl();
            this.tp_Local = new System.Windows.Forms.TabPage();
            this.dgv_LocalLicense = new System.Windows.Forms.DataGridView();
            this.tp_International = new System.Windows.Forms.TabPage();
            this.dgv_InternationalLicense = new System.Windows.Forms.DataGridView();
            this.uc_PersonDetailsWithFilter = new DVLD_Project.uc_PersonDetailsWithFilter();
            this.tc_License.SuspendLayout();
            this.tp_Local.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalLicense)).BeginInit();
            this.tp_International.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InternationalLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // tc_License
            // 
            this.tc_License.Controls.Add(this.tp_Local);
            this.tc_License.Controls.Add(this.tp_International);
            this.tc_License.Location = new System.Drawing.Point(50, 479);
            this.tc_License.Name = "tc_License";
            this.tc_License.SelectedIndex = 0;
            this.tc_License.Size = new System.Drawing.Size(804, 176);
            this.tc_License.TabIndex = 2;
            // 
            // tp_Local
            // 
            this.tp_Local.Controls.Add(this.dgv_LocalLicense);
            this.tp_Local.Location = new System.Drawing.Point(4, 29);
            this.tp_Local.Name = "tp_Local";
            this.tp_Local.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Local.Size = new System.Drawing.Size(796, 143);
            this.tp_Local.TabIndex = 0;
            this.tp_Local.Text = "Local";
            this.tp_Local.UseVisualStyleBackColor = true;
            // 
            // dgv_LocalLicense
            // 
            this.dgv_LocalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_LocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LocalLicense.Location = new System.Drawing.Point(29, 15);
            this.dgv_LocalLicense.Name = "dgv_LocalLicense";
            this.dgv_LocalLicense.RowHeadersWidth = 62;
            this.dgv_LocalLicense.RowTemplate.Height = 28;
            this.dgv_LocalLicense.Size = new System.Drawing.Size(746, 128);
            this.dgv_LocalLicense.TabIndex = 0;
            // 
            // tp_International
            // 
            this.tp_International.Controls.Add(this.dgv_InternationalLicense);
            this.tp_International.Location = new System.Drawing.Point(4, 29);
            this.tp_International.Name = "tp_International";
            this.tp_International.Padding = new System.Windows.Forms.Padding(3);
            this.tp_International.Size = new System.Drawing.Size(796, 143);
            this.tp_International.TabIndex = 1;
            this.tp_International.Text = "International";
            this.tp_International.UseVisualStyleBackColor = true;
            // 
            // dgv_InternationalLicense
            // 
            this.dgv_InternationalLicense.AllowUserToAddRows = false;
            this.dgv_InternationalLicense.AllowUserToDeleteRows = false;
            this.dgv_InternationalLicense.AllowUserToResizeColumns = false;
            this.dgv_InternationalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_InternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InternationalLicense.Location = new System.Drawing.Point(28, 15);
            this.dgv_InternationalLicense.Name = "dgv_InternationalLicense";
            this.dgv_InternationalLicense.RowHeadersWidth = 62;
            this.dgv_InternationalLicense.RowTemplate.Height = 28;
            this.dgv_InternationalLicense.Size = new System.Drawing.Size(748, 128);
            this.dgv_InternationalLicense.TabIndex = 1;
            // 
            // uc_PersonDetailsWithFilter
            // 
            this.uc_PersonDetailsWithFilter.AddPersonEnabled = true;
            this.uc_PersonDetailsWithFilter.FilterEnabled = true;
            this.uc_PersonDetailsWithFilter.Location = new System.Drawing.Point(111, 59);
            this.uc_PersonDetailsWithFilter.Name = "uc_PersonDetailsWithFilter";
            this.uc_PersonDetailsWithFilter.Size = new System.Drawing.Size(699, 421);
            this.uc_PersonDetailsWithFilter.TabIndex = 1;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 732);
            this.Controls.Add(this.tc_License);
            this.Controls.Add(this.uc_PersonDetailsWithFilter);
            this.Controls.Add(this.label1);
            this.Name = "frmLicensesHistory";
            this.Text = "frmLicensesHistory";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.tc_License.ResumeLayout(false);
            this.tp_Local.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalLicense)).EndInit();
            this.tp_International.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InternationalLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private uc_PersonDetailsWithFilter uc_PersonDetailsWithFilter;
        private System.Windows.Forms.TabControl tc_License;
        private System.Windows.Forms.TabPage tp_Local;
        private System.Windows.Forms.TabPage tp_International;
        private System.Windows.Forms.DataGridView dgv_LocalLicense;
        private System.Windows.Forms.DataGridView dgv_InternationalLicense;
    }
}