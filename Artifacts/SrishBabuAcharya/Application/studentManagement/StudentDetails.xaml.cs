using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace studentManagement
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

        private void studentDetailsBtn_Click(object sender, RoutedEventArgs e)
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
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.studentIdNumber = Convert.ToString(values[0]);
                    student.studentFullName = Convert.ToString(values[1]);
                    student.studentAddress = Convert.ToString(values[2]);
                    student.studentContact = Convert.ToString(values[3]);
                    student.courseName = Convert.ToString(values[4]);
                    student.registeredDate = Convert.ToString(values[5]);
                    studentDetails.Add(student);
                }
                datagridThird.ItemsSource = studentDetails2;
                this.datagridThird.ItemsSource = studentDetails;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return studentDetails;
        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(datagridThird, 1);
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

        private void SortByDate_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(datagridThird, 5);
        }
    }
}
   
