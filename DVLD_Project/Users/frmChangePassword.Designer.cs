namespace DVLD_Project.Users
{
    partial class frmChangePassword
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
            this.uc_UserDetail1 = new DVLD_Project.Users.uc_UserDetail();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.tb_OldPassword = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uc_UserDetail1
            // 
            this.uc_UserDetail1.Location = new System.Drawing.Point(-2, 2);
            this.uc_UserDetail1.Name = "uc_UserDetail1";
            this.uc_UserDetail1.Size = new System.Drawing.Size(714, 422);
            this.uc_UserDetail1.TabIndex = 0;
            this.uc_UserDetail1.Load += new System.EventHandler(this.uc_UserDetail1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Password";
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Location = new System.Drawing.Point(260, 468);
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.Size = new System.Drawing.Size(100, 26);
            this.tb_NewPassword.TabIndex = 4;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(260, 507);
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(100, 26);
            this.tb_ConfirmPassword.TabIndex = 5;
            // 
            // tb_OldPassword
            // 
            this.tb_OldPassword.Location = new System.Drawing.Point(260, 424);
            this.tb_OldPassword.Name = "tb_OldPassword";
            this.tb_OldPassword.Size = new System.Drawing.Size(100, 26);
            this.tb_OldPassword.TabIndex = 6;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(500, 499);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 43);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 581);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.tb_OldPassword);
            this.Controls.Add(this.tb_ConfirmPassword);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uc_UserDetail1);
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uc_UserDetail uc_UserDetail1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.TextBox tb_OldPassword;
        private System.Windows.Forms.Button btn_Save;
    }
}