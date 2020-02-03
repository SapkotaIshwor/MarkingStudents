using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace StudentManagementSystem
{
    public partial class StudentDetail : Form
    {
        private BindingSource _studentBindingSource = new BindingSource();

        private StudentRepository _studentRepository = new StudentRepository();


        public StudentDetail()
        {
            InitializeComponent();
        }

        private void StudentDetail_Load(object sender, EventArgs e)
        {
            btnRetrive_Click_1(sender, e);
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RegisterStudent studentForm = new RegisterStudent();
            studentForm.MaximizeBox = false;
            //Nullable<bool> result = Convert.ToBoolean(studentForm.ShowDialog());
            var result = studentForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var newStudent = studentForm.Student;

                newStudent.StudentId = _studentRepository.GenerateId();

                _studentBindingSource.Add(newStudent);
                _studentRepository.SaveStudents((List<Student>)_studentBindingSource.DataSource);


            }

            //RegisterStudent studentform = new RegisterStudent();

            //studentform.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //step 1: create an instance of windows default open dialog box.
            var dialog = new OpenFileDialog();
            //step 2: set filter so that it shows only csv files.
            dialog.Filter = "CSV files|*.csv";

            //step 3: open the dialog box
            var result = dialog.ShowDialog();

            //check if  user has clicked OK.
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //Step 1: read all the lines in the csv file
                var csvString = File.ReadAllText(dialog.FileName);
                //Step 2: Pass the csvString to ReadFromCSV method from _vehicleRepository class
                //Step 3: Save the value to the binding source. (Binding Source is used by our grid).
                _studentBindingSource.DataSource = _studentRepository.ReadFromCSV(csvString);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //step 1: create an instance of windows default save dialog box.
            var dialog = new SaveFileDialog();
            //step 2: set filter so that the file can be saved with extenstion .csv.
            dialog.Filter = "CSV File|*.csv";
            dialog.AddExtension = true;
            //step 3: open the save dialog box
            var result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //export filename and our data list to the ExportToCSV class.
                _studentRepository.ExportToCSV((List<Student>)_studentBindingSource.DataSource, dialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _studentRepository.SaveStudents((List<Student>)_studentBindingSource.DataSource);
        }

        private void btnRetrive_Click_1(object sender, EventArgs e)
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

        }

        //private void btnSort_Click(object sender, EventArgs e)
        //{

        //    _studentBindingSource.DataSource = _studentRepository.SortUsingName();
        //    //this.StudentDataGridView.Sort(this.StudentDataGridView.Columns["Name"], ListSortDirection.Ascending);


        //    //refresh the grid to view the output.
        //    StudentDataGridView.Refresh();
        //}



        //private void btnSort_Click(object sender, EventArgs e)
        ////{
        ////    _studentBindingSource.DataSource = _studentRepository.SortUsingTotalDuration();

        ////    //refresh the grid to view the output.
        ////    StudentDataGridView.Refresh();
        //}
    }
}
