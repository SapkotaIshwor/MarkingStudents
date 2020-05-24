using DataHandler;
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

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for Stddetails.xaml
    /// </summary>
    public partial class Stddetails : Window
    {
        public Stddetails()
        {
            InitializeComponent();
        }
        private void display_Report()
        {
            string sampleXmlFile = @"D:\Year 3\Application Development\cw1\StudentReport.xml";
            DataSet dataset = new DataSet();
            dataset.ReadXml(sampleXmlFile);

            DataTable buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("ContactNo", typeof(String));
            buffer.Columns.Add("EmailAddress", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("Date", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][6].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dataset.Tables[0].Rows[i][5].ToString(),
                    dtime.ToShortDateString());

            }

            DataView dataView = new DataView(buffer); // setting the itemsource to table 
            grdStudentDetails.ItemsSource = dataView;  // viewing?  
        }

        private void btnStudentDetails_Click(object sender, RoutedEventArgs e)
        {
            display_Report();
        }
    }
}
