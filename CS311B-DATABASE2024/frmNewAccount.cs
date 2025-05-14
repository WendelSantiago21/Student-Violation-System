using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            if (txtpassword.Text.Length > 6)
            {
                errorProvider1.SetError(txtpassword, "Password should be at least 6 characters");
                errorcount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select user type");
                errorcount++;
            }
            try
            {
                DataTable dt = newaccount.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtusername, "Username already in user.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmNewAccount_Load(object sender, EventArgs e)
        {

        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked == true)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newaccount.executeSQL("INSERT INTO tblaccounts (username, password, usertype, status, createdby, datecreated) VALUES ('" + txtusername.Text +
                            "', '" + txtpassword.Text + "', '" + cmbtype.Text.ToUpper() + "', 'ACTIVE', '" + username + "' , '" + DateTime.Now.ToShortDateString() + "')");
                        if (newaccount.rowAffected > 0)
                        {
                            newaccount.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Add', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
                            MessageBox.Show("New account Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on Validating existing username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtpassword.Clear();
            txtusername.Clear();
            txtusername.Focus();
            cmbtype.SelectedIndex = -1;
        }
    }
}
