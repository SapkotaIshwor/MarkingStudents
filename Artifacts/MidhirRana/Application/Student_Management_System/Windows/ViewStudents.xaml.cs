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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Student_Management_System.Forms
{
    /// <summary>
    /// Interaction logic for ViewStudents.xaml
    /// </summary>
    public partial class ViewStudents : Window
    {
        List<StudentInfo> stdInfoList2 = new List<StudentInfo>();
       
        public ViewStudents()
        {
            InitializeComponent();
            var csvData = System.IO.File.ReadAllText("studentDetails.csv");
            ReadFromCSV(csvData);

        }

        public List<StudentInfo> ReadFromCSV(string csvData)
        {
            List<StudentInfo> stdInfoList1 = new List<StudentInfo>();
            try
            {
                
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    StudentInfo stdobj = new StudentInfo();
                    stdobj.ID = Convert.ToString(values[0]);
                    stdobj.Student_Name = Convert.ToString(values[1]);
                    stdobj.Gender = Convert.ToString(values[2]);
                    stdobj.Address = Convert.ToString(values[3]);
                    stdobj.Contact = Convert.ToString(values[4]);
                    stdobj.Email = Convert.ToString(values[5]);
                    stdobj.Programme = Convert.ToString(values[6]);
                    stdobj.Registration_Date = Convert.ToString(values[7]);
                    stdInfoList1.Add(stdobj);
                }
                StudentGridView.ItemsSource = stdInfoList2;
                this.StudentGridView.ItemsSource = stdInfoList1;
                MessageBox.Show("Successfully Fetched. Click OK to View.", "Success",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return stdInfoList1;
        }

        private void BtnViewByName_Click(object sender, RoutedEventArgs e)
        {

            SortDataGrid(StudentGridView, 1);
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

        private void BtnViewByDate_Click(object sender, RoutedEventArgs e)
        {
            SortDataGrid(StudentGridView, 7);
        }
    }
}
