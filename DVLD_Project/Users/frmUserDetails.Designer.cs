namespace DVLD_Project.Users
{
    partial class frmUserDetails
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
            this.SuspendLayout();
            // 
            // uc_UserDetail1
            // 
            this.uc_UserDetail1.Location = new System.Drawing.Point(12, 0);
            this.uc_UserDetail1.Name = "uc_UserDetail1";
            this.uc_UserDetail1.Size = new System.Drawing.Size(714, 422);
            this.uc_UserDetail1.TabIndex = 0;
            this.uc_UserDetail1.Load += new System.EventHandler(this.uc_UserDetail1_Load);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 450);
            this.Controls.Add(this.uc_UserDetail1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_UserDetail uc_UserDetail1;
    }
}