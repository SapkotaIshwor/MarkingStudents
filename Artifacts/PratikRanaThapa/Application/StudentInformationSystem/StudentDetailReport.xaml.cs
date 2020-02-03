using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
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
    /// Interaction logic for StudentDetailReport.xaml
    /// </summary>
    public partial class StudentDetailReport : Window
    {
        public StudentDetailReport()
        {
            InitializeComponent();
            //MessageBox.Show(name);
        }

        //private void StudentDetails(DataSet dataSet, object tbRegNo, object cbProgramEnroll, object tbName, object tbAddress, object tbEmail, object tbContact, object dpDateTime)
        //{

        //    var handler = new Handler();

        //    dataSet.Tables["StudentReport"].ReadXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");

        //    var dr2 = dataSet.Tables["StudentReport"].NewRow();
        //    dr2["RegNo"] = tbRegNo;
        //    dr2["Name"] = tbName;
        //    dr2["Address"] = tbAddress;
        //    dr2["EmailId"] = tbEmail;
        //    dr2["ContactNo"] = tbContact;
        //    dr2["CourseEnroll"] = cbProgramEnroll;
        //    dr2["RegistrationDate"] = dpDateTime;

        //    dataSet.Tables["StudentReport"].Rows.Add(dr2);

        //    dataSet.Tables["StudentReport"].WriteXml(@"C:\Informatics\Coursework\Application Development\StudentReport.xml");

        //}

        private void LoadStudentData()
        {

            if (System.IO.File.Exists(@"StudentReport.xml"))
            {
                var handler = new Handler();


                var dataSet = new DataSet();

                dataSet.ReadXml(@"StudentReport.xml");

                DataTable dtStdReport = new DataTable();
                dtStdReport = dataSet.Tables[0];
                grdStudentDetails.ItemsSource = dtStdReport.DefaultView;
            }

        }

        private void btnStudentRecord_Click(object sender, RoutedEventArgs e)
        {
         

           
            LoadStudentData();
        }

        private void btnSortRegDate_Click(object sender, RoutedEventArgs e)
        {


            //create a collection view for the datasoruce binded with grid

            
     
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            LoadStudentData();
        
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            grdStudentDetails.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(@"StudentReport.xml");
            
            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            grdStudentDetails.ItemsSource = dtStdReport.DefaultView;
           
            grdStudentDetails.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            
           
        }

        private void btnSortRegDate_Click_1(object sender, RoutedEventArgs e)
        {

           
            grdStudentDetails.ItemsSource = null;
            var dataSet = new DataSet();

            dataSet.ReadXml(@"StudentReport.xml");

            DataTable dtStdReport = new DataTable();
            dtStdReport = dataSet.Tables[0];
            grdStudentDetails.ItemsSource = dtStdReport.DefaultView;
            grdStudentDetails.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
            grdStudentDetails.Items.Refresh();


        }
    }
}
