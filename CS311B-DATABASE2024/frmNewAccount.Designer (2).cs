namespace CS311B_DATABASE2024
{
    partial class frmNewAccount
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtusernames = new System.Windows.Forms.TextBox();
            this.txtpasswords = new System.Windows.Forms.TextBox();
            this.cmbtypes = new System.Windows.Forms.ComboBox();
            this.btnsaves = new System.Windows.Forms.Button();
            this.btnclears = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Usertype:";
            // 
            // txtusernames
            // 
            this.txtusernames.Location = new System.Drawing.Point(105, 51);
            this.txtusernames.Name = "txtusernames";
            this.txtusernames.Size = new System.Drawing.Size(167, 20);
            this.txtusernames.TabIndex = 3;
            // 
            // txtpasswords
            // 
            this.txtpasswords.Location = new System.Drawing.Point(105, 84);
            this.txtpasswords.Name = "txtpasswords";
            this.txtpasswords.Size = new System.Drawing.Size(167, 20);
            this.txtpasswords.TabIndex = 4;
            // 
            // cmbtypes
            // 
            this.cmbtypes.FormattingEnabled = true;
            this.cmbtypes.Items.AddRange(new object[] {
            "admin",
            "branchadmin",
            "staff"});
            this.cmbtypes.Location = new System.Drawing.Point(105, 122);
            this.cmbtypes.Name = "cmbtypes";
            this.cmbtypes.Size = new System.Drawing.Size(167, 21);
            this.cmbtypes.TabIndex = 5;
            // 
            // btnsaves
            // 
            this.btnsaves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsaves.Location = new System.Drawing.Point(105, 177);
            this.btnsaves.Name = "btnsaves";
            this.btnsaves.Size = new System.Drawing.Size(75, 23);
            this.btnsaves.TabIndex = 6;
            this.btnsaves.Text = "&Save";
            this.btnsaves.UseVisualStyleBackColor = true;
            this.btnsaves.Click += new System.EventHandler(this.btnsaves_Click);
            // 
            // btnclears
            // 
            this.btnclears.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclears.Location = new System.Drawing.Point(197, 177);
            this.btnclears.Name = "btnclears";
            this.btnclears.Size = new System.Drawing.Size(75, 23);
            this.btnclears.TabIndex = 7;
            this.btnclears.Text = "&Clear";
            this.btnclears.UseVisualStyleBackColor = true;
            // 
            // frmNewAccount
            // 
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.btnclears);
            this.Controls.Add(this.btnsaves);
            this.Controls.Add(this.cmbtypes);
            this.Controls.Add(this.txtpasswords);
            this.Controls.Add(this.txtusernames);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbshow;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtusernames;
        private System.Windows.Forms.TextBox txtpasswords;
        private System.Windows.Forms.ComboBox cmbtypes;
        private System.Windows.Forms.Button btnsaves;
        private System.Windows.Forms.Button btnclears;
    }
}