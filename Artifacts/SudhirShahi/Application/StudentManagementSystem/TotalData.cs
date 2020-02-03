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
    public partial class TotalData : Form
    {
        public TotalData()
        {
            InitializeComponent();
        }
        private StudentRepository _studentRepository = new StudentRepository();
        private List<Student> _studentList = new List<Student>();
        private void TotalData_Load(object sender, EventArgs e)
        {
            _studentList = _studentRepository.GetAllData();

            FillChart();
        }
        private void FillChart()
        {
            foreach (var student in _studentList)
            {
                
                var b = student.Count1.ToString();
                
                var e = student.Name.ToString();



                string[] row = new string[] {  e,b };
                TotalDataGridView.Rows.Add(row);
                


            }
        }
        }
}
