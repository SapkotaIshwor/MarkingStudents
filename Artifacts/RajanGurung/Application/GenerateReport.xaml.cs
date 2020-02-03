using System;
using System.Collections.Generic;
using System.Data;
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

namespace CourseworkAppDevelopment
{

    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
    public partial class GenerateReport : Window
    {
        DataTable datatable;
        // Datatable variable is created which is used in the code below.

        public GenerateReport()
        {
            InitializeComponent();
        }

        private void btnGenerateBack_Click(object sender, RoutedEventArgs e) {

            HomeWindow homeWindow = new HomeWindow();
            
            homeWindow.Show();
            
            this.Close();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e) {

            try {

                DataSet dataset = new DataSet();
                
                dataset.ReadXml("StudentEnroll.xml");
                
                DataView dataview = new DataView();
                
                dataview = dataset.Tables[0].DefaultView;
                
                this.dataGridStudentReport.ItemsSource = dataview;

                MessageBox.Show("Student Report Generated", "Student InformationSystem");

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnReportName_Click(object sender, RoutedEventArgs e)
        {
            try{
                var dataSet = new DataSet();

                dataSet.ReadXml(@"StudentEnroll.xml");

                //DataTable StudentDT = new DataTable("dt");

                datatable = dataSet.Tables[0];

                datatable.DefaultView.Sort = "StudentName ASC";

                dataGridStudentReport.Items.Refresh();

                dataGridStudentReport.ItemsSource = datatable.DefaultView;

                MessageBox.Show("Student Records Genrated by First Name", "Student Information System");

            }

            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnGenerateByRegistrationDate_Click(object sender, RoutedEventArgs e) {

            try
            {

                var dataSet = new DataSet();

                dataSet.ReadXml(@"StudentEnroll.xml");

                //DataTable StudentDT = new DataTable("dt");

                datatable = dataSet.Tables[0];

                datatable.DefaultView.Sort = "StudentRegistrationDate ASC";

                dataGridStudentReport.Items.Refresh();

                dataGridStudentReport.ItemsSource = datatable.DefaultView;

                MessageBox.Show("Student Records Genrated by Registration Date", "Student Information System");
            }

            catch (Exception ex){

                MessageBox.Show(ex.Message);

            }

        }
    }
}
