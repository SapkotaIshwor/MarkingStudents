using System;
using System.Collections.Generic;
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
using System.Data;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
   
        
    public partial class GenerateReport : Window
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        DataTable tableData;
        private void GenerateByDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(@"StudentDetails.xml"))
                {

                    var dataSet = new DataSet();
                    dataSet.ReadXml(@"StudentDetails.xml");

                    //DataTable StudentDT = new DataTable("dt");
                    tableData = dataSet.Tables[0];
                    tableData.DefaultView.Sort = "StudentRegistrationDate ASC";
                    ReportDataGrid.Items.Refresh();
                    ReportDataGrid.ItemsSource = tableData.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("StudentDetails.xml");
                DataView dv = new DataView();
                dv = ds.Tables[0].DefaultView;
                this.ReportDataGrid.ItemsSource = dv;

                MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateByName_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(@"StudentDetails.xml"))
                {

                    var dataSet = new DataSet();
                    dataSet.ReadXml(@"StudentDetails.xml");

                    //DataTable StudentDT = new DataTable("dt");
                    tableData = dataSet.Tables[0];
                    tableData.DefaultView.Sort = "StudentName ASC";
                    ReportDataGrid.Items.Refresh();
                    ReportDataGrid.ItemsSource = tableData.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
