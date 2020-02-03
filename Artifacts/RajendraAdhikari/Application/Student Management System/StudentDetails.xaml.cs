using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Student_Management_System
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Page
    {
        List<Student> studentDetails2 = new List<Student>();
        public StudentDetails()
        {
            InitializeComponent();
        }
        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {


            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            ReadFromCSV(csvData);


        }

        public List<Student> ReadFromCSV(string csvData)
        {
            List<Student> studentDetails = new List<Student>();
            try
            {
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.studentID = Convert.ToString(values[0]);
                    student.firstName = Convert.ToString(values[1]);
                    student.lastName = Convert.ToString(values[2]);
                    student.address = Convert.ToString(values[3]);
                    student.phoneNo = Convert.ToString(values[4]);
                    student.courseName = Convert.ToString(values[5]);
                    student.enrolledDate = Convert.ToString(values[6]);
                    studentDetails.Add(student);
                }
                dg3rd.ItemsSource = studentDetails2;
                this.dg3rd.ItemsSource = studentDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return studentDetails;
        }

        private void SortByNameBtn_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(dg3rd, 1);
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];
            dataGrid.Items.SortDescriptions.Clear();

            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            dataGrid.Items.Refresh();
        }

        private void SortByDateBtn_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(dg3rd, 6);
        }
    }
}

