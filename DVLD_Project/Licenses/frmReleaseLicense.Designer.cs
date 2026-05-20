namespace DVLD_Project.Licenses
{
    partial class frmReleaseLicense
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
            this.ucLicenseDetailsWithFilter1 = new DVLD_Project.InternationalLicense.ucLicenseDetailsWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_CreateBy = new System.Windows.Forms.Label();
            this.lbl_ApplicationId = new System.Windows.Forms.Label();
            this.lbl_FineFees = new System.Windows.Forms.Label();
            this.lbl_LicenseID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_DetainDate = new System.Windows.Forms.Label();
            this.lbl_TotalFees = new System.Windows.Forms.Label();
            this.lbl_AppFees = new System.Windows.Forms.Label();
            this.lbl_DetainID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Release = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucLicenseDetailsWithFilter1
            // 
            this.ucLicenseDetailsWithFilter1.Location = new System.Drawing.Point(-1, -2);
            this.ucLicenseDetailsWithFilter1.Name = "ucLicenseDetailsWithFilter1";
            this.ucLicenseDetailsWithFilter1.Size = new System.Drawing.Size(698, 440);
            this.ucLicenseDetailsWithFilter1.TabIndex = 0;
            this.ucLicenseDetailsWithFilter1.OnLicenseSelected += new System.Action<int>(this.ucLicenseDetailsWithFilter1_OnLicenseSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detain ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_CreateBy);
            this.groupBox1.Controls.Add(this.lbl_ApplicationId);
            this.groupBox1.Controls.Add(this.lbl_FineFees);
            this.groupBox1.Controls.Add(this.lbl_LicenseID);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lbl_DetainDate);
            this.groupBox1.Controls.Add(this.lbl_TotalFees);
            this.groupBox1.Controls.Add(this.lbl_AppFees);
            this.groupBox1.Controls.Add(this.lbl_DetainID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 407);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 190);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lbl_CreateBy
            // 
            this.lbl_CreateBy.AutoSize = true;
            this.lbl_CreateBy.Location = new System.Drawing.Point(439, 73);
            this.lbl_CreateBy.Name = "lbl_CreateBy";
            this.lbl_CreateBy.Size = new System.Drawing.Size(36, 20);
            this.lbl_CreateBy.TabIndex = 17;
            this.lbl_CreateBy.Text = "???";
            // 
            // lbl_ApplicationId
            // 
            this.lbl_ApplicationId.AutoSize = true;
            this.lbl_ApplicationId.Location = new System.Drawing.Point(439, 157);
            this.lbl_ApplicationId.Name = "lbl_ApplicationId";
            this.lbl_ApplicationId.Size = new System.Drawing.Size(36, 20);
            this.lbl_ApplicationId.TabIndex = 16;
            this.lbl_ApplicationId.Text = "???";
            // 
            // lbl_FineFees
            // 
            this.lbl_FineFees.AutoSize = true;
            this.lbl_FineFees.Location = new System.Drawing.Point(439, 109);
            this.lbl_FineFees.Name = "lbl_FineFees";
            this.lbl_FineFees.Size = new System.Drawing.Size(36, 20);
            this.lbl_FineFees.TabIndex = 15;
            this.lbl_FineFees.Text = "???";
            // 
            // lbl_LicenseID
            // 
            this.lbl_LicenseID.AutoSize = true;
            this.lbl_LicenseID.Location = new System.Drawing.Point(439, 32);
            this.lbl_LicenseID.Name = "lbl_LicenseID";
            this.lbl_LicenseID.Size = new System.Drawing.Size(36, 20);
            this.lbl_LicenseID.TabIndex = 14;
            this.lbl_LicenseID.Text = "???";
            this.lbl_LicenseID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 13;
            this.label13.Text = "Create By";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(314, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "Application ID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(314, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "Fine Fees";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(314, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 20);
            this.label16.TabIndex = 10;
            this.label16.Text = "License ID";
            // 
            // lbl_DetainDate
            // 
            this.lbl_DetainDate.AutoSize = true;
            this.lbl_DetainDate.Location = new System.Drawing.Point(177, 73);
            this.lbl_DetainDate.Name = "lbl_DetainDate";
            this.lbl_DetainDate.Size = new System.Drawing.Size(36, 20);
            this.lbl_DetainDate.TabIndex = 9;
            this.lbl_DetainDate.Text = "???";
            // 
            // lbl_TotalFees
            // 
            this.lbl_TotalFees.AutoSize = true;
            this.lbl_TotalFees.Location = new System.Drawing.Point(177, 157);
            this.lbl_TotalFees.Name = "lbl_TotalFees";
            this.lbl_TotalFees.Size = new System.Drawing.Size(36, 20);
            this.lbl_TotalFees.TabIndex = 8;
            this.lbl_TotalFees.Text = "???";
            // 
            // lbl_AppFees
            // 
            this.lbl_AppFees.AutoSize = true;
            this.lbl_AppFees.Location = new System.Drawing.Point(177, 109);
            this.lbl_AppFees.Name = "lbl_AppFees";
            this.lbl_AppFees.Size = new System.Drawing.Size(36, 20);
            this.lbl_AppFees.TabIndex = 7;
            this.lbl_AppFees.Text = "???";
            // 
            // lbl_DetainID
            // 
            this.lbl_DetainID.AutoSize = true;
            this.lbl_DetainID.Location = new System.Drawing.Point(177, 32);
            this.lbl_DetainID.Name = "lbl_DetainID";
            this.lbl_DetainID.Size = new System.Drawing.Size(36, 20);
            this.lbl_DetainID.TabIndex = 6;
            this.lbl_DetainID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Detain Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Application Fees";
            // 
            // btn_Release
            // 
            this.btn_Release.Location = new System.Drawing.Point(383, 616);
            this.btn_Release.Name = "btn_Release";
            this.btn_Release.Size = new System.Drawing.Size(272, 54);
            this.btn_Release.TabIndex = 3;
            this.btn_Release.Text = "Release License";
            this.btn_Release.UseVisualStyleBackColor = true;
            this.btn_Release.Click += new System.EventHandler(this.btn_Release_Click);
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 682);
            this.Controls.Add(this.btn_Release);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucLicenseDetailsWithFilter1);
            this.Name = "frmReleaseLicense";
            this.Text = "frmReleaseLicense";
            this.Load += new System.EventHandler(this.frmReleaseLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicense.ucLicenseDetailsWithFilter ucLicenseDetailsWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_CreateBy;
        private System.Windows.Forms.Label lbl_ApplicationId;
        private System.Windows.Forms.Label lbl_FineFees;
        private System.Windows.Forms.Label lbl_LicenseID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_DetainDate;
        private System.Windows.Forms.Label lbl_TotalFees;
        private System.Windows.Forms.Label lbl_AppFees;
        private System.Windows.Forms.Label lbl_DetainID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Release;
    }
}