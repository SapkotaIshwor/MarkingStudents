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
    /// Interaction logic for SortByDate.xaml
    /// </summary>
    public partial class SortByDate : Window
    {
        DataTable buffer;
        public SortByDate()
        {
            InitializeComponent();
            sortDate();
        }
        private void sortDate()
        {
            string sampleXmlFile = @"D:\Year 3\Application Development\cw1\StudentReport.xml";
            DataSet dataset = new DataSet(); 
            dataset.ReadXml(sampleXmlFile); 

            buffer = new DataTable("dt"); 
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
            gridSortDate.ItemsSource = dataView;
        }
        // setting the itemsource to table
        // code responsible sorting in ascending order, In Date ASE, DATE should match your variable from handler class
        // Displaying data
        private void SortDate_Click(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "Date ASC";
            gridSortDate.ItemsSource = dataView;
        }
    }
}
