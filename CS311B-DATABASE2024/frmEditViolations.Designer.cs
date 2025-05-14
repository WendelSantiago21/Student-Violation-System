namespace CS311B_DATABASE2024
{
    partial class frmEditViolations
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
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbviolationtype = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 60);
            this.label5.TabIndex = 35;
            this.label5.Text = "  EDIT THE \r\nVIOLATION";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(85)))), ((int)(((byte)(123)))));
            this.btnreset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(50, 356);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(167, 35);
            this.btnreset.TabIndex = 31;
            this.btnreset.Text = "&CLEAR";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(50, 315);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(167, 35);
            this.btnsave.TabIndex = 30;
            this.btnsave.Text = "&SAVE";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cmbstatus
            // 
            this.cmbstatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbstatus.Location = new System.Drawing.Point(50, 221);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(167, 24);
            this.cmbstatus.TabIndex = 28;
            // 
            // txtdescription
            // 
            this.txtdescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtdescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription.Location = new System.Drawing.Point(50, 177);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(167, 22);
            this.txtdescription.TabIndex = 27;
            // 
            // txtcode
            // 
            this.txtcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtcode.Enabled = false;
            this.txtcode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(50, 133);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(167, 22);
            this.txtcode.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label3.Location = new System.Drawing.Point(53, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label2.Location = new System.Drawing.Point(53, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label1.Location = new System.Drawing.Point(53, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Code";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(183)))), ((int)(((byte)(234)))));
            this.panel1.BackgroundImage = global::CS311B_DATABASE2024.Properties.Resources.rb_63666;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(277, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 438);
            this.panel1.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label4.Location = new System.Drawing.Point(53, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Violation Type";
            // 
            // cmbviolationtype
            // 
            this.cmbviolationtype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbviolationtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbviolationtype.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbviolationtype.FormattingEnabled = true;
            this.cmbviolationtype.Items.AddRange(new object[] {
            "Minor Offense",
            "Major Offense"});
            this.cmbviolationtype.Location = new System.Drawing.Point(50, 267);
            this.cmbviolationtype.Name = "cmbviolationtype";
            this.cmbviolationtype.Size = new System.Drawing.Size(167, 24);
            this.cmbviolationtype.TabIndex = 36;
            // 
            // frmEditViolations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 423);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbviolationtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditViolations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Violations";
            this.Load += new System.EventHandler(this.frmEditViolations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbviolationtype;
    }
}