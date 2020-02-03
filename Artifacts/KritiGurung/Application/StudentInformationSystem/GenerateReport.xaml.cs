using System;
using System.Data;
using System.Windows;
using System.IO;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ImportBulkRecord.xaml
    /// </summary>
    public partial class GenerateReport : Window
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private void generateStudentReport(object sender, RoutedEventArgs e)
        {


            if (sort_date.IsChecked == true)
            {
                try
                {
                    if (System.IO.File.Exists(@"StudentDetails.xml"))
                    {
                        var dataSet = new DataSet();
                        dataSet.ReadXml(@"StudentDetails.xml");

                        dt = dataSet.Tables[0];
                        dt.DefaultView.Sort = "registrationDate ASC";
                        disply_record.Items.Refresh();
                        disply_record.ItemsSource = dt.DefaultView;
                        MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No data to generate report.", "Action UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);

                }
            }

            else if (sort_first_name.IsChecked == true)
            {
                try
                {
                    if (System.IO.File.Exists(@"StudentDetails.xml"))
                    {

                        var dataSet = new DataSet();
                        dataSet.ReadXml(@"StudentDetails.xml");

                        dt = dataSet.Tables[0];
                        dt.DefaultView.Sort = "name ASC";
                        disply_record.Items.Refresh();
                        disply_record.ItemsSource = dt.DefaultView;
                        MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No data to generate report.", "Action UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
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
                    this.disply_record.ItemsSource = dv;

                    MessageBox.Show("Student details report is generated.", "Report Generated!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                catch
                {
                    MessageBox.Show("No data to generate report.", "Action UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
            }
        }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.Hide();
                HomePage form2 = new HomePage();
                form2.ShowDialog();
            }
        
    }
}
    
