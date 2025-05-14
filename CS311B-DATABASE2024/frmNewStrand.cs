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
    public partial class frmNewStrand : Form
    {
        string strandcode;
        public frmNewStrand(string strandcode)
        {
            InitializeComponent();
            this.strandcode = strandcode;
        }
        private int errorcount;
        Class1 newstrand = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtstrandcode.Text))
            {
                errorProvider1.SetError(txtstrandcode, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Input is empty");
                errorcount++;
            }
            try
            {
                DataTable dt = newstrand.GetData("SELECT * FROM tblstrands WHERE strandcode = '" + txtstrandcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtstrandcode, "Strand already exist.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing strand d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newstrand.executeSQL("INSERT INTO tblstrands (strandcode, description, datecreated, createdby) VALUES ('" + txtstrandcode.Text +
                            "', '" + txtdescription.Text + "', '" + DateTime.Now.ToShortDateString() + "' , '" + strandcode + "')");
                        if (newstrand.rowAffected > 0)
                        {
                            newstrand.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Add', 'Strand Management', '" + txtstrandcode.Text + "', '" + strandcode + "')");
                            MessageBox.Show("New Strand Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on Validating existing student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtstrandcode.Clear();
            txtdescription.Clear();
            txtstrandcode.Focus();
        }
    }
}
