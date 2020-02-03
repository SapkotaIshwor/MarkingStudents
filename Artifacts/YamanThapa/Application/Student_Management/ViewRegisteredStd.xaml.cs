using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for ViewRegisteredStd.xaml
    /// </summary>
    public partial class ViewRegisteredStd : Window
    {
        public ViewRegisteredStd()
        {
            InitializeComponent();

            retriveDAta();

        }

        private void retriveDAta()
        {
            var handler = new Handler();

            var dataSet = handler.GenerateDataSet();


            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {
                               
                dataSet.ReadXml(@"D:\StudentData.xml");

                studentDataView.ItemsSource = new DataView(dataSet.Tables["StudentInfo"]);
                DataTable stdReportTbl = dataSet.Tables["StudentInfo"];
            }
            else
            {
                System.Windows.MessageBox.Show("Sorry! XML file is missing", "FIle Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        
            {
                this.Close();
                baseWndo bw = new baseWndo();
                bw.Show();
            
        }

        private void sortData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sortData.SelectedIndex == 1)
            {

                studentDataView.Items.SortDescriptions.Clear();
                studentDataView.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
                studentDataView.Items.Refresh();

            }
            else if (sortData.SelectedIndex == 0)
            {
                studentDataView.Items.SortDescriptions.Clear();
                studentDataView.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                studentDataView.Items.Refresh();
            }
        }
    }
}
