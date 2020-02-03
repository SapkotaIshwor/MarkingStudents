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

        private void Btn_Load_Daily_Report(object sender, RoutedEventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {
                //var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"D:\StudentData.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdRreportDaily.DataContext = dtStdReport.DefaultView;
            }

        }

        private void Btn_Sort_First(object sender, RoutedEventArgs e)
        {
            grdRreportDaily.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\StudentData.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            grdRreportDaily.ItemsSource = dtStdReport.DefaultView;

            grdRreportDaily.Items.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
        }

        private void Btn_Sort_Date(object sender, RoutedEventArgs e)
        {
            //grdRreportDaily.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\StudentData.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            grdRreportDaily.ItemsSource = dtStdReport.DefaultView;
            grdRreportDaily.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
            //grdRreportDaily.Items.Refresh();
        }

        private void Btn_Back_2(object sender, RoutedEventArgs e)
        {
            HomePage hp = new HomePage();
            this.Close();
            hp.Show();
        }
    }
}
