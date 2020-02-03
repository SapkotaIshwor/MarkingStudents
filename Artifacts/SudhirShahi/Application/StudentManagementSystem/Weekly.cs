using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace StudentManagementSystem
{
    public partial class Weekly : Form
    {
        
        public Weekly()
        {
            InitializeComponent();
        }
        private StudentRepository _studentRepository  = new StudentRepository();
        private List<Student> _studentList  = new List<Student>();
        private Student st = new Student();

        private void WeeklyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Weekly_Load(object sender, EventArgs e)
        {
            _studentList = _studentRepository.GetWeeksData();
            
            FillChart();
        }

        private void FillChart()
        {
           
            foreach (var student in _studentList)
            {
                var a = student.Count1.ToString();
                var b = student.Name.ToString();
               

                string[] row = new string[] { b, a };
                WeeklyDataGridView.Rows.Add(row);
                

            }






            //var e = visit.VisitorName.ToString();

            //this.WeeklyDataGridView.Rows.Add(b, c, d);


            //}
        }
    }
}
