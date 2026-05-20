namespace DVLD_Project.Licenses
{
    partial class frmCreateLocalDrivingLicense
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
            this.ucLocalDrivingApplicationDetails = new DVLD_Project.Applications.Controls.ucLocalDrivingApplicationDetails();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucLocalDrivingApplicationDetails
            // 
            this.ucLocalDrivingApplicationDetails.Location = new System.Drawing.Point(12, 12);
            this.ucLocalDrivingApplicationDetails.Name = "ucLocalDrivingApplicationDetails";
            this.ucLocalDrivingApplicationDetails.Size = new System.Drawing.Size(723, 405);
            this.ucLocalDrivingApplicationDetails.TabIndex = 0;
            // 
            // btn_Issue
            // 
            this.btn_Issue.Location = new System.Drawing.Point(241, 437);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(230, 63);
            this.btn_Issue.TabIndex = 1;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.UseVisualStyleBackColor = true;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // frmCreateLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 512);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.ucLocalDrivingApplicationDetails);
            this.Name = "frmCreateLocalDrivingLicense";
            this.Text = "frmCreateLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frmCreateLocalDrivingLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Applications.Controls.ucLocalDrivingApplicationDetails ucLocalDrivingApplicationDetails;
        private System.Windows.Forms.Button btn_Issue;
    }
}