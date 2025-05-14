using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CS311B_DATABASE2024.frmNewCase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS311B_DATABASE2024
{
    public partial class frmUpdateCase : Form
    {
        private string caseID, username, editcaseid, studentID, editlastname, editfirstname, editmiddlename, editlevel, editstrandcourse, editviolationid,
        editviolationcount, editdescription, editstatus, editaction, editschoolyear, editconcernlevel, editdiscipline;

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbstatus.SelectedIndex = -1;
            txtaction.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to edit this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (cmbcode.SelectedItem is ComboBoxItem selectedItem)
                        {
                            updatecases.executeSQL("UPDATE tblcases SET studentID = '" + txtstudentid.Text + "', schoolyear = '" + txtschoolyear.Text + "', code = '" + selectedItem.Code.ToUpper() +
                                "', description = '" + txtdescription.Text + "', violationtype = '" + selectedItem.Type + "', violationCount = '" +
                                txtviolationcount.Text + "', concernlevel = '" + cmbconcernlevel.Text.ToUpper() + "', status = '" + cmbstatus.Text.ToLower() + "', action = '" + txtaction.Text +
                                 "', disciplinaryaction = '" + txtdiscipline.Text + "' WHERE caseID = '" + txtcaseid.Text + "'");

                            if (updatecases.rowAffected > 0)
                            {
                                updatecases.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "', '" + DateTime.Now.ToShortTimeString() + "', 'Update', 'Cases Management', '" + txtcaseid.Text + "', '" + caseID + "')");
                                MessageBox.Show("Case Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
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
            errorCount = 0;
            errorProvider1.Clear();
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Please Select a Status");
                errorCount++;
            }
            if (txtaction.Enabled && string.IsNullOrEmpty(txtaction.Text))
            {
                errorProvider1.SetError(txtaction, "Input is Empty");
                errorCount++;
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
            }
        }

        private void frmUpdateCase_Load(object sender, EventArgs e)
        {
            txtcaseid.Text = editcaseid;
            PopulateViolationId();
            txtschoolyear.Text = editschoolyear;
            cmbconcernlevel.Text = editconcernlevel;
            txtdiscipline.Text = editdiscipline;
            txtviolationcount.Text = editviolationcount;
            txtdescription.Text = editdescription;

            if (editstatus == "On going")
            {
                cmbstatus.SelectedIndex = 0;
            }
            else
            {
                cmbstatus.SelectedIndex = 1;
                txtaction.Enabled = true;
            }
            txtaction.Text = editaction;
        }
        private void PopulateViolationId()
        {
            cmbcode.Items.Clear();
            string query = "SELECT code, violationtype, description FROM tblviolations";
            DataTable dataTable = updatecases.GetData(query);

            // Add items to the ComboBox
            foreach (DataRow row in dataTable.Rows)
            {
                ComboBoxItem comboItem = new ComboBoxItem
                {
                    Code = row["code"].ToString(),
                    Type = row["violationtype"].ToString(),
                    Description = row["description"].ToString()
                };

                cmbcode.Items.Add(comboItem);
            }

            // Find and select the item that matches editviolationid
            for (int i = 0; i < cmbcode.Items.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)cmbcode.Items[i];
                if (item.Code.Equals(editviolationid, StringComparison.OrdinalIgnoreCase)) // Case-insensitive comparison
                {
                    cmbcode.SelectedIndex = i;
                    txtdescription.Text = item.Description;
                    txtviolationcount.Text = editviolationcount;
                    break;
                }
            }
        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbstatus.SelectedIndex == 1)
            {
                txtaction.Enabled = true;
            }
            else
            {
                txtaction.Enabled = false;
                txtaction.Clear();
            }
        }
        Class1 updatecases = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private int errorCount;

        public frmUpdateCase(string caseID, string username, string editcaseid, string studentID, string lastname, string firstname, string middlename,
            string level, string course, string editviolationid, string editviolationcount, string editdescription, string editstatus, string editaction, 
            string editschoolyear, string editconcernlevel, string editdiscipline)
        {
            InitializeComponent();
            this.caseID = caseID;
            this.username = username;
            this.editcaseid = editcaseid;
            txtstudentid.Text = studentID;
            txtlastname.Text = lastname;
            txtfirstname.Text = firstname;
            txtmiddlename.Text = middlename;
            txtlevel.Text = level;
            txtstrandcourse.Text = course;
            this.editviolationid = editviolationid;
            this.editviolationcount = editviolationcount;
            this.editdescription = editdescription;
            this.editstatus = editstatus;
            this.editaction = editaction;
            this.editschoolyear = editschoolyear;
            this.editdiscipline = editdiscipline;
            this.editconcernlevel = editconcernlevel;
        }

    }
}
