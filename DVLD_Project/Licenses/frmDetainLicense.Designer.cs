namespace DVLD_Project.Licenses
{
    partial class frmDetainLicense
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Fees = new System.Windows.Forms.TextBox();
            this.lbl_CreateBy = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_LicenseId = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_DetainDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_DetainID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Detain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucLicenseDetailsWithFilter1
            // 
            this.ucLicenseDetailsWithFilter1.Location = new System.Drawing.Point(-1, 12);
            this.ucLicenseDetailsWithFilter1.Name = "ucLicenseDetailsWithFilter1";
            this.ucLicenseDetailsWithFilter1.Size = new System.Drawing.Size(698, 440);
            this.ucLicenseDetailsWithFilter1.TabIndex = 0;
            this.ucLicenseDetailsWithFilter1.OnLicenseSelected += new System.Action<int>(this.ucLicenseDetailsWithFilter1_OnLicenseSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Fees);
            this.groupBox1.Controls.Add(this.lbl_CreateBy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_LicenseId);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lbl_DetainDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_DetainID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tb_Fees
            // 
            this.tb_Fees.Location = new System.Drawing.Point(102, 116);
            this.tb_Fees.Name = "tb_Fees";
            this.tb_Fees.Size = new System.Drawing.Size(108, 26);
            this.tb_Fees.TabIndex = 12;
            // 
            // lbl_CreateBy
            // 
            this.lbl_CreateBy.AutoSize = true;
            this.lbl_CreateBy.Location = new System.Drawing.Point(407, 66);
            this.lbl_CreateBy.Name = "lbl_CreateBy";
            this.lbl_CreateBy.Size = new System.Drawing.Size(36, 20);
            this.lbl_CreateBy.TabIndex = 11;
            this.lbl_CreateBy.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Create By";
            // 
            // lbl_LicenseId
            // 
            this.lbl_LicenseId.AutoSize = true;
            this.lbl_LicenseId.Location = new System.Drawing.Point(407, 22);
            this.lbl_LicenseId.Name = "lbl_LicenseId";
            this.lbl_LicenseId.Size = new System.Drawing.Size(36, 20);
            this.lbl_LicenseId.TabIndex = 7;
            this.lbl_LicenseId.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "License ID";
            // 
            // lbl_DetainDate
            // 
            this.lbl_DetainDate.AutoSize = true;
            this.lbl_DetainDate.Location = new System.Drawing.Point(135, 66);
            this.lbl_DetainDate.Name = "lbl_DetainDate";
            this.lbl_DetainDate.Size = new System.Drawing.Size(36, 20);
            this.lbl_DetainDate.TabIndex = 5;
            this.lbl_DetainDate.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detain Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fees";
            // 
            // lbl_DetainID
            // 
            this.lbl_DetainID.AutoSize = true;
            this.lbl_DetainID.Location = new System.Drawing.Point(135, 22);
            this.lbl_DetainID.Name = "lbl_DetainID";
            this.lbl_DetainID.Size = new System.Drawing.Size(36, 20);
            this.lbl_DetainID.TabIndex = 1;
            this.lbl_DetainID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID";
            // 
            // btn_Detain
            // 
            this.btn_Detain.Location = new System.Drawing.Point(409, 586);
            this.btn_Detain.Name = "btn_Detain";
            this.btn_Detain.Size = new System.Drawing.Size(240, 49);
            this.btn_Detain.TabIndex = 2;
            this.btn_Detain.Text = "Detain";
            this.btn_Detain.UseVisualStyleBackColor = true;
            this.btn_Detain.Click += new System.EventHandler(this.btn_Detain_Click);
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 677);
            this.Controls.Add(this.btn_Detain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucLicenseDetailsWithFilter1);
            this.Name = "frmDetainLicense";
            this.Text = "frmDetainLicense";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicense.ucLicenseDetailsWithFilter ucLicenseDetailsWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_DetainDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DetainID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Fees;
        private System.Windows.Forms.Label lbl_CreateBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_LicenseId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Detain;
    }
}