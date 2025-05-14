using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311B_DATABASE2024
{
    public partial class frmUpdateAccount : Form
    {
        private string username, editusername, editpassword, edittype, editstatus;
        private int errorcount;
        Class1 updateaccount = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
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
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select status");
                errorcount++;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updateaccount.executeSQL("UPDATE tblaccounts SET password = '" + txtpassword.Text + "', usertype = '" + cmbtype.Text.ToUpper() + "', status = '" + cmbstatus.Text.ToUpper() +
                            "' WHERE username = '" + txtusername.Text + "'");
                        if (updateaccount.rowAffected > 0)
                        {
                            updateaccount.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
                            MessageBox.Show("Account Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            errorProvider1.Clear();
            txtpassword.Clear();
            cmbstatus.SelectedIndex = -1;
            cmbtype.SelectedIndex = -1;
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

        public frmUpdateAccount(string editusername, string editpassword, string edittype, string editstatus, string username)
        {
            InitializeComponent();
            this.username = username;
            this.editusername = editusername;
            this.editpassword = editpassword;
            this.edittype = edittype;
            this.editstatus = editstatus;
        }

        private void frmUpdateAccount_Load(object sender, EventArgs e)
        {
            txtusername.Text = editusername;
            txtpassword.Text = editpassword;
            if (edittype == "ADMINISTRATOR")
            {
                cmbtype.SelectedIndex = 0;
            }
            else if (edittype == "BRANCHADMIN")
            {
                cmbtype.SelectedIndex = 1;
            }
            else
            {
                cmbtype.SelectedIndex = 2;
            }
            if (editstatus == "ACTIVE")
            {
                cmbstatus.SelectedIndex = 0;
            }
            else
            {
                cmbstatus.SelectedIndex = 1;
            }
        }
    }
}
