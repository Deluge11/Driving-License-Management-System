namespace DVLD_Project.Tests.Controls
{
    partial class frmScheduleTest
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
            this.ucScheduleTestAppointment1 = new DVLD_Project.Tests.ScheduleTest.ucScheduleTestAppointment();
            this.SuspendLayout();
            // 
            // ucScheduleTestAppointment1
            // 
            this.ucScheduleTestAppointment1.Location = new System.Drawing.Point(35, 2);
            this.ucScheduleTestAppointment1.Name = "ucScheduleTestAppointment1";
            this.ucScheduleTestAppointment1.Size = new System.Drawing.Size(477, 634);
            this.ucScheduleTestAppointment1.TabIndex = 0;
            this.ucScheduleTestAppointment1.TestTypeID = DVLD_Business.clsTestType.enTestType.Vision;
            this.ucScheduleTestAppointment1.Load += new System.EventHandler(this.ucScheduleTestAppointment1_Load);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 637);
            this.Controls.Add(this.ucScheduleTestAppointment1);
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScheduleTest.ucScheduleTestAppointment ucScheduleTestAppointment1;
    }
}