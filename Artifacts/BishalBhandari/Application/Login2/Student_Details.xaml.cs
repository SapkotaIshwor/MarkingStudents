using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Login2
{
    /// <summary>
    /// Interaction logic for Student_Details.xaml
    /// </summary>
    public partial class Student_Details : Page
    {
        public Student_Details()
        {
            InitializeComponent();

            DataSet xmlData = new DataSet();
            xmlData.ReadXml("StudentDetails.xml", XmlReadMode.Auto);
            //DataGrid dataGrid = new DataGrid();  <- don't create new one!!
            dgStudentDetails.ItemsSource =                     //<- reference datagrid from your XAML
                        xmlData.Tables[0].DefaultView;

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            dgStudentDetails.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml("StudentDetails.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            dgStudentDetails.ItemsSource = dtStdReport.DefaultView;
            dgStudentDetails.Items.SortDescriptions.Add(new SortDescription("RegisterDate", ListSortDirection.Ascending));
            dgStudentDetails.Items.Refresh();
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            dgStudentDetails.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml("StudentDetails.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            dgStudentDetails.ItemsSource = dtStdReport.DefaultView;
            dgStudentDetails.Items.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
            dgStudentDetails.Items.Refresh();
        }
    }
}
