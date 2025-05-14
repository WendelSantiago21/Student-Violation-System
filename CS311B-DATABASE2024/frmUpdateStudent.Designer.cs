namespace CS311B_DATABASE2024
{
    partial class frmUpdateStudent
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cmbcourse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmiddlename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.cmblevel = new System.Windows.Forms.ComboBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.txtstudentid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 60);
            this.label5.TabIndex = 35;
            this.label5.Text = "       UPDATE\r\nYOUR STUDENT";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(114)))), ((int)(((byte)(110)))));
            this.btnreset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(58, 465);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(205, 35);
            this.btnreset.TabIndex = 31;
            this.btnreset.Text = "&CLEAR";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(5)))));
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(58, 424);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(205, 35);
            this.btnsave.TabIndex = 30;
            this.btnsave.Text = "&SAVE";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cmbcourse
            // 
            this.cmbcourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbcourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcourse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcourse.FormattingEnabled = true;
            this.cmbcourse.Items.AddRange(new object[] {
            "English, Political Science, Psychology & History",
            "Performing Arts (Dance)",
            "Criminology",
            "Accountancy",
            "Computer Science",
            "Business Administration",
            "Elementary Education",
            "Secondary Education",
            "Physical Education",
            "Library and Information Science",
            "Nursing",
            "Physical Therapy",
            "Radiologic Technology",
            "Medical Technology",
            "Pharmacy",
            "Psychology",
            "Midwifery",
            "Hospitality Management",
            "Tourism Management",
            "ABM",
            "GAS",
            "HUMSS",
            "STEM"});
            this.cmbcourse.Location = new System.Drawing.Point(58, 371);
            this.cmbcourse.Name = "cmbcourse";
            this.cmbcourse.Size = new System.Drawing.Size(205, 24);
            this.cmbcourse.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "Course / Strand";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "Level";
            // 
            // txtmiddlename
            // 
            this.txtmiddlename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtmiddlename.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmiddlename.Location = new System.Drawing.Point(58, 281);
            this.txtmiddlename.Name = "txtmiddlename";
            this.txtmiddlename.Size = new System.Drawing.Size(205, 22);
            this.txtmiddlename.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Middle Name (Optional)";
            // 
            // txtfirstname
            // 
            this.txtfirstname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtfirstname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfirstname.Location = new System.Drawing.Point(58, 237);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(205, 22);
            this.txtfirstname.TabIndex = 42;
            // 
            // cmblevel
            // 
            this.cmblevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmblevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblevel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblevel.FormattingEnabled = true;
            this.cmblevel.Items.AddRange(new object[] {
            "Elementary",
            "Junior High",
            "Senior High",
            "College"});
            this.cmblevel.Location = new System.Drawing.Point(58, 325);
            this.cmblevel.Name = "cmblevel";
            this.cmblevel.Size = new System.Drawing.Size(205, 24);
            this.cmblevel.TabIndex = 41;
            this.cmblevel.SelectedIndexChanged += new System.EventHandler(this.cmblevel_SelectedIndexChanged);
            // 
            // txtlastname
            // 
            this.txtlastname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtlastname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastname.Location = new System.Drawing.Point(58, 193);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(205, 22);
            this.txtlastname.TabIndex = 40;
            // 
            // txtstudentid
            // 
            this.txtstudentid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtstudentid.Enabled = false;
            this.txtstudentid.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstudentid.Location = new System.Drawing.Point(58, 149);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(205, 22);
            this.txtstudentid.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Student ID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(207)))));
            this.panel1.BackgroundImage = global::CS311B_DATABASE2024.Properties.Resources._4398922_2327605_removebg_preview;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(329, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 560);
            this.panel1.TabIndex = 34;
            // 
            // frmUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 555);
            this.Controls.Add(this.cmbcourse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmiddlename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.cmblevel);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtstudentid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUpdateStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Student";
            this.Load += new System.EventHandler(this.frmUpdateStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox cmbcourse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmiddlename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.ComboBox cmblevel;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtstudentid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}