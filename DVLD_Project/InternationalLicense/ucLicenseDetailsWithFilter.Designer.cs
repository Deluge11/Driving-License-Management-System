namespace DVLD_Project.InternationalLicense
{
    partial class ucLicenseDetailsWithFilter
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
            this.tb_FilterBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_FindLicense = new System.Windows.Forms.Button();
            this.ucLocalDrivingLicenseDetails1 = new DVLD_Project.Licenses.ucLocalDrivingLicenseDetails();
            this.SuspendLayout();
            // 
            // tb_FilterBox
            // 
            this.tb_FilterBox.Location = new System.Drawing.Point(155, 29);
            this.tb_FilterBox.Name = "tb_FilterBox";
            this.tb_FilterBox.Size = new System.Drawing.Size(188, 26);
            this.tb_FilterBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "License ID";
            // 
            // btn_FindLicense
            // 
            this.btn_FindLicense.Location = new System.Drawing.Point(368, 21);
            this.btn_FindLicense.Name = "btn_FindLicense";
            this.btn_FindLicense.Size = new System.Drawing.Size(62, 42);
            this.btn_FindLicense.TabIndex = 3;
            this.btn_FindLicense.Text = "Find";
            this.btn_FindLicense.UseVisualStyleBackColor = true;
            this.btn_FindLicense.Click += new System.EventHandler(this.btn_FindLicense_Click);
            // 
            // ucLocalDrivingLicenseDetails1
            // 
            this.ucLocalDrivingLicenseDetails1.Location = new System.Drawing.Point(3, 77);
            this.ucLocalDrivingLicenseDetails1.Name = "ucLocalDrivingLicenseDetails1";
            this.ucLocalDrivingLicenseDetails1.Size = new System.Drawing.Size(669, 349);
            this.ucLocalDrivingLicenseDetails1.TabIndex = 1;
            // 
            // ucLicenseDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_FindLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucLocalDrivingLicenseDetails1);
            this.Controls.Add(this.tb_FilterBox);
            this.Name = "ucLicenseDetailsWithFilter";
            this.Size = new System.Drawing.Size(698, 440);
            this.Load += new System.EventHandler(this.ucLicenseDetailsWithFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_FilterBox;
        private Licenses.ucLocalDrivingLicenseDetails ucLocalDrivingLicenseDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_FindLicense;
    }
}
