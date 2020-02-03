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

namespace StudentInformationSystem
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
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.stdidNum = Convert.ToString(values[0]);
                    student.stdfullName = Convert.ToString(values[1]);
                    student.stdaddress = Convert.ToString(values[2]);
                    student.contactNum = Convert.ToString(values[3]);
                    student.courseName = Convert.ToString(values[4]);
                    student.registerDate = Convert.ToString(values[5]);
                    studentDetails.Add(student);
                }
                datagrid3.ItemsSource = studentDetails2;
                this.datagrid3.ItemsSource = studentDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return studentDetails;
        }

        private void ButtonSortByName_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(datagrid3, 1);
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
            SortDataGrid(datagrid3, 5);
        }
    }
}


