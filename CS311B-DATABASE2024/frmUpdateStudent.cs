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
    public partial class frmUpdateStudent : Form
    {
        private string studentID, editstudentid, editlastname, editfirstname, editmiddlename, editlevel, editcourse;

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmiddlename.Clear();
            cmbcourse.Enabled = false;
            cmbcourse.Text = "";
            cmblevel.SelectedIndex = -1;
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
                    DataTable dtStrands = updatestudent.GetData("SELECT strandcode AS Code, description FROM tblstrands");

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
                    DataTable dtCourses = updatestudent.GetData("SELECT coursecode AS Code, description FROM tblcourse");

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

        private void frmUpdateStudent_Load(object sender, EventArgs e)
        {
            txtstudentid.Text = editstudentid;
            txtlastname.Text = editlastname;
            txtfirstname.Text = editfirstname;
            txtmiddlename.Text = editmiddlename;
            cmblevel.SelectedItem = editlevel;
            cmbcourse.SelectedItem = editcourse;

            cmblevel_SelectedIndexChanged(null, null);

            // Set the previously selected course/strand if applicable
            if (!string.IsNullOrEmpty(editcourse))
            {
                cmbcourse.SelectedValue = editcourse;
            }
        }

        public frmUpdateStudent(string editstudentid, string editlastname, string editfirstname, string editmiddlename, string editlevel, string editcourse, string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.editstudentid = editstudentid;
            this.editlastname = editlastname;
            this.editfirstname = editfirstname;
            this.editmiddlename = editmiddlename;
            this.editlevel = editlevel;
            this.editcourse = editcourse;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatestudent.executeSQL("UPDATE tblstudents SET lastname = '" + txtlastname.Text + "', firstname = '" + txtfirstname.Text + "', middlename = '" + txtmiddlename.Text + 
                            "',  level = '" + cmblevel.Text + "', course = '" + cmbcourse.SelectedValue?.ToString() +
                            "' WHERE studentID = '" + txtstudentid.Text + "'");
                        if (updatestudent.rowAffected > 0)
                        {
                            updatestudent.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                "', 'Update', 'Students Management', '" + txtstudentid.Text + "', '" + studentID + "')");
                            MessageBox.Show("Student Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        Class1 updatestudent = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void validateForm()
        {
            errorcount = 0;
            errorProvider1.Clear();
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
        }
    }
}
