namespace DVLD_Project
{
    partial class FindPersonForm
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
            this.uc_PersonDetailsWithFilter1 = new DVLD_Project.uc_PersonDetailsWithFilter();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(330, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fine Person";
            // 
            // uc_PersonDetailsWithFilter1
            // 
            this.uc_PersonDetailsWithFilter1.Location = new System.Drawing.Point(97, 82);
            this.uc_PersonDetailsWithFilter1.Name = "uc_PersonDetailsWithFilter1";
            this.uc_PersonDetailsWithFilter1.Size = new System.Drawing.Size(699, 421);
            this.uc_PersonDetailsWithFilter1.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(721, 524);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 52);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FindPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 597);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.uc_PersonDetailsWithFilter1);
            this.Controls.Add(this.label1);
            this.Name = "FindPersonForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private uc_PersonDetailsWithFilter uc_PersonDetailsWithFilter1;
        private System.Windows.Forms.Button btn_Close;
    }
}