using DataHandler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Startup();

            LoadStudentData();

        }

        public void Startup()
        {
            //var handler = new Handler();
            //var dataSet = handler.CreateDataSet();
            //AddSampleData(dataSet);
            //dataSet.WriteXmlSchema(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWSchema.xml");
            //dataSet.WriteXml(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWData.xml");

            //var dataSet = new DataSet();
            //dataSet.ReadXmlSchema(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWSchema.xml");
            //dataSet.ReadXml(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWData.xml");

            var i = 0;
        }

        private void AddSampleData(DataSet dataSet)
        {
            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Network & Communication";
            dr["DisplayText"] = "BCA Network";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "Programming & Application Development";
            dr["DisplayText"] = "BSc CSIT Application Development";
            dataSet.Tables["Course"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = txtname.Text;
            dr["Address"] = txtAddress.Text;
            dr["ContactNo"] = txtContact.Text;
            dr["CourseEnroll"] = 1;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Kapil Raj Gurung";
            dr["Address"] = "Pokhara";
            dr["ContactNo"] = "9851220845";
            dr["CourseEnroll"] = 1;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-2);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Samyam Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220846";
            dr["CourseEnroll"] = 2;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-1);
            dataSet.Tables["Student"].Rows.Add(dr);

            dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = "Safal Sapkota";
            dr["Address"] = "Kathmandu";
            dr["ContactNo"] = "9851220847";
            dr["CourseEnroll"] = 3;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

        }
        private void AddStudentData(DataSet dataSet)
        {
            var dr = dataSet.Tables["Course"].NewRow();
            dr["Name"] = "BBA";
            dr["DisplayText"] = "BBA Hons";
            dataSet.Tables["Course"].Rows.Add(dr);


            dr = dataSet.Tables["Student"].NewRow();
            dr["RegisterNumber"] = txtregister.Text;
            dr["Name"] = txtname.Text;
            dr["Address"] = txtAddress.Text;
            dr["ContactNo"] = txtContact.Text;
            dr["CourseEnroll"] = txtcourseEnroll.Text;
            dr["RegistrationDate"] = DateTime.Today.AddDays(-3);
            dataSet.Tables["Student"].Rows.Add(dr);

          
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AddStudentData(dataSet);
            dataSet.WriteXmlSchema(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWSchema.xml");
            dataSet.WriteXml(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWData.xml");
        }
        private void LoadStudentData() {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            dataSet.ReadXml(@"C:\Users\Kapil\Downloads\y3\app dev\xml\StudentCWData.xml");
            DataTable dtStd = new DataTable();
            dtStd = dataSet.Tables[1];
            grdStd.DataContext = dtStd.DefaultView;

        }
    }
}
