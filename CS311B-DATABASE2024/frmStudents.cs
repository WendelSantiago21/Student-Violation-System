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
    public partial class frmStudents : Form
    {
        private string studentID;
        public frmStudents(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }
        Class1 students = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");

        private void frmStudents_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, course, createdby, datecreated FROM tblstudents WHERE studentID <> '" + studentID +
                    "' ORDER BY studentID DESC");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewStudent newstudentform = new frmNewStudent(studentID);
            newstudentform.FormClosed += (s, args) => frmStudents_Load(this, EventArgs.Empty);
            newstudentform.Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, course, createdby, datecreated FROM tblstudents WHERE studentID <> '"
                    + studentID + "' AND (studentID LIKE '%" + txtsearch.Text + "%' OR lastname LIKE '%" + txtsearch.Text + "%' OR course LIKE '%" + txtsearch.Text + "%') ORDER BY studentID");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmStudents_Load(sender, e);
        }
        private int row;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = (int)e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on datagrid cellclick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to remove this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    students.executeSQL("DELETE FROM tblstudents WHERE studentID = '" + selectedUser + "'");
                    if (students.rowAffected > 0)
                    {
                        students.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                    "', 'Delete', 'Students Management', '" + selectedUser + "', '" + studentID + "')");
                        MessageBox.Show("Student Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmStudents_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string editstudentid = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editlastname = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editfirstname = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editmiddlename = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string editlevel = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string editcourse = dataGridView1.Rows[row].Cells[5].Value.ToString();
            frmUpdateStudent updatestudentfrm = new frmUpdateStudent(editstudentid, editlastname, editfirstname, editmiddlename, editlevel, editcourse, studentID);
            updatestudentfrm.FormClosed += (s, args) => frmStudents_Load(this, EventArgs.Empty);
            updatestudentfrm.Show();
        }
        private void btncourse_Click(object sender, EventArgs e)
        {
            frmCourse courseform = new frmCourse(studentID);
            courseform.Show();
        }

        private void btnstrand_Click(object sender, EventArgs e)
        {
            frmStrand strandform = new frmStrand(studentID);
            strandform.Show();
        }
    }
}
