namespace CS311B_DATABASE2024
{
    partial class frmNewStudent
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cmblevel = new System.Windows.Forms.ComboBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.txtstudentid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmiddlename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbcourse = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 60);
            this.label4.TabIndex = 22;
            this.label4.Text = "         ADD\r\nNEW STUDENT";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(32)))), ((int)(((byte)(11)))));
            this.btnreset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(59, 449);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(214, 35);
            this.btnreset.TabIndex = 20;
            this.btnreset.Text = "&CLEAR";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(94)))), ((int)(((byte)(7)))));
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(59, 408);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(214, 35);
            this.btnsave.TabIndex = 19;
            this.btnsave.Text = "&SAVE";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
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
            this.cmblevel.Location = new System.Drawing.Point(59, 315);
            this.cmblevel.Name = "cmblevel";
            this.cmblevel.Size = new System.Drawing.Size(214, 24);
            this.cmblevel.TabIndex = 17;
            this.cmblevel.SelectedIndexChanged += new System.EventHandler(this.cmblevel_SelectedIndexChanged);
            // 
            // txtlastname
            // 
            this.txtlastname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtlastname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastname.Location = new System.Drawing.Point(59, 183);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(214, 22);
            this.txtlastname.TabIndex = 16;
            // 
            // txtstudentid
            // 
            this.txtstudentid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtstudentid.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstudentid.Location = new System.Drawing.Point(59, 139);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(214, 22);
            this.txtstudentid.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Student ID";
            // 
            // txtfirstname
            // 
            this.txtfirstname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtfirstname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfirstname.Location = new System.Drawing.Point(59, 227);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(214, 22);
            this.txtfirstname.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Middle Name (Optional)";
            // 
            // txtmiddlename
            // 
            this.txtmiddlename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtmiddlename.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmiddlename.Location = new System.Drawing.Point(59, 271);
            this.txtmiddlename.Name = "txtmiddlename";
            this.txtmiddlename.Size = new System.Drawing.Size(214, 22);
            this.txtmiddlename.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Course / Strand";
            // 
            // cmbcourse
            // 
            this.cmbcourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbcourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcourse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcourse.FormattingEnabled = true;
            this.cmbcourse.Items.AddRange(new object[] {
            "Select Course / Strand",
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
            this.cmbcourse.Location = new System.Drawing.Point(59, 361);
            this.cmbcourse.Name = "cmbcourse";
            this.cmbcourse.Size = new System.Drawing.Size(214, 24);
            this.cmbcourse.TabIndex = 28;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            this.panel1.BackgroundImage = global::CS311B_DATABASE2024.Properties.Resources._26810399_7205793;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(342, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 568);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(244)))), ((int)(((byte)(238)))));
            this.panel2.Location = new System.Drawing.Point(342, -7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 51);
            this.panel2.TabIndex = 29;
            // 
            // frmNewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 531);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbcourse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmiddlename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cmblevel);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtstudentid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNewStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Student";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox cmblevel;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtstudentid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmiddlename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbcourse;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
    }
}