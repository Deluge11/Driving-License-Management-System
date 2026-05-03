namespace DVLD_Project.Applications.Controls
{
    partial class ucLocalDrivingApplicationDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_LicenseName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ApplicationID = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_PassedTests = new System.Windows.Forms.Label();
            this.ucGeneralApplicationDetails = new DVLD_Project.Applications.Controls.ucGeneralApplicationDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LicenseName
            // 
            this.lbl_LicenseName.AutoSize = true;
            this.lbl_LicenseName.Location = new System.Drawing.Point(455, 19);
            this.lbl_LicenseName.Name = "lbl_LicenseName";
            this.lbl_LicenseName.Size = new System.Drawing.Size(36, 20);
            this.lbl_LicenseName.TabIndex = 1;
            this.lbl_LicenseName.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Applied for license";
            // 
            // lbl_ApplicationID
            // 
            this.lbl_ApplicationID.AutoSize = true;
            this.lbl_ApplicationID.Location = new System.Drawing.Point(146, 19);
            this.lbl_ApplicationID.Name = "lbl_ApplicationID";
            this.lbl_ApplicationID.Size = new System.Drawing.Size(36, 20);
            this.lbl_ApplicationID.TabIndex = 3;
            this.lbl_ApplicationID.Text = "???";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(455, 72);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(140, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show License Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Passed Tests";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PassedTests
            // 
            this.lbl_PassedTests.AutoSize = true;
            this.lbl_PassedTests.Location = new System.Drawing.Point(146, 72);
            this.lbl_PassedTests.Name = "lbl_PassedTests";
            this.lbl_PassedTests.Size = new System.Drawing.Size(36, 20);
            this.lbl_PassedTests.TabIndex = 6;
            this.lbl_PassedTests.Text = "???";
            this.lbl_PassedTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucGeneralApplicationDetails
            // 
            this.ucGeneralApplicationDetails.Location = new System.Drawing.Point(19, 121);
            this.ucGeneralApplicationDetails.Name = "ucGeneralApplicationDetails";
            this.ucGeneralApplicationDetails.Size = new System.Drawing.Size(576, 259);
            this.ucGeneralApplicationDetails.TabIndex = 7;
            // 
            // ucLocalDrivingApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucGeneralApplicationDetails);
            this.Controls.Add(this.lbl_PassedTests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbl_ApplicationID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_LicenseName);
            this.Controls.Add(this.label1);
            this.Name = "ucLocalDrivingApplicationDetails";
            this.Size = new System.Drawing.Size(723, 401);
            this.Load += new System.EventHandler(this.ucApplicationDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LicenseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ApplicationID;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_PassedTests;
        private ucGeneralApplicationDetails ucGeneralApplicationDetails;
    }
}
