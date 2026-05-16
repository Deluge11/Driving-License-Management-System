namespace DVLD_Project.Tests
{
    partial class frmManageTestAppointment
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
            this.dgv_TestAppointments = new System.Windows.Forms.DataGridView();
            this.cmsManageTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Add = new System.Windows.Forms.Button();
            this.ucLocalDrivingApplicationDetails = new DVLD_Project.Applications.Controls.ucLocalDrivingApplicationDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestAppointments)).BeginInit();
            this.cmsManageTestAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(159, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(398, 42);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "View Test Appointment";
            // 
            // dgv_TestAppointments
            // 
            this.dgv_TestAppointments.AllowUserToAddRows = false;
            this.dgv_TestAppointments.AllowUserToDeleteRows = false;
            this.dgv_TestAppointments.AllowUserToResizeColumns = false;
            this.dgv_TestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TestAppointments.ContextMenuStrip = this.cmsManageTestAppointment;
            this.dgv_TestAppointments.Location = new System.Drawing.Point(38, 498);
            this.dgv_TestAppointments.MultiSelect = false;
            this.dgv_TestAppointments.Name = "dgv_TestAppointments";
            this.dgv_TestAppointments.RowHeadersWidth = 62;
            this.dgv_TestAppointments.RowTemplate.Height = 28;
            this.dgv_TestAppointments.Size = new System.Drawing.Size(564, 138);
            this.dgv_TestAppointments.TabIndex = 2;
            // 
            // cmsManageTestAppointment
            // 
            this.cmsManageTestAppointment.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsManageTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsManageTestAppointment.Name = "cmsManageTestAppointment";
            this.cmsManageTestAppointment.Size = new System.Drawing.Size(154, 68);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(625, 521);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 69);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // ucLocalDrivingApplicationDetails
            // 
            this.ucLocalDrivingApplicationDetails.Location = new System.Drawing.Point(12, 81);
            this.ucLocalDrivingApplicationDetails.Name = "ucLocalDrivingApplicationDetails";
            this.ucLocalDrivingApplicationDetails.Size = new System.Drawing.Size(723, 401);
            this.ucLocalDrivingApplicationDetails.TabIndex = 0;
            // 
            // frmManageTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dgv_TestAppointments);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.ucLocalDrivingApplicationDetails);
            this.Name = "frmManageTestAppointment";
            this.Text = "frmViewTestAppoitmentDetails";
            this.Load += new System.EventHandler(this.frmViewTestAppointmentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestAppointments)).EndInit();
            this.cmsManageTestAppointment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Controls.ucLocalDrivingApplicationDetails ucLocalDrivingApplicationDetails;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.DataGridView dgv_TestAppointments;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}