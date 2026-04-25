namespace DVLD_Project.Users
{
    partial class AddUpdateUserForm
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
            this.components = new System.ComponentModel.Container();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tc_AddNewUser = new System.Windows.Forms.TabControl();
            this.tp_PersonInfo = new System.Windows.Forms.TabPage();
            this.uc_PersonDetails = new DVLD_Project.uc_PersonDetailsWithFilter();
            this.tp_UserInfo = new System.Windows.Forms.TabPage();
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.cb_IsActive = new System.Windows.Forms.CheckBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc_AddNewUser.SuspendLayout();
            this.tp_PersonInfo.SuspendLayout();
            this.tp_UserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(345, 31);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(282, 47);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Add New User";
            // 
            // tc_AddNewUser
            // 
            this.tc_AddNewUser.Controls.Add(this.tp_PersonInfo);
            this.tc_AddNewUser.Controls.Add(this.tp_UserInfo);
            this.tc_AddNewUser.Location = new System.Drawing.Point(52, 81);
            this.tc_AddNewUser.Name = "tc_AddNewUser";
            this.tc_AddNewUser.SelectedIndex = 0;
            this.tc_AddNewUser.Size = new System.Drawing.Size(868, 475);
            this.tc_AddNewUser.TabIndex = 1;
            this.tc_AddNewUser.SelectedIndexChanged += new System.EventHandler(this.tc_AddNewUser_SelectedIndexChanged);
            // 
            // tp_PersonInfo
            // 
            this.tp_PersonInfo.Controls.Add(this.uc_PersonDetails);
            this.tp_PersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tp_PersonInfo.Name = "tp_PersonInfo";
            this.tp_PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PersonInfo.Size = new System.Drawing.Size(860, 442);
            this.tp_PersonInfo.TabIndex = 0;
            this.tp_PersonInfo.Text = "Personal Info";
            this.tp_PersonInfo.UseVisualStyleBackColor = true;
            this.tp_PersonInfo.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // uc_PersonDetails
            // 
            this.uc_PersonDetails.Location = new System.Drawing.Point(77, 6);
            this.uc_PersonDetails.Name = "uc_PersonDetails";
            this.uc_PersonDetails.Size = new System.Drawing.Size(699, 421);
            this.uc_PersonDetails.TabIndex = 0;
            this.uc_PersonDetails.Load += new System.EventHandler(this.uc_PersonDetailsWithFilter1_Load);
            this.uc_PersonDetails.Validating += new System.ComponentModel.CancelEventHandler(this.uc_PersonDetails_Validating);
            // 
            // tp_UserInfo
            // 
            this.tp_UserInfo.Controls.Add(this.lbl_UserId);
            this.tp_UserInfo.Controls.Add(this.cb_IsActive);
            this.tp_UserInfo.Controls.Add(this.tb_Password);
            this.tp_UserInfo.Controls.Add(this.tb_ConfirmPassword);
            this.tp_UserInfo.Controls.Add(this.tb_UserName);
            this.tp_UserInfo.Controls.Add(this.label5);
            this.tp_UserInfo.Controls.Add(this.label4);
            this.tp_UserInfo.Controls.Add(this.label3);
            this.tp_UserInfo.Controls.Add(this.label2);
            this.tp_UserInfo.Location = new System.Drawing.Point(4, 29);
            this.tp_UserInfo.Name = "tp_UserInfo";
            this.tp_UserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tp_UserInfo.Size = new System.Drawing.Size(860, 442);
            this.tp_UserInfo.TabIndex = 1;
            this.tp_UserInfo.Text = "User Info";
            this.tp_UserInfo.UseVisualStyleBackColor = true;
            this.tp_UserInfo.Click += new System.EventHandler(this.tp_UserInfo_Click);
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Location = new System.Drawing.Point(323, 58);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(36, 20);
            this.lbl_UserId.TabIndex = 9;
            this.lbl_UserId.Text = "???";
            // 
            // cb_IsActive
            // 
            this.cb_IsActive.AutoSize = true;
            this.cb_IsActive.Location = new System.Drawing.Point(297, 248);
            this.cb_IsActive.Name = "cb_IsActive";
            this.cb_IsActive.Size = new System.Drawing.Size(95, 24);
            this.cb_IsActive.TabIndex = 8;
            this.cb_IsActive.Text = "Is Active";
            this.cb_IsActive.UseVisualStyleBackColor = true;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(297, 147);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(100, 26);
            this.tb_Password.TabIndex = 6;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRequired);
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(297, 193);
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.PasswordChar = '*';
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(100, 26);
            this.tb_ConfirmPassword.TabIndex = 5;
            this.tb_ConfirmPassword.UseSystemPasswordChar = true;
            this.tb_ConfirmPassword.TextChanged += new System.EventHandler(this.tb_ConfirmPassword_TextChanged);
            this.tb_ConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tb_ConfirmPassword_Validating);
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(297, 101);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(100, 26);
            this.tb_UserName.TabIndex = 4;
            this.tb_UserName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRequired);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(729, 573);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 38);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(634, 633);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 38);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(729, 633);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 38);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddUpdateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 683);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.tc_AddNewUser);
            this.Controls.Add(this.lbl_Title);
            this.Name = "AddUpdateUserForm";
            this.Text = "AddUserForm";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.tc_AddNewUser.ResumeLayout(false);
            this.tp_PersonInfo.ResumeLayout(false);
            this.tp_UserInfo.ResumeLayout(false);
            this.tp_UserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TabControl tc_AddNewUser;
        private System.Windows.Forms.TabPage tp_PersonInfo;
        private System.Windows.Forms.TabPage tp_UserInfo;
        private uc_PersonDetailsWithFilter uc_PersonDetails;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.CheckBox cb_IsActive;
        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}