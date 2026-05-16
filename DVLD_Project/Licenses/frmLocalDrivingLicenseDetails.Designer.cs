namespace DVLD_Project.Licenses
{
    partial class frmLocalDrivingLicenseDetails
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
            this.ucLocalDrivingLicenseDetails1 = new DVLD_Project.Licenses.ucLocalDrivingLicenseDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucLocalDrivingLicenseDetails1
            // 
            this.ucLocalDrivingLicenseDetails1.Location = new System.Drawing.Point(24, 75);
            this.ucLocalDrivingLicenseDetails1.Name = "ucLocalDrivingLicenseDetails1";
            this.ucLocalDrivingLicenseDetails1.Size = new System.Drawing.Size(669, 349);
            this.ucLocalDrivingLicenseDetails1.TabIndex = 0;
            this.ucLocalDrivingLicenseDetails1.Load += new System.EventHandler(this.ucLocalDrivingLicenseDetails1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Details";
            // 
            // frmLocalDrivingLicenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucLocalDrivingLicenseDetails1);
            this.Name = "frmLocalDrivingLicenseDetails";
            this.Text = "frmLocalDrivingLicenseDetails";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucLocalDrivingLicenseDetails ucLocalDrivingLicenseDetails1;
        private System.Windows.Forms.Label label1;
    }
}