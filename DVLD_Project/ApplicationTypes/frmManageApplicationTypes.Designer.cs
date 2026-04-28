namespace DVLD_Project.ApplicationTypes
{
    partial class frmManageApplicationTypes
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
            this.dgv_ApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cms_ApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApplicationTypes)).BeginInit();
            this.cms_ApplicationTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Application Types";
            // 
            // dgv_ApplicationTypes
            // 
            this.dgv_ApplicationTypes.AllowUserToAddRows = false;
            this.dgv_ApplicationTypes.AllowUserToDeleteRows = false;
            this.dgv_ApplicationTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ApplicationTypes.ContextMenuStrip = this.cms_ApplicationTypes;
            this.dgv_ApplicationTypes.Location = new System.Drawing.Point(55, 123);
            this.dgv_ApplicationTypes.Name = "dgv_ApplicationTypes";
            this.dgv_ApplicationTypes.RowHeadersWidth = 62;
            this.dgv_ApplicationTypes.RowTemplate.Height = 28;
            this.dgv_ApplicationTypes.Size = new System.Drawing.Size(717, 347);
            this.dgv_ApplicationTypes.TabIndex = 1;
            this.dgv_ApplicationTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cms_ApplicationTypes
            // 
            this.cms_ApplicationTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_ApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.cms_ApplicationTypes.Name = "cms_ApplicationTypes";
            this.cms_ApplicationTypes.Size = new System.Drawing.Size(252, 69);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(251, 32);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 553);
            this.Controls.Add(this.dgv_ApplicationTypes);
            this.Controls.Add(this.label1);
            this.Name = "frmManageApplicationTypes";
            this.Text = "frmManageApplicationTypes";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApplicationTypes)).EndInit();
            this.cms_ApplicationTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ApplicationTypes;
        private System.Windows.Forms.ContextMenuStrip cms_ApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}