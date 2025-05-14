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
    public partial class frmUpdateStrand : Form
    {
        private string strandcode, editstrandcode, editdescription;
        public string SelectedCourse { get; set; }
        private int errorcount;
        public frmUpdateStrand(string editcourse, string editdescription, string strandcode)
        {
            InitializeComponent();
            this.editstrandcode = editcourse;
            this.strandcode = strandcode;
            this.editdescription = editdescription;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtdescription.Clear();
            txtdescription.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatestrand.executeSQL("UPDATE tblstrands SET strandcode = '" + txtstrandcode.Text + "', description = '" + txtdescription.Text +
                            "' WHERE strandcode = '" + txtstrandcode.Text + "'");
                        if (updatestrand.rowAffected > 0)
                        {
                            updatestrand.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Strand Management', '" + txtstrandcode.Text + "', '" + strandcode + "')");
                            MessageBox.Show("Strand Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Input is empty");
                errorcount++;
            }

        }

        private void frmUpdateStrand_Load(object sender, EventArgs e)
        {
            txtstrandcode.Text = editstrandcode;
            txtdescription.Text = editdescription;
        }

        Class1 updatestrand = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        
    }
}
