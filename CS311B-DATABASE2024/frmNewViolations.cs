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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311B_DATABASE2024
{
    public partial class frmNewViolations : Form
    {
        private string code;
        public frmNewViolations(string code)
        {
            InitializeComponent();
            this.code = code;
        }
        private int errorcount;
        Class1 newviolations = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtcode.Text))
            {
                errorProvider1.SetError(txtcode, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Input is empty");
                errorcount++;
            }
            if (cmbviolationtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbviolationtype, "Select a violation type");
                errorcount++;
            }
            try
            {
                DataTable dt = newviolations.GetData("SELECT * FROM tblviolations WHERE code = '" + txtcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtcode, "Violation already exist.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing violations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newviolations.executeSQL("INSERT INTO tblviolations (code, description, violationtype, status, createdby, datecreated) VALUES ('" + txtcode.Text +
                            "', '" + txtdescription.Text + "', '" + cmbviolationtype.Text.ToUpper() + "', 'ACTIVE', '" + code + "' , '" + DateTime.Now.ToShortDateString() + "')");
                        if (newviolations.rowAffected > 0)
                        {
                            newviolations.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Add', 'Violations Management', '" + txtcode.Text + "', '" + code + "')");
                            MessageBox.Show("New Violation Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on Validating existing violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtdescription.Clear();
            txtcode.Clear();
            txtcode.Focus();
        }
    }
}
