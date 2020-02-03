using System;
using System.Collections.Generic;
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

namespace Student_info
{
    /// <summary>
    /// Interaction logic for WeeklyReportWindow.xaml
    /// </summary>
    public partial class WeeklyReportWindow : Window
    {
        string path = @"D:\Student_Management\StudentRegistrationData.xml";
        int ITData;
        int mgtData;
        int eduData;
        int BITData;
        int CSITData;
        int literatureData;
        int teachingData;
        int bbaData;
        int bbsData;
        public WeeklyReportWindow()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();

            try
            {

                if (System.IO.File.Exists(path))
            {

                    dataSet.ReadXml(path);

                    DataTable stdReportTbl = dataSet.Tables["Student"];
                    DataTable dv = stdReportTbl.Select("").CopyToDataTable();
                    //filtering date of one week

                    //counting total number of student registered in a week
                    ITData = stdReportTbl.Select("Department = 'IT' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    mgtData = stdReportTbl.Select("Department = 'Management' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    eduData = stdReportTbl.Select("Department = 'Education' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    //faculty
                    BITData = stdReportTbl.Select("Faculty = 'BIT' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    CSITData = stdReportTbl.Select("Faculty = 'BSCIT' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    literatureData = stdReportTbl.Select("Faculty = 'Literature' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    teachingData = stdReportTbl.Select("Faculty = 'Teaching' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    bbaData = stdReportTbl.Select("Faculty = 'BBA' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                    bbsData = stdReportTbl.Select("Faculty = 'BBS' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();

                    //asigning value to label 
                    itDepartLbl.Content = ITData;
                    mgtDepartLbl.Content = mgtData;
                    eduDepartLbl.Content = eduData;

                    //faculty
                    bitLbl.Content = BITData;
                    CSITLbl.Content = CSITData;
                    literatureLbl.Content = literatureData;
                    teachingLbl.Content = teachingData;
                    bbaLbl.Content = bbaData;
                    bbsLbl.Content = bbsData;


                }
            else
                {
                    System.Windows.MessageBox.Show("Sorry! XML file is missing", "FIle Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Sorry! Error occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    ReportMainWindow rpw = new ReportMainWindow();
                    rpw.Show();

                }
            }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
            ReportMainWindow rpw = new ReportMainWindow();
            rpw.Show();
        }
    }

}
