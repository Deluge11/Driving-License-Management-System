namespace DVLD_Project.Users
{
    partial class UsersManageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Users = new System.Windows.Forms.DataGridView();
            this.cms_Users = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_FilterBy = new System.Windows.Forms.ComboBox();
            this.tb_FilterText = new System.Windows.Forms.TextBox();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.cb_Active = new System.Windows.Forms.ComboBox();
            this.btn_ApplyFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).BeginInit();
            this.cms_Users.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage User";
            // 
            // dgv_Users
            // 
            this.dgv_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Users.ContextMenuStrip = this.cms_Users;
            this.dgv_Users.Location = new System.Drawing.Point(99, 197);
            this.dgv_Users.Name = "dgv_Users";
            this.dgv_Users.RowHeadersWidth = 62;
            this.dgv_Users.RowTemplate.Height = 28;
            this.dgv_Users.Size = new System.Drawing.Size(855, 299);
            this.dgv_Users.TabIndex = 1;
            this.dgv_Users.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cms_Users
            // 
            this.cms_Users.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_Users.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.cms_Users.Name = "cms_Users";
            this.cms_Users.Size = new System.Drawing.Size(241, 197);
            this.cms_Users.Opening += new System.ComponentModel.CancelEventHandler(this.cmsUsers_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.addUserToolStripMenuItem.Text = "Add";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By";
            // 
            // cb_FilterBy
            // 
            this.cb_FilterBy.FormattingEnabled = true;
            this.cb_FilterBy.Location = new System.Drawing.Point(134, 150);
            this.cb_FilterBy.Name = "cb_FilterBy";
            this.cb_FilterBy.Size = new System.Drawing.Size(145, 28);
            this.cb_FilterBy.TabIndex = 3;
            this.cb_FilterBy.SelectedIndexChanged += new System.EventHandler(this.cb_FilterBy_SelectedIndexChanged);
            // 
            // tb_FilterText
            // 
            this.tb_FilterText.Location = new System.Drawing.Point(299, 149);
            this.tb_FilterText.Name = "tb_FilterText";
            this.tb_FilterText.Size = new System.Drawing.Size(152, 26);
            this.tb_FilterText.TabIndex = 4;
            this.tb_FilterText.TextChanged += new System.EventHandler(this.tb_FilterText_TextChanged);
            this.tb_FilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_FilterText_KeyPress);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Image = global::DVLD_Project.Properties.Resources.Add_New_User_32;
            this.btn_AddUser.Location = new System.Drawing.Point(879, 118);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(75, 60);
            this.btn_AddUser.TabIndex = 5;
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // cb_Active
            // 
            this.cb_Active.FormattingEnabled = true;
            this.cb_Active.Location = new System.Drawing.Point(299, 147);
            this.cb_Active.Name = "cb_Active";
            this.cb_Active.Size = new System.Drawing.Size(152, 28);
            this.cb_Active.TabIndex = 6;
            this.cb_Active.SelectedIndexChanged += new System.EventHandler(this.cb_Active_SelectedIndexChanged);
            // 
            // btn_ApplyFilter
            // 
            this.btn_ApplyFilter.Location = new System.Drawing.Point(488, 141);
            this.btn_ApplyFilter.Name = "btn_ApplyFilter";
            this.btn_ApplyFilter.Size = new System.Drawing.Size(75, 44);
            this.btn_ApplyFilter.TabIndex = 7;
            this.btn_ApplyFilter.Text = "Apply";
            this.btn_ApplyFilter.UseVisualStyleBackColor = true;
            this.btn_ApplyFilter.Click += new System.EventHandler(this.btn_ApplyFilter_Click);
            // 
            // UsersManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 577);
            this.Controls.Add(this.btn_ApplyFilter);
            this.Controls.Add(this.cb_Active);
            this.Controls.Add(this.btn_AddUser);
            this.Controls.Add(this.tb_FilterText);
            this.Controls.Add(this.cb_FilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_Users);
            this.Controls.Add(this.label1);
            this.Name = "UsersManageForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UsersManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).EndInit();
            this.cms_Users.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Users;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_FilterBy;
        private System.Windows.Forms.TextBox tb_FilterText;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.ComboBox cb_Active;
        private System.Windows.Forms.Button btn_ApplyFilter;
        private System.Windows.Forms.ContextMenuStrip cms_Users;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}