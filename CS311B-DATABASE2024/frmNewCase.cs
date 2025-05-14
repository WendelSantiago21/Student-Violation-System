using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311B_DATABASE2024
{
    public partial class frmNewCase : Form
    {
        private string caseID, username;
        Class1 newcases = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        public frmNewCase(string username, string caseID, string studentID, string lastname, string firstname, string middlename, string level, string course)
        {
            InitializeComponent();
            this.caseID = caseID;
            this.username = username;
            txtstudentid.Text = studentID;
            txtlastname.Text = lastname;
            txtfirstname.Text = firstname;
            txtmiddlename.Text = middlename;
            txtlevel.Text = level;
            txtstrandcourse.Text = course;
            cmbcode.SelectedIndexChanged += cmbcode_SelectedIndexChanged;
        }
        private string GenerateCaseID()
        {
            DateTime now = DateTime.Now;
            return $"case - {now.Year}{now.Month:D2}{now.Day:D2}{now.Hour:D2}{now.Minute:D2}{now.Second:D2}";
        }
        private void frmNewCase_Load(object sender, EventArgs e)
        {
            caseID = GenerateCaseID();
            txtcaseid.Text = caseID;
            PopulateViolationId();
        }
        private void PopulateViolationId()
        {
            cmbcode.Items.Clear();
            string query = "SELECT code, violationtype, description FROM tblviolations";
            DataTable dataTable = newcases.GetData(query);

            foreach (DataRow row in dataTable.Rows)
            {
                cmbcode.Items.Add(new ComboBoxItem
                {
                    Code = row["code"].ToString(),
                    Type = row["violationtype"].ToString(),
                    Description = row["description"].ToString()
                });
            }
        }
        public class ComboBoxItem
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }

            public override string ToString() => Code;
        }
        private void cmbcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtviolationcount.Clear();
            errorProvider1.SetError(txtviolationcount, string.Empty);

            if (cmbcode.SelectedItem is ComboBoxItem selectedItem)
            {
                txtdescription.Text = selectedItem.Description;
                SetOffenseCount(txtstudentid.Text, selectedItem.Code);
            }
        }
        private void SetOffenseCount(string studentID, string code)
        {
            string query = $"SELECT violationCount FROM tblcases WHERE studentID = '{studentID}' AND code = '{code}'";
            DataTable result = newcases.GetData(query);

            bool hasFirstOffense = false;
            bool hasSecondOffense = false;
            foreach (DataRow row in result.Rows)
            {
                string existingCount = row["violationCount"].ToString().ToLower().Trim();
                Console.WriteLine($"Retrieved violationCount from DB: {existingCount}");

                if (existingCount == "1st offense")
                {
                    hasFirstOffense = true;
                }
                else if (existingCount == "2nd offense")
                {
                    hasSecondOffense = true;
                }
            }
            if (hasSecondOffense)
            {
                txtviolationcount.Text = "Repeat Offense";
            }
            else if (hasFirstOffense)
            {
                txtviolationcount.Text = "2nd Offense";
            }
            else
            {
                txtviolationcount.Text = "1st Offense";
            }
            Console.WriteLine($"Set txtviolationcount.Text to: {txtviolationcount.Text}");
        }
        private int errorCount = 0;
        private bool validateForm()
        {
            errorCount = 0;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtcaseid.Text))
            {
                errorProvider1.SetError(txtcaseid, "Input is Empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtschoolyear.Text))
            {
                errorProvider1.SetError(txtschoolyear, "Input is Empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdiscipline.Text))
            {
                errorProvider1.SetError(txtdiscipline, "Input is Empty");
                errorCount++;
            }
            if (cmbcode.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbcode, "Select a violation code");
                errorCount++;
            }
            if (cmbconcernlevel.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbconcernlevel, "Select a concern level");
                errorCount++;
            }

            string code = cmbcode.Text.ToUpper();
            string existingOffenses = CheckExistingOffense(txtstudentid.Text, code).Trim().ToLower();
            string currentCount = txtviolationcount.Text.Trim().ToLower();
            Console.WriteLine($"Existing Offenses: {existingOffenses}, Current Count: {currentCount}");
            if (existingOffenses.Contains("1st offense") && currentCount == "1st offense")
            {
                errorProvider1.SetError(txtviolationcount, "Student already has 1st offense for this violation.");
                errorCount++;
            }
            if (existingOffenses.Contains("2nd offense") && currentCount == "2nd offense")
            {
                errorProvider1.SetError(txtviolationcount, "Student already has 2nd offense for this violation.");
                errorCount++;
            }
            return errorCount == 0;
        }
        private string CheckExistingOffense(string studentID, string code)
        {
            string query = $"SELECT violationCount FROM tblcases WHERE studentID = '{studentID}' AND code = '{code}'";
            DataTable result = newcases.GetData(query);
            List<string> offenses = new List<string>();
            foreach (DataRow row in result.Rows)
            {
                string offense = row["violationCount"].ToString().Trim().ToLower();
                if (!offenses.Contains(offense))
                {
                    offenses.Add(offense);
                }
            }
            return offenses.Count > 0 ? string.Join(", ", offenses) : string.Empty;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbcode.SelectedIndex = -1;
            txtviolationcount.Clear();
            txtdescription.Clear();
            txtschoolyear.Clear();
            cmbconcernlevel.SelectedIndex = -1;
            txtdiscipline.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this Case for this Student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ComboBoxItem selectedItem = (ComboBoxItem)cmbcode.SelectedItem;
                        string violationType = selectedItem.Type;

                        newcases.executeSQL("INSERT INTO tblcases (caseID, studentID, schoolyear, concernlevel, code, description, violationtype, violationCount, disciplinaryaction, status, action, createdby, datecreated) " +
                                                    $"VALUES ('{txtcaseid.Text}', '{txtstudentid.Text}', '{txtschoolyear.Text}', '{cmbconcernlevel.Text.ToUpper()}', '{cmbcode.Text.ToUpper()}', '{txtdescription.Text}', " +
                                                    $"'{violationType}', '{txtviolationcount.Text}', '{txtdiscipline.Text}' ,'On going', ' ', '{username}', '{DateTime.Now.ToShortDateString()}')");

                        if (newcases.rowAffected > 0)
                        {
                            newcases.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) " +
                                                         $"VALUES ('{DateTime.Now.ToShortDateString()}', '{DateTime.Now.ToShortTimeString()}', 'Add', 'Cases Management', '{txtcaseid.Text}', '{username}')");

                            MessageBox.Show("New case added successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on saving the case", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
