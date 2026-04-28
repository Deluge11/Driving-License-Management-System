namespace DVLD_Project.ApplicationTypes
{
    partial class frm_EditApplicationType
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ApplicationTypeID = new System.Windows.Forms.Label();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.tb_Fees = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fees";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_ApplicationTypeID
            // 
            this.lbl_ApplicationTypeID.AutoSize = true;
            this.lbl_ApplicationTypeID.Location = new System.Drawing.Point(220, 62);
            this.lbl_ApplicationTypeID.Name = "lbl_ApplicationTypeID";
            this.lbl_ApplicationTypeID.Size = new System.Drawing.Size(36, 20);
            this.lbl_ApplicationTypeID.TabIndex = 3;
            this.lbl_ApplicationTypeID.Text = "???";
            this.lbl_ApplicationTypeID.Click += new System.EventHandler(this.lbl_ApplicationTypeID_Click);
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(197, 126);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(100, 26);
            this.tb_Title.TabIndex = 4;
            this.tb_Title.TextChanged += new System.EventHandler(this.tb_Title_TextChanged);
            // 
            // tb_Fees
            // 
            this.tb_Fees.Location = new System.Drawing.Point(197, 182);
            this.tb_Fees.Name = "tb_Fees";
            this.tb_Fees.Size = new System.Drawing.Size(100, 26);
            this.tb_Fees.TabIndex = 5;
            this.tb_Fees.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_EdtiApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_Fees);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.lbl_ApplicationTypeID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_EdtiApplicationType";
            this.Text = "frm_EdtiApplicationType";
            this.Load += new System.EventHandler(this.frm_EdtiApplicationType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ApplicationTypeID;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.TextBox tb_Fees;
        private System.Windows.Forms.Button button1;
    }
}