using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace CourseWork1
{
    /// <summary>
    /// Interaction logic for StudentDetailForm.xaml
    /// </summary>
    public partial class StudentDetailForm : Window
    {
        public StudentDetailForm()
        {
            InitializeComponent();

            

            //add new student

            Student student = new Student();

            //add details
            student.RegNo = "1";
            student.Name = "Sneha BK";
            student.Address = "Rambazzar";
            student.Contact = "9805678776";
            student.CourseEnrol = "Computing";
            student.RegistrationDate = "06/02/2019";

            grdStd.Items.Add(student);

        }

        public class Student
        {
            public string RegNo { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Contact { get; set; }
            public string CourseEnrol { get; set; }
            public string RegistrationDate { get; set; }

        }

       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddData(dataSet);
            MessageBox.Show("Data saved successfully !!!");
            if (File.Exists(@"D:\studentData.xml"))
            {
                dataSet = new DataSet();
                dataSet.ReadXml(@"D:\studentData.xml");
                AddData(dataSet);
                dataSet.WriteXml(@"D:\studentData.xml");
            }
            else
            {
                dataSet = handler.CreateDataSet();
                AddData(dataSet);
                dataSet.WriteXml(@"D:\studentData.xml");
            }


  
        }

        private void AddData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            //dr1["RegNo"] = regNo.Text;
            dr1["Name"] = txtName.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["Contact"] = txtContact.Text;
            dr1["CourseEnrol"] = courseEnrol.Text;
            dr1["RegistrationDate"] = registrationDate.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }

        

       

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            regNo.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            courseEnrol.Text = "";
            registrationDate.Text = "";

            MessageBox.Show("Data cleared successfully !!!");

        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            Student dataStudent = new Student();
            dataStudent.RegNo = regNo.Text;
            dataStudent.Name = txtName.Text;
            dataStudent.Address = txtAddress.Text;
            dataStudent.Contact = txtContact.Text;
            dataStudent.CourseEnrol = courseEnrol.Text;
            dataStudent.RegistrationDate = registrationDate.Text;
            grdStd.Items.Add(dataStudent);
            MessageBox.Show("Data imported successfully !!!");

        }

        private void BtnDispalyReport_Click(object sender, RoutedEventArgs e)
        {
            StudentReport studentReport = new StudentReport();
            studentReport.Show();


        }

        private void BtnDispalyCharts_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
    }
}
