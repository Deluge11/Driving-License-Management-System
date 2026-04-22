namespace DVLD_Project
{
    partial class uc_PersonDetails
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_PersonDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_personimage = new System.Windows.Forms.PictureBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_personId = new System.Windows.Forms.Label();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.lbl_nationalno = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_country = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ll_EditPerson = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_personimage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "National No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Country";
            // 
            // pb_personimage
            // 
            this.pb_personimage.Image = global::DVLD_Project.Properties.Resources.Male_512;
            this.pb_personimage.Location = new System.Drawing.Point(495, 123);
            this.pb_personimage.Name = "pb_personimage";
            this.pb_personimage.Size = new System.Drawing.Size(155, 137);
            this.pb_personimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_personimage.TabIndex = 9;
            this.pb_personimage.TabStop = false;
            this.pb_personimage.Click += new System.EventHandler(this.pb_personimage_Click);
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(377, 133);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(36, 20);
            this.lbl_date.TabIndex = 10;
            this.lbl_date.Text = "???";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(167, 287);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(36, 20);
            this.lbl_address.TabIndex = 11;
            this.lbl_address.Text = "???";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(167, 240);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(36, 20);
            this.lbl_email.TabIndex = 12;
            this.lbl_email.Text = "???";
            // 
            // lbl_personId
            // 
            this.lbl_personId.AutoSize = true;
            this.lbl_personId.Location = new System.Drawing.Point(167, 36);
            this.lbl_personId.Name = "lbl_personId";
            this.lbl_personId.Size = new System.Drawing.Size(35, 20);
            this.lbl_personId.TabIndex = 13;
            this.lbl_personId.Text = "N/A";
            // 
            // lbl_gender
            // 
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Location = new System.Drawing.Point(167, 186);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(36, 20);
            this.lbl_gender.TabIndex = 14;
            this.lbl_gender.Text = "???";
            this.lbl_gender.Click += new System.EventHandler(this.lbl_gender_Click);
            // 
            // lbl_nationalno
            // 
            this.lbl_nationalno.AutoSize = true;
            this.lbl_nationalno.Location = new System.Drawing.Point(167, 133);
            this.lbl_nationalno.Name = "lbl_nationalno";
            this.lbl_nationalno.Size = new System.Drawing.Size(36, 20);
            this.lbl_nationalno.TabIndex = 15;
            this.lbl_nationalno.Text = "???";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(167, 80);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(36, 20);
            this.lbl_name.TabIndex = 16;
            this.lbl_name.Text = "???";
            this.lbl_name.Click += new System.EventHandler(this.lbl_name_Click);
            // 
            // lbl_country
            // 
            this.lbl_country.AutoSize = true;
            this.lbl_country.Location = new System.Drawing.Point(377, 240);
            this.lbl_country.Name = "lbl_country";
            this.lbl_country.Size = new System.Drawing.Size(36, 20);
            this.lbl_country.TabIndex = 17;
            this.lbl_country.Text = "???";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(377, 186);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(36, 20);
            this.lbl_phone.TabIndex = 18;
            this.lbl_phone.Text = "???";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Male.png");
            this.imageList1.Images.SetKeyName(1, "Female.png");
            // 
            // ll_EditPerson
            // 
            this.ll_EditPerson.AutoSize = true;
            this.ll_EditPerson.Location = new System.Drawing.Point(524, 80);
            this.ll_EditPerson.Name = "ll_EditPerson";
            this.ll_EditPerson.Size = new System.Drawing.Size(91, 20);
            this.ll_EditPerson.TabIndex = 19;
            this.ll_EditPerson.TabStop = true;
            this.ll_EditPerson.Text = "Edit Person";
            this.ll_EditPerson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_EditPerson_LinkClicked);
            // 
            // uc_PersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ll_EditPerson);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.lbl_country);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_nationalno);
            this.Controls.Add(this.lbl_gender);
            this.Controls.Add(this.lbl_personId);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.pb_personimage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "uc_PersonDetails";
            this.Size = new System.Drawing.Size(683, 338);
            this.Load += new System.EventHandler(this.uc_PersonDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_personimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pb_personimage;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_personId;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.Label lbl_nationalno;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_country;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.LinkLabel ll_EditPerson;
    }
}
