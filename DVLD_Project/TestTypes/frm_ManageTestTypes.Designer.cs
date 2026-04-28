namespace DVLD_Project.TestTypes
{
    partial class frm_ManageTestTypes
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
            this.dgv_TestTypes = new System.Windows.Forms.DataGridView();
            this.cms_TestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestTypes)).BeginInit();
            this.cms_TestTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Test Types";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_TestTypes
            // 
            this.dgv_TestTypes.AllowUserToAddRows = false;
            this.dgv_TestTypes.AllowUserToDeleteRows = false;
            this.dgv_TestTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TestTypes.ContextMenuStrip = this.cms_TestTypes;
            this.dgv_TestTypes.Location = new System.Drawing.Point(50, 126);
            this.dgv_TestTypes.Name = "dgv_TestTypes";
            this.dgv_TestTypes.RowHeadersWidth = 62;
            this.dgv_TestTypes.RowTemplate.Height = 28;
            this.dgv_TestTypes.Size = new System.Drawing.Size(591, 254);
            this.dgv_TestTypes.TabIndex = 1;
            this.dgv_TestTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cms_TestTypes
            // 
            this.cms_TestTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_TestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypeToolStripMenuItem});
            this.cms_TestTypes.Name = "cms_TestTypes";
            this.cms_TestTypes.Size = new System.Drawing.Size(241, 69);
            // 
            // editTestTypeToolStripMenuItem
            // 
            this.editTestTypeToolStripMenuItem.Name = "editTestTypeToolStripMenuItem";
            this.editTestTypeToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.editTestTypeToolStripMenuItem.Text = "Edit Test Type";
            this.editTestTypeToolStripMenuItem.Click += new System.EventHandler(this.editTestTypeToolStripMenuItem_Click);
            // 
            // frm_ManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.dgv_TestTypes);
            this.Controls.Add(this.label1);
            this.Name = "frm_ManageTestTypes";
            this.Text = "frm_ManageTestTypes";
            this.Load += new System.EventHandler(this.frm_ManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestTypes)).EndInit();
            this.cms_TestTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_TestTypes;
        private System.Windows.Forms.ContextMenuStrip cms_TestTypes;
        private System.Windows.Forms.ToolStripMenuItem editTestTypeToolStripMenuItem;
    }
}