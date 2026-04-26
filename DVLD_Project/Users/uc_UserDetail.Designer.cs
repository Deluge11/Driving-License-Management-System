namespace DVLD_Project.Users
{
    partial class uc_UserDetail
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
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_IsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uc_PersonDetails1 = new DVLD_Project.uc_PersonDetails();
            this.SuspendLayout();
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Location = new System.Drawing.Point(108, 374);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(44, 20);
            this.lbl_UserId.TabIndex = 20;
            this.lbl_UserId.Text = "[???]";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(340, 374);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(44, 20);
            this.lbl_Username.TabIndex = 19;
            this.lbl_Username.Text = "[???]";
            // 
            // lbl_IsActive
            // 
            this.lbl_IsActive.AutoSize = true;
            this.lbl_IsActive.Location = new System.Drawing.Point(570, 374);
            this.lbl_IsActive.Name = "lbl_IsActive";
            this.lbl_IsActive.Size = new System.Drawing.Size(44, 20);
            this.lbl_IsActive.TabIndex = 18;
            this.lbl_IsActive.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Is Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "User Id";
            // 
            // uc_PersonDetails1
            // 
            this.uc_PersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_PersonDetails1.Location = new System.Drawing.Point(16, 14);
            this.uc_PersonDetails1.Name = "uc_PersonDetails1";
            this.uc_PersonDetails1.Size = new System.Drawing.Size(683, 338);
            this.uc_PersonDetails1.TabIndex = 14;
            // 
            // uc_UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_UserId);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_IsActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uc_PersonDetails1);
            this.Name = "uc_UserDetails";
            this.Size = new System.Drawing.Size(714, 422);
            this.Load += new System.EventHandler(this.uc_UserDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_IsActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private uc_PersonDetails uc_PersonDetails1;
    }
}
