namespace DVLD_Project.InternationalLicense
{
    partial class frmIssueInternationalLicense
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
            this.btn_Issue = new System.Windows.Forms.Button();
            this.ucLicenseDetailsWithFilter1 = new DVLD_Project.InternationalLicense.ucLicenseDetailsWithFilter();
            this.ucInternationalDetails1 = new DVLD_Project.InternationalLicense.ucInternationalDetails();
            this.SuspendLayout();
            // 
            // btn_Issue
            // 
            this.btn_Issue.Location = new System.Drawing.Point(399, 654);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(295, 44);
            this.btn_Issue.TabIndex = 2;
            this.btn_Issue.Text = "Issue License";
            this.btn_Issue.UseVisualStyleBackColor = true;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            this.btn_Issue.Validating += new System.ComponentModel.CancelEventHandler(this.btn_Issue_Validating);
            // 
            // ucLicenseDetailsWithFilter1
            // 
            this.ucLicenseDetailsWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ucLicenseDetailsWithFilter1.Name = "ucLicenseDetailsWithFilter1";
            this.ucLicenseDetailsWithFilter1.Size = new System.Drawing.Size(698, 440);
            this.ucLicenseDetailsWithFilter1.TabIndex = 1;
            this.ucLicenseDetailsWithFilter1.OnLicenseSelected += new System.Action<int>(this.ucLicenseDetailsWithFilter1_OnLicenseSelected);
            // 
            // ucInternationalDetails1
            // 
            this.ucInternationalDetails1.Location = new System.Drawing.Point(-7, 421);
            this.ucInternationalDetails1.Name = "ucInternationalDetails1";
            this.ucInternationalDetails1.Size = new System.Drawing.Size(717, 216);
            this.ucInternationalDetails1.TabIndex = 0;
            // 
            // frmIssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 710);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.ucLicenseDetailsWithFilter1);
            this.Controls.Add(this.ucInternationalDetails1);
            this.Name = "frmIssueInternationalLicense";
            this.Text = "frmIssueInternationalLicense";
            this.Load += new System.EventHandler(this.frmIssueInternationalLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucInternationalDetails ucInternationalDetails1;
        private ucLicenseDetailsWithFilter ucLicenseDetailsWithFilter1;
        private System.Windows.Forms.Button btn_Issue;
    }
}