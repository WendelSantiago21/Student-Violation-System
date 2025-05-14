using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311B_DATABASE2024
{
    public partial class frmNewAccount : Form
    {
        private string username;
        public frmNewAccount(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private int errorcount;
        Class1 newaccount = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Input is empty");
                errorcount++;
            }
            if (txtpassword.Text.Length < 6)
            {
                errorProvider1.SetError(txtpassword, "Password should be at least 6 characters");
                errorcount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select a user type");
                errorcount++;
            }
            try
            {
                DataTable dt = newaccount.GetData("SELECT * FROM tblaccounts WHERE username '" + txtusername.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtusername, "Username is alraady in use");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnsaves_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0) 
            {
                try
                {
                    newaccount.executeSQL("INSERT INTO tblaccounts (username, password, useertype, status, createdby, datecreated) VALUES ('" + txtusername.Text + "', '" 
                        + txtpassword.Text + "', '" + cmbtype.Text.ToUpper() + "', 'ACTIVE', " + username + "', '" + DateTime.Now.ToShortDateString() + "')'");
                    if (newaccount.rowAffected > 0)
                    {
                        MessageBox.Show("New Account Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error on save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

