using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace CWAD
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
        {
            InitializeComponent();
        }

        DataTable StudentDT;
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnRegistrationDate.IsChecked == true)
            {
                try
                {
                    if (System.IO.File.Exists(@"StudentDetails.xml"))
                    {

                        var dataSet = new DataSet();
                        dataSet.ReadXml(@"StudentDetails.xml");

                        //DataTable StudentDT = new DataTable("dt");
                        StudentDT = dataSet.Tables[0];
                        StudentDT.DefaultView.Sort = "StudentRegistrationDate ASC";
                        dataGridReport.Items.Refresh();
                        dataGridReport.ItemsSource = StudentDT.DefaultView;

                        MessageBox.Show("Student details report sorted by Registration Date in ascending order; is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("No xml file is created to get and show data from.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (rbtnStudentName.IsChecked == true)
            {
                try
                {
                    if (System.IO.File.Exists(@"StudentDetails.xml"))
                    {

                        var dataSet = new DataSet();
                        dataSet.ReadXml(@"StudentDetails.xml");

                        //DataTable StudentDT = new DataTable("dt");
                        StudentDT = dataSet.Tables[0];
                        StudentDT.DefaultView.Sort = "StudentName ASC";
                        dataGridReport.Items.Refresh();
                        dataGridReport.ItemsSource = StudentDT.DefaultView;

                        MessageBox.Show("Student details report sorted by Student's Name in ascending order; is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("No xml file is created to get and show data from.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("StudentDetails.xml");
                    DataView dv = new DataView();
                    dv = ds.Tables[0].DefaultView;
                    this.dataGridReport.ItemsSource = dv;

                    MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch
                {
                    MessageBox.Show("No xml file is created to get and show data from.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }      
            }
        }

        private void rbtnStudentName_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbtnRegistrationDate_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
