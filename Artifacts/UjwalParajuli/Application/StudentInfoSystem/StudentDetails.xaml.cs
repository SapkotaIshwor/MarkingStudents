using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace StudentInfoSystem
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

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
          
                var csvData = System.IO.File.ReadAllText("studentDetails.csv");
                ReadFromCSV(csvData);

        }

        public List<Student> ReadFromCSV(string csvData)
        {
            List<Student> studentDetails = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.idNumber = Convert.ToString(values[0]);
                    student.firstName = Convert.ToString(values[1]);
                    student.lastName = Convert.ToString(values[2]);
                    student.address = Convert.ToString(values[3]);
                    student.contactNo = Convert.ToString(values[4]);
                    student.courseName = Convert.ToString(values[5]);
                    student.registerDate = Convert.ToString(values[6]);
                    studentDetails.Add(student);
                }
                dgThird.ItemsSource = studentDetails2;
                this.dgThird.ItemsSource = studentDetails;
                MessageBox.Show("Successfully Retrieved", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return studentDetails;
        }

        private void ButtonSortByName_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(dgThird, 1);
            MessageBox.Show("Successfully Sorted by First Name","Success");
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }

        private void ButtonSortByDate_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(dgThird, 6);
            MessageBox.Show("Successfully Sorted by Date", "Success");
        }
    }
}

