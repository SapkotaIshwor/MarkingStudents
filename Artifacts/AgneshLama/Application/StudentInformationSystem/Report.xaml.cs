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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        
        public Report()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

       

       
        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("StudentDetails.xml");
                DataView dv = new DataView();
                dv = ds.Tables[0].DefaultView;
                this.DataGridReport.ItemsSource = dv;

                MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DataTable sortTable;
        private void btnGenerateByDate_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(@"StudentDetails.xml"))
                {

                    var dataSet = new DataSet();
                    dataSet.ReadXml(@"StudentDetails.xml");

                    //DataTable StudentDT = new DataTable("dt");
                    sortTable = dataSet.Tables[0];
                    sortTable.DefaultView.Sort = "StudentRegistrationDate ASC";
                    DataGridReport.Items.Refresh();
                    DataGridReport.ItemsSource = sortTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateByName_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(@"StudentDetails.xml"))
                {

                    var dataSet = new DataSet();
                    dataSet.ReadXml(@"StudentDetails.xml");

                    //DataTable StudentDT = new DataTable("dt");
                    sortTable = dataSet.Tables[0];
                    sortTable.DefaultView.Sort = "StudentName ASC";
                    DataGridReport.Items.Refresh();
                    DataGridReport.ItemsSource = sortTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
