using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311B_DATABASE2024
{
    public partial class frmEditViolations : Form
    {
        private string code, editcode, editdescription, editviolationtype, editstatus;
        private int errorcount;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to edit this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        editviolations.executeSQL("UPDATE tblviolations SET description = '" + txtdescription.Text + "', violationtype = '" + cmbviolationtype.Text.ToUpper() + "', status = '" + cmbstatus.Text.ToUpper() +
                            "' WHERE code = '" + txtcode.Text + "'");
                        if (editviolations.rowAffected > 0)
                        {
                            editviolations.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Violations Management', '" + txtcode.Text + "', '" + code + "')");
                            MessageBox.Show("Violation has been Edited", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtdescription.Clear();
            txtdescription.Focus();
            errorProvider1.Clear();
            cmbstatus.SelectedIndex = -1;
            cmbviolationtype.SelectedIndex = -1;
        }

        private void frmEditViolations_Load(object sender, EventArgs e)
        {
            txtcode.Text = editcode;
            txtdescription.Text = editdescription;
            if (editstatus == "ACTIVE")
            {
                cmbstatus.SelectedIndex = 0;
            }
            else
            {
                cmbstatus.SelectedIndex = 1;
            }
            if (editviolationtype == "MINOR OFFENSE")
            {
                cmbviolationtype.SelectedIndex = 0;
            }
            else
            {
                cmbviolationtype.SelectedIndex = 1;
            }
        }

        Class1 editviolations = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Input is empty");
                errorcount++;
            }
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select status");
                errorcount++;
            }
            if (cmbviolationtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbviolationtype, "Select a violation type");
                errorcount++;
            }
        }
        public frmEditViolations(string editcode, string editdescription, string editviolationtype, string editstatus, string code)
        {
            InitializeComponent();
            this.editcode = editcode;
            this.editdescription = editdescription;
            this.editviolationtype = editviolationtype;
            this.editstatus = editstatus;
            this.code = code;
        }
    }
}