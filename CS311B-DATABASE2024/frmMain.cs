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
    public partial class frmMain : Form
    {
        private String username, usertype;
        public frmMain(string username, string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }
        private void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAccounts accounts = new frmAccounts(username);
            accounts.MdiParent = this;
            accounts.Show();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudents students = new frmStudents(username);
            students.MdiParent = this;
            students.Show();
        }

        private void violationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViolations violations = new frmViolations(username);
            violations.MdiParent = this;
            violations.Show();
        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCourse course = new frmCourse(username);
            course.MdiParent = this;
            course.Show();
        }

        private void strandsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStrand strand = new frmStrand(username);
            strand.MdiParent = this;
            strand.Show();
        }
        private string caseID;
        private void casesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCase cases = new frmCase(username, caseID);
            cases.MdiParent = this;
            cases.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Username:" + username;
            toolStripStatusLabel4.Text = "Usertype:" + usertype;
            if (usertype == "ADMINISTRATOR")
            {
                accountsToolStripMenuItem1.Visible = true;
                studentToolStripMenuItem1.Visible = true;
                violationsToolStripMenuItem1.Visible = true;
                courseToolStripMenuItem1.Visible = true;
                strandsToolStripMenuItem1.Visible = true;
                casesToolStripMenuItem1.Visible = true;
            }
            else if (usertype == "BRANCHADMIN")
            {
                accountsToolStripMenuItem1.Visible = false;
                studentToolStripMenuItem1.Visible = true;
                violationsToolStripMenuItem1.Visible = true;
                courseToolStripMenuItem1.Visible = false;
                strandsToolStripMenuItem1.Visible = false;
                casesToolStripMenuItem1.Visible = true;
            }
            else
            {
                accountsToolStripMenuItem1.Visible = false;
                studentToolStripMenuItem1.Visible = false;
                violationsToolStripMenuItem1.Visible = false;
                courseToolStripMenuItem1.Visible = false;
                strandsToolStripMenuItem1.Visible = false;
                casesToolStripMenuItem1.Visible = true;
            }
        }
    }
}
