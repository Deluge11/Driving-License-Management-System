namespace DVLD_Project
{
    partial class uc_PersonDetailsWithFilter
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
            this.uc_PersonDetails = new DVLD_Project.uc_PersonDetails();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddPerson = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uc_PersonDetails
            // 
            this.uc_PersonDetails.Location = new System.Drawing.Point(3, 78);
            this.uc_PersonDetails.Name = "uc_PersonDetails";
            this.uc_PersonDetails.Size = new System.Drawing.Size(685, 340);
            this.uc_PersonDetails.TabIndex = 0;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(84, 37);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 28);
            this.cbFilterBy.TabIndex = 1;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By";
            // 
            // btn_AddPerson
            // 
            this.btn_AddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddPerson.Image = global::DVLD_Project.Properties.Resources.Add_Person_72;
            this.btn_AddPerson.Location = new System.Drawing.Point(564, 26);
            this.btn_AddPerson.Name = "btn_AddPerson";
            this.btn_AddPerson.Size = new System.Drawing.Size(69, 51);
            this.btn_AddPerson.TabIndex = 4;
            this.btn_AddPerson.UseVisualStyleBackColor = true;
            this.btn_AddPerson.Click += new System.EventHandler(this.btn_AddPerson_Click);
            // 
            // button2
            // 
            this.button2.Image = global::DVLD_Project.Properties.Resources.SearchPerson;
            this.button2.Location = new System.Drawing.Point(335, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 42);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uc_PersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_AddPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.uc_PersonDetails);
            this.Name = "uc_PersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(699, 421);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uc_PersonDetails uc_PersonDetails;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddPerson;
        private System.Windows.Forms.Button button2;
    }
}
