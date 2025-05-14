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
    public partial class frmCourse : Form
    {

        private string coursecode;
        public frmCourse(string coursecode)
        {
            InitializeComponent();
            this.coursecode = coursecode;
        }
        Class1 course = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");

        private void frmCourse_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = course.GetData("SELECT coursecode, description, datecreated, createdby FROM tblcourse WHERE coursecode <> '" + coursecode +
                    "' ORDER BY coursecode DESC");
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["description"].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on course load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewCourse newcourseform = new frmNewCourse(coursecode);
            newcourseform.FormClosed += (s, args) => frmCourse_Load(this, EventArgs.Empty);
            newcourseform.Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = course.GetData("SELECT coursecode, description, datecreated, createdby FROM tblcourse WHERE coursecode <> '"
                    + coursecode + "' AND (coursecode LIKE '%" + txtsearch.Text + "%' OR description LIKE '%" + txtsearch.Text + "%' OR createdby LIKE '%" + txtsearch.Text + "%') ORDER BY coursecode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on course search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmCourse_Load(sender, e);
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
            DialogResult dr = MessageBox.Show("Are you sure you want to remove this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    course.executeSQL("DELETE FROM tblcourse WHERE coursecode = '" + selectedUser + "'");
                    if (course.rowAffected > 0)
                    {
                        course.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                    "', 'Delete', 'Course Management', '" + selectedUser + "', '" + coursecode + "')");
                        MessageBox.Show("Course Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmCourse_Load(sender, e);
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
            string editcoursecode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            frmUpdateCourse updatecoursefrm = new frmUpdateCourse(editcoursecode, editdescription, coursecode);
            updatecoursefrm.FormClosed += (s, args) => frmCourse_Load(this, EventArgs.Empty);
            updatecoursefrm.Show();
        }
    }
}
