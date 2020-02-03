using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace StudentManagementSystem
{
    public partial class SortedByDate : Form
    {
        private BindingSource _studentBindingSource = new BindingSource();

        private StudentRepository _studentRepository = new StudentRepository();
        public SortedByDate()
        {
            InitializeComponent();
        }

        private void SortedByDate_Load(object sender, EventArgs e)
        {
            // to display in grid
            _studentBindingSource.DataSource = _studentRepository.GetStudents();
            //if set to true creates a new object if the list is empty

            _studentBindingSource.AllowNew = false;

            StudentDataGridView.DataSource = _studentBindingSource;
            StudentDataGridView.ReadOnly = true;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            _studentBindingSource.DataSource = _studentRepository.SortUsingDate();
           


            //refresh the grid to view the output.
             StudentDataGridView.Refresh();
        }
    }
}
