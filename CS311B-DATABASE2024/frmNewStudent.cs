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
    public partial class frmNewStudent : Form
    {
        private string studentID;
        public frmNewStudent(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }
        private int errorcount;
        Class1 newstudent = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtstudentid.Text))
            {
                errorProvider1.SetError(txtstudentid, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                errorProvider1.SetError(txtlastname, "Input is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(txtfirstname.Text))
            {
                errorProvider1.SetError(txtfirstname, "Input is empty");
                errorcount++;
            }
            if (cmblevel.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmblevel, "Select a grade level");
                errorcount++;
            }
            if ((cmblevel.SelectedItem?.ToString() != "Elementary" && cmblevel.SelectedItem?.ToString() != "Junior High") &&
                cmbcourse.SelectedIndex < 1)
            {
                errorProvider1.SetError(cmbcourse, "Select a course/strand");
                errorcount++;
            }
            try
            {
                DataTable dt = newstudent.GetData("SELECT * FROM tblstudents WHERE studentID = '" + txtstudentid.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtstudentid, "Student ID already exist.");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing student d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {

                DialogResult dr = MessageBox.Show("Are you sure you want to Add this Student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    // Get the selected course or strand code
                    string selectedCourseCode = cmbcourse.SelectedValue?.ToString(); // Using ?. to avoid null reference exception

                    // Insert the new student into the database, using the course/strand code
                    newstudent.executeSQL("INSERT INTO tblstudents (studentID, lastname, firstname, middlename, level, course, createdby, datecreated) VALUES ('" +
                        txtstudentid.Text + "', '" + txtlastname.Text + "', '" + txtfirstname.Text + "', '" + txtmiddlename.Text + "', '" + cmblevel.Text + "', '" + selectedCourseCode + "', '" +
                        studentID + "', '" + DateTime.Now.ToShortDateString() + "')");

                    if (newstudent.rowAffected > 0)
                    {
                        // Log the action
                        newstudent.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" +
                            DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "', 'Add', 'Students Management', '" +
                            txtstudentid.Text + "', '" + studentID + "')");
                        MessageBox.Show("New Student Successfully Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the Student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtstudentid.Clear();
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmiddlename.Clear();
            cmbcourse.Enabled = false;
            cmbcourse.Text = "";
            cmbcourse.SelectedIndex = -1;
            cmblevel.SelectedIndex = -1;
            txtstudentid.Focus();
        }

        private void cmblevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbcourse.DataSource = null;
            cmbcourse.Items.Clear();

            if (cmblevel.SelectedItem != null)
            {
                if (cmblevel.SelectedItem.ToString() == "Elementary" || cmblevel.SelectedItem.ToString() == "Junior High")
                {
                    cmbcourse.Items.Add("N/A");
                    cmbcourse.SelectedIndex = 0;
                    cmbcourse.Enabled = false;
                }
                else if (cmblevel.SelectedItem.ToString() == "Senior High")
                {

                    // Load strands and add placeholder
                    DataTable dtStrands = newstudent.GetData("SELECT strandcode AS Code, description FROM tblstrands");

                    // Insert a placeholder row at the top of the DataTable
                    DataRow newRow = dtStrands.NewRow();
                    newRow["Code"] = DBNull.Value;
                    newRow["description"] = "Select a strand";
                    dtStrands.Rows.InsertAt(newRow, 0);

                    // Bind the ComboBox
                    cmbcourse.DataSource = dtStrands;
                    cmbcourse.DisplayMember = "description";
                    cmbcourse.ValueMember = "Code";
                    cmbcourse.SelectedIndex = 0; // Select the placeholder
                    cmbcourse.Enabled = true;
                }
                else if (cmblevel.SelectedItem.ToString() == "College")
                {
                    // Load courses and add placeholder
                    DataTable dtCourses = newstudent.GetData("SELECT coursecode AS Code, description FROM tblcourse");

                    // Insert a placeholder row at the top of the DataTable
                    DataRow newRow = dtCourses.NewRow();
                    newRow["Code"] = DBNull.Value;
                    newRow["description"] = "Select a course";
                    dtCourses.Rows.InsertAt(newRow, 0);

                    // Bind the ComboBox
                    cmbcourse.DataSource = dtCourses;
                    cmbcourse.DisplayMember = "description";
                    cmbcourse.ValueMember = "Code";
                    cmbcourse.SelectedIndex = 0; // Select the placeholder
                    cmbcourse.Enabled = true;
                }
            }
        }
    }
}
