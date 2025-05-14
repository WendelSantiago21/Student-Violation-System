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
    public partial class frmViolations : Form
    {
        private string code;
        public frmViolations(string code)
        {
            InitializeComponent();
            this.code = code;
        }
        Class1 violations = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");
        private void frmViolations_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = violations.GetData("SELECT code, description, violationtype, status, createdby, datecreated FROM tblviolations WHERE code <> '" + code +
                    "' ORDER BY code DESC");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on violations load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewViolations newviolationform = new frmNewViolations(code);
            newviolationform.FormClosed += (s, args) => frmViolations_Load(this, EventArgs.Empty);
            newviolationform.Show();
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = violations.GetData("SELECT code, description, violationtype, status, createdby, datecreated FROM tblviolations WHERE code <> '" + code +
                    "' AND (code LIKE '%" + txtsearch.Text + "%' OR violationtype LIKE '%" + txtsearch.Text + "%') ORDER BY code");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on violations search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmViolations_Load(sender, e);
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
            DialogResult dr = MessageBox.Show("Are you sure you want to remove this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    violations.executeSQL("DELETE FROM tblviolations WHERE code = '" + selectedUser + "'");
                    if (violations.rowAffected > 0)
                    {
                        violations.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                    "', 'Delete', 'Violations Management', '" + selectedUser + "', '" + code + "')");
                        MessageBox.Show("Violation has been Removed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmViolations_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string editcode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editviolationtype = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[3].Value.ToString();
            frmEditViolations editviolationfrm = new frmEditViolations(editcode, editdescription, editviolationtype, editstatus, code);
            editviolationfrm.FormClosed += (s, args) => frmViolations_Load(this, EventArgs.Empty);
            editviolationfrm.Show();
        }
    }
}
