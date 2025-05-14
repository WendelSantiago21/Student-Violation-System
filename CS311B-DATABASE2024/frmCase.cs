using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311B_DATABASE2024
{
    public partial class frmCase : Form
    {
        private string username,caseID;
        private int errorCount;
        public frmCase(string caseID, string username)
        {
            InitializeComponent();
            this.caseID = caseID;
            this.username = username;
            txtstudentid.KeyDown += new KeyEventHandler(txtstudentid_KeyDown);
        }
        Class1 cases = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");

        private void frmCase_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtstudentid.Text.Trim()))
            {
                FetchStudentCases(txtstudentid.Text.Trim());
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtstudentid.Text.Trim()))
            {
                errorProvider1.SetError(txtstudentid, "Please enter a valid Student ID.");
                return;
            }
            FetchStudentInfo();

            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                MessageBox.Show("Please provide a valid student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string studentID = txtstudentid.Text;
            string lastname = txtlastname.Text;
            string firstname = txtfirstname.Text;
            string middlename = txtmiddlename.Text;
            string level = txtlevel.Text;
            string course = txtstrandcourse.Text;

            frmNewCase newcaseform = new frmNewCase(caseID, username, studentID, lastname, firstname, middlename, level, course);
            newcaseform.StartPosition = FormStartPosition.CenterParent;
            newcaseform.FormClosed += (s, args) => {
                // Refresh cases after the new case form is closed
                FetchStudentCases(studentID);
            };
            newcaseform.Show();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            string studentID = txtstudentid.Text.Trim();
            if (!string.IsNullOrEmpty(studentID))
            {
                FetchStudentCases(studentID);
            }
            else
            {
                errorProvider1.SetError(txtstudentid, "Please enter a valid Student ID.");
            }
        }

        private int row;

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string studentID = txtstudentid.Text;
            string lastname = txtlastname.Text;
            string firstname = txtfirstname.Text;
            string middlename = txtmiddlename.Text;
            string level = txtlevel.Text;
            string course = txtstrandcourse.Text;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                string editcaseid = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string editschoolyear = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                string editviolationid = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                string editdescription = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                string editviolationtype = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                string editviolationcount = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                string editconcernlevel = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                string editstatus = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                string editaction = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                string editdiscipline = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();

                frmUpdateCase updatecaseform = new frmUpdateCase(caseID, username, editcaseid, studentID, lastname, firstname, middlename, level, course,
                    editviolationid, editviolationcount, editdescription, editstatus, editaction, editschoolyear, editconcernlevel, editdiscipline);

                updatecaseform.StartPosition = FormStartPosition.CenterParent;
                updatecaseform.FormClosed += (s, args) => {
                    // Refresh cases after the update case form is closed
                    FetchStudentCases(studentID);
                };
                updatecaseform.Show();
            }
            else
            {
                MessageBox.Show("Please select a student account to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtstudentid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                validateForm();

                if (errorCount == 0)
                {
                    FetchStudentInfo();
                    FetchStudentCases(txtstudentid.Text.Trim());
                }
            }
        }
        private void validateForm()
        {
            errorCount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtstudentid.Text.Trim()))
            {
                errorProvider1.SetError(txtstudentid, "Please enter a valid Student ID.");
                errorCount++;
            }
        }
        private void FetchStudentInfo()
        {
            string studentID = txtstudentid.Text.Trim();

            if (!string.IsNullOrEmpty(studentID))
            {
                string query = $"SELECT lastname, firstname, middlename, level, course FROM tblstudents WHERE studentID = '{studentID}'";
                DataTable dataTable = cases.GetData(query);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    txtlastname.Text = row["lastname"].ToString();
                    txtfirstname.Text = row["firstname"].ToString();
                    txtmiddlename.Text = row["middlename"].ToString();
                    txtlevel.Text = row["level"].ToString();
                    txtstrandcourse.Text = row["course"].ToString();
                    errorProvider1.Clear();
                }
                else
                {
                    ClearStudentFields();
                    errorProvider1.SetError(txtstudentid, "Student ID not found.");
                }
            }
        }
        private void ClearStudentFields()
        {
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmiddlename.Clear();
            txtlevel.Clear();
            txtstrandcourse.Clear();
            txtstudentid.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }
        private void FetchStudentCases(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
            {
                errorProvider1.SetError(txtstudentid, "Please enter a valid Student ID.");
                return;
            }
            try
            {
                string query = $"SELECT caseID, schoolyear, code, description, violationtype, violationCount, concernlevel, status, action, disciplinaryaction, datecreated " +
                                $"FROM tblcases WHERE studentID = '{studentID}' ORDER BY caseID DESC";
                DataTable dt = cases.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Refresh();
                }
                else
                {
                    DataTable noCasesTable = new DataTable();
                    noCasesTable.Columns.Add("Message");
                    noCasesTable.Rows.Add("No cases found for this student.");
                    dataGridView1.DataSource = noCasesTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Data Refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            validateForm();

            if (errorCount == 0)
            {
                FetchStudentInfo();
                if (!string.IsNullOrEmpty(txtstudentid.Text.Trim()))
                {
                    FetchStudentCases(txtstudentid.Text.Trim());
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.SelectedRows[0].Index;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearStudentFields();
            errorProvider1.Clear();
        }
    }
}
