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
    public partial class frmStrand : Form
    {
        private string strandcode;
        public frmStrand(string strandcode)
        {
            InitializeComponent();
            this.strandcode = strandcode;
        }
        Class1 strand = new Class1("127.0.0.1", "cs311b2024", "wendel", "pastoral");

        private void frmStrand_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = strand.GetData("SELECT strandcode, description, datecreated, createdby FROM tblstrands WHERE strandcode <> '" + strandcode +
                    "' ORDER BY strandcode DESC");
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["description"].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on strand load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewStrand newstrandform = new frmNewStrand(strandcode);
            newstrandform.FormClosed += (s, args) => frmStrand_Load(this, EventArgs.Empty);
            newstrandform.Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = strand.GetData("SELECT strandcode, description, datecreated, createdby FROM tblstrands WHERE strandcode <> '"
                    + strandcode + "' AND (strandcode LIKE '%" + txtsearch.Text + "%' OR description LIKE '%" + txtsearch.Text + "%' OR createdby LIKE '%" + txtsearch.Text + "%') ORDER BY strandcode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on strand search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmStrand_Load(sender, e);
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
            DialogResult dr = MessageBox.Show("Are you sure you want to remove this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    strand.executeSQL("DELETE FROM tblstrands WHERE strandcode = '" + selectedUser + "'");
                    if (strand.rowAffected > 0)
                    {
                        strand.executeSQL("INSERT INTO tbllogs(datelog, timelog, action, module, ID, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() +
                                    "', 'Delete', 'Strand Management', '" + selectedUser + "', '" + strandcode + "')");
                        MessageBox.Show("Strand Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmStrand_Load(sender, e);
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
            string editstrandcode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            frmUpdateStrand updatestrandfrm = new frmUpdateStrand(editstrandcode, editdescription, strandcode);
            updatestrandfrm.FormClosed += (s, args) => frmStrand_Load(this, EventArgs.Empty);
            updatestrandfrm.Show();
        }
    }
}
