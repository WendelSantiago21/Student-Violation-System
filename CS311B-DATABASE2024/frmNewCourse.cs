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
    public partial class frmNewCourse : Form
    {
        private string coursecode;
        public frmNewCourse(string coursecode)
        {
            InitializeComponent();
            this.coursecode = coursecode;
        }
        private int errorcount;
        Class1 newcourse = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
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
            try
            {
                DataTable dt = newcourse.GetData("SELECT * FROM tblcourse WHERE coursecode = '" + txtcoursecode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtcoursecode, "Course already exist.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing course d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newcourse.executeSQL("INSERT INTO tblcourse (coursecode, description, datecreated, createdby) VALUES ('" + txtcoursecode.Text +
                            "', '" + txtdescription.Text + "', '" + coursecode + "' , '" + DateTime.Now.ToShortDateString() + "')");
                        if (newcourse.rowAffected > 0)
                        {
                            newcourse.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Add', 'Course Management', '" + txtcoursecode.Text + "', '" + coursecode + "')");
                            MessageBox.Show("New Course Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtcoursecode.Clear();
            txtdescription.Clear();
            txtcoursecode.Focus();
        }
    }
}
