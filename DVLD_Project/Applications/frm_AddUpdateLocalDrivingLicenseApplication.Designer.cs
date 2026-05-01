namespace DVLD_Project.Applications
{
    partial class frm_AddUpdateLocalDrivingLicenseApplication
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
            this.tc_AddUpdateApplicationDetails = new System.Windows.Forms.TabControl();
            this.tp_PersonalDetails = new System.Windows.Forms.TabPage();
            this.uc_PersonDetails = new DVLD_Project.uc_PersonDetailsWithFilter();
            this.tp_ApplicationDetails = new System.Windows.Forms.TabPage();
            this.cb_LicenseClass = new System.Windows.Forms.ComboBox();
            this.lbl_ApplicationDate = new System.Windows.Forms.Label();
            this.lbl_AppicationID = new System.Windows.Forms.Label();
            this.lbl_ApplicationCreatedBy = new System.Windows.Forms.Label();
            this.lbl_Fees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.ep_1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tc_AddUpdateApplicationDetails.SuspendLayout();
            this.tp_PersonalDetails.SuspendLayout();
            this.tp_ApplicationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(95, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(79, 52);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "???";
            // 
            // tc_AddUpdateApplicationDetails
            // 
            this.tc_AddUpdateApplicationDetails.Controls.Add(this.tp_PersonalDetails);
            this.tc_AddUpdateApplicationDetails.Controls.Add(this.tp_ApplicationDetails);
            this.tc_AddUpdateApplicationDetails.Location = new System.Drawing.Point(44, 74);
            this.tc_AddUpdateApplicationDetails.Name = "tc_AddUpdateApplicationDetails";
            this.tc_AddUpdateApplicationDetails.SelectedIndex = 0;
            this.tc_AddUpdateApplicationDetails.Size = new System.Drawing.Size(894, 475);
            this.tc_AddUpdateApplicationDetails.TabIndex = 1;
            this.tc_AddUpdateApplicationDetails.SelectedIndexChanged += new System.EventHandler(this.tc_AddUpdateApplicationDetails_SelectedIndexChanged);
            // 
            // tp_PersonalDetails
            // 
            this.tp_PersonalDetails.Controls.Add(this.uc_PersonDetails);
            this.tp_PersonalDetails.Location = new System.Drawing.Point(4, 29);
            this.tp_PersonalDetails.Name = "tp_PersonalDetails";
            this.tp_PersonalDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PersonalDetails.Size = new System.Drawing.Size(886, 442);
            this.tp_PersonalDetails.TabIndex = 0;
            this.tp_PersonalDetails.Text = "Person Details";
            this.tp_PersonalDetails.UseVisualStyleBackColor = true;
            this.tp_PersonalDetails.Validating += new System.ComponentModel.CancelEventHandler(this.tp_PersonalDetails_Validating);
            // 
            // uc_PersonDetails
            // 
            this.uc_PersonDetails.AddPersonEnabled = true;
            this.uc_PersonDetails.FilterEnabled = true;
            this.uc_PersonDetails.Location = new System.Drawing.Point(86, 6);
            this.uc_PersonDetails.Name = "uc_PersonDetails";
            this.uc_PersonDetails.Size = new System.Drawing.Size(699, 421);
            this.uc_PersonDetails.TabIndex = 0;
            // 
            // tp_ApplicationDetails
            // 
            this.tp_ApplicationDetails.Controls.Add(this.cb_LicenseClass);
            this.tp_ApplicationDetails.Controls.Add(this.lbl_ApplicationDate);
            this.tp_ApplicationDetails.Controls.Add(this.lbl_AppicationID);
            this.tp_ApplicationDetails.Controls.Add(this.lbl_ApplicationCreatedBy);
            this.tp_ApplicationDetails.Controls.Add(this.lbl_Fees);
            this.tp_ApplicationDetails.Controls.Add(this.label6);
            this.tp_ApplicationDetails.Controls.Add(this.label5);
            this.tp_ApplicationDetails.Controls.Add(this.label4);
            this.tp_ApplicationDetails.Controls.Add(this.label3);
            this.tp_ApplicationDetails.Controls.Add(this.label2);
            this.tp_ApplicationDetails.Location = new System.Drawing.Point(4, 29);
            this.tp_ApplicationDetails.Name = "tp_ApplicationDetails";
            this.tp_ApplicationDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tp_ApplicationDetails.Size = new System.Drawing.Size(886, 442);
            this.tp_ApplicationDetails.TabIndex = 1;
            this.tp_ApplicationDetails.Text = "Application Details";
            this.tp_ApplicationDetails.UseVisualStyleBackColor = true;
            // 
            // cb_LicenseClass
            // 
            this.cb_LicenseClass.FormattingEnabled = true;
            this.cb_LicenseClass.Location = new System.Drawing.Point(278, 182);
            this.cb_LicenseClass.Name = "cb_LicenseClass";
            this.cb_LicenseClass.Size = new System.Drawing.Size(273, 28);
            this.cb_LicenseClass.TabIndex = 9;
            this.cb_LicenseClass.Validating += new System.ComponentModel.CancelEventHandler(this.cb_LicenseClass_Validating);
            // 
            // lbl_ApplicationDate
            // 
            this.lbl_ApplicationDate.AutoSize = true;
            this.lbl_ApplicationDate.Location = new System.Drawing.Point(278, 125);
            this.lbl_ApplicationDate.Name = "lbl_ApplicationDate";
            this.lbl_ApplicationDate.Size = new System.Drawing.Size(44, 20);
            this.lbl_ApplicationDate.TabIndex = 8;
            this.lbl_ApplicationDate.Text = "[???]";
            // 
            // lbl_AppicationID
            // 
            this.lbl_AppicationID.AutoSize = true;
            this.lbl_AppicationID.Location = new System.Drawing.Point(278, 68);
            this.lbl_AppicationID.Name = "lbl_AppicationID";
            this.lbl_AppicationID.Size = new System.Drawing.Size(44, 20);
            this.lbl_AppicationID.TabIndex = 7;
            this.lbl_AppicationID.Text = "[???]";
            // 
            // lbl_ApplicationCreatedBy
            // 
            this.lbl_ApplicationCreatedBy.AutoSize = true;
            this.lbl_ApplicationCreatedBy.Location = new System.Drawing.Point(278, 304);
            this.lbl_ApplicationCreatedBy.Name = "lbl_ApplicationCreatedBy";
            this.lbl_ApplicationCreatedBy.Size = new System.Drawing.Size(44, 20);
            this.lbl_ApplicationCreatedBy.TabIndex = 6;
            this.lbl_ApplicationCreatedBy.Text = "[???]";
            // 
            // lbl_Fees
            // 
            this.lbl_Fees.AutoSize = true;
            this.lbl_Fees.Location = new System.Drawing.Point(278, 247);
            this.lbl_Fees.Name = "lbl_Fees";
            this.lbl_Fees.Size = new System.Drawing.Size(44, 20);
            this.lbl_Fees.TabIndex = 5;
            this.lbl_Fees.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Application Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Created By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "License Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Application ID";
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(639, 565);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 59);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(753, 565);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 59);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ep_1
            // 
            this.ep_1.ContainerControl = this;
            // 
            // frm_AddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 649);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.tc_AddUpdateApplicationDetails);
            this.Controls.Add(this.lbl_Title);
            this.Name = "frm_AddUpdateLocalDrivingLicenseApplication";
            this.Text = "frm_AddLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frm_AddLocalDrivingLicenseApplication_Load);
            this.tc_AddUpdateApplicationDetails.ResumeLayout(false);
            this.tp_PersonalDetails.ResumeLayout(false);
            this.tp_ApplicationDetails.ResumeLayout(false);
            this.tp_ApplicationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TabControl tc_AddUpdateApplicationDetails;
        private System.Windows.Forms.TabPage tp_PersonalDetails;
        private System.Windows.Forms.TabPage tp_ApplicationDetails;
        private uc_PersonDetailsWithFilter uc_PersonDetails;
        private System.Windows.Forms.Label lbl_ApplicationDate;
        private System.Windows.Forms.Label lbl_AppicationID;
        private System.Windows.Forms.Label lbl_ApplicationCreatedBy;
        private System.Windows.Forms.Label lbl_Fees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_LicenseClass;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ErrorProvider ep_1;
    }
}