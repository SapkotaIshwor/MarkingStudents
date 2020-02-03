using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
    public partial class GenerateReport : UserControl
    {
        private FileHandler fileHandler = new FileHandler();
        private ObservableCollection<StudentDetails> Students;
        public GenerateReport()
        {
            InitializeComponent();
            Students = fileHandler.getData();
            fillTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Import Students";
            ofd.Filter = "CSV File|*.csv";
            

            if(ofd.ShowDialog() == true)
            {
                string filePath = ofd.FileName;

                fileHandler.importCSV(filePath);
            }
        }

        private void fillTable()
        {
            try
            {
                studentDetailTable.ItemsSource = null;
                Students = fileHandler.getData();
                studentDetailTable.ItemsSource = Students;
            }
            catch
            {
                MessageBox.Show("An error occured!");
            }
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            SortDataGrid(studentDetailTable, 1);
        }

        private void SortByDate(object sender, RoutedEventArgs e)
        {
            SortDataGrid(studentDetailTable, 5);
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
    }
}
