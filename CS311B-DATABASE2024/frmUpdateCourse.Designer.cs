namespace CS311B_DATABASE2024
{
    partial class frmUpdateCourse
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
            this.txtcoursecode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcoursecode
            // 
            this.txtcoursecode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtcoursecode.Enabled = false;
            this.txtcoursecode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcoursecode.Location = new System.Drawing.Point(480, 224);
            this.txtcoursecode.Name = "txtcoursecode";
            this.txtcoursecode.Size = new System.Drawing.Size(205, 22);
            this.txtcoursecode.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(483, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(483, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "Course Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(496, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 60);
            this.label5.TabIndex = 51;
            this.label5.Text = "       UPDATE\r\n YOUR COURSE";
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(38)))), ((int)(((byte)(80)))));
            this.btnreset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(480, 362);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(205, 35);
            this.btnreset.TabIndex = 49;
            this.btnreset.Text = "&CLEAR";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(119)))), ((int)(((byte)(236)))));
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(480, 321);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(205, 35);
            this.btnsave.TabIndex = 48;
            this.btnsave.Text = "&SAVE";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtdescription
            // 
            this.txtdescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtdescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription.Location = new System.Drawing.Point(480, 268);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(205, 22);
            this.txtdescription.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.BackgroundImage = global::CS311B_DATABASE2024.Properties.Resources.file;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(-21, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 569);
            this.panel1.TabIndex = 50;
            // 
            // frmUpdateCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(57)))), ((int)(((byte)(118)))));
            this.ClientSize = new System.Drawing.Size(756, 555);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txtcoursecode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUpdateCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Course";
            this.Load += new System.EventHandler(this.frmUpdateCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtcoursecode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtdescription;
    }
}