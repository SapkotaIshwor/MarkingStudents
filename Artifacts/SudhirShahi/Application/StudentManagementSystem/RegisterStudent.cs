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
    public partial class RegisterStudent : Form
    {
        private StudentRepository _studentRepository = new StudentRepository();
        private BindingSource _studentBindingSource = new BindingSource();

        public RegisterStudent()
        {
            InitializeComponent();
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {
            //GetStudentData(sender, e);
        }

        //private void GetStudentData(object sender, EventArgs e)
        //{
        //    //to display in grid
        //    //it gets student data from studentRepository class

        //    _studentBindingSource.DataSource = _studentRepository.GetStudents();

        //    //if set to true creates a new object if the list is empty.
        //    _studentBindingSource.AllowNew = false;

            


        //}

        public Student Student
        {
            get
            {
                var student = new Student();
                student.Name = txtName.Text;
                student.Address = txtAddress.Text;
                student.ContactNumber = txtContact.Text;
                student.Email = txtEmail.Text;
                student.ProgramEnroll = comboProgram.Text;
                student.RegistrationDate = dateTimePicker1.Value.Date;

                return student;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //var student = new Student();
            //student.StudentId = _studentRepository.GenerateId();
            //txtName.Text = student.Name;
            //txtAddress.Text = student.Address;
            //txtContact.Text = Convert.ToString(student.ContactNumber);
            //txtEmail.Text = student.Email;
            //comboProgram.Text = student.ProgramEnroll;
            //dateTimePicker1.MinDate = student.RegistrationDate;


           

            //_studentBindingSource.Add(student);
            //_studentRepository.SaveStudents((List<Student>)_studentBindingSource.DataSource);



        }
    }
}
