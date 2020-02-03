using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the form is already open
            Form openForm = Application.OpenForms["StudentDetail"];
            //doesnot open a new instance if the form is already open.
            if (openForm == null)
            {
                StudentDetail studentDetail = new StudentDetail();
                studentDetail.MdiParent = this;
                studentDetail.Dock = DockStyle.Fill;
                studentDetail.Show();
            }
            
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the form is already open
            Form openForm = Application.OpenForms["TotalData"];
            //doesnot open a new instance if the form is already open.
            if (openForm == null)
            {
                TotalData course = new TotalData();
                course.MdiParent = this;
                course.Dock = DockStyle.Fill;
                course.Show();
            }
        }

        private void weakelyEnrolmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the form is already open
            Form openForm = Application.OpenForms["Weekly"];
            //doesnot open a new instance if the form is already open.
            if (openForm == null)
            {
                Weekly week = new Weekly();
                week.MdiParent = this;
                week.Dock = DockStyle.Fill;
                week.Show();
            }
        }

        private void sortedByRegistrationDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the form is already open
            Form openForm = Application.OpenForms["SortedByDate"];
            //doesnot open a new instance if the form is already open.
            if (openForm == null)
            {
                SortedByDate sort = new SortedByDate();
                sort.MdiParent = this;
                sort.Dock = DockStyle.Fill;
                sort.Show();
            }
        }
    }
}
