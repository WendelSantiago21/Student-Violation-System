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
    public partial class frmUpdateCourse : Form
    {
        private string coursecode, editcoursecode, editdescription;
        public string SelectedCourse { get; set; }

        private void frmUpdateCourse_Load(object sender, EventArgs e)
        {
            txtcoursecode.Text = editcoursecode;
            txtdescription.Text = editdescription;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatecourse.executeSQL("UPDATE tblcourse SET coursecode = '" + txtcoursecode.Text + "', description = '" + txtdescription.Text +
                            "' WHERE coursecode = '" + txtcoursecode.Text + "'");
                        if (updatecourse.rowAffected > 0)
                        {
                            updatecourse.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Course Management', '" + txtcoursecode.Text + "', '" + coursecode + "')");
                            MessageBox.Show("Course Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private int errorcount;
        Class1 updatecourse = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtcoursecode.Text))
            {
                errorProvider1.SetError(txtcoursecode, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Input is empty");
                errorcount++;
            }
        }

        public frmUpdateCourse(string editcoursecode, string editdescription, string coursecode)
        {
            InitializeComponent();
            this.coursecode = coursecode;
            this.editcoursecode = editcoursecode;
            this.editdescription = editdescription;
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtdescription.Clear();
            txtdescription.Focus();
        }
    }
}
