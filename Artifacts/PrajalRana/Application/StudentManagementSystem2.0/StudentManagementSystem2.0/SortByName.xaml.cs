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

namespace StudentManagementSystem2._0 {
    /// <summary>
    /// Interaction logic for SortByName.xaml
    /// </summary>
    public partial class SortByName : Window {
        DataTable buffer;
        public SortByName() {
            InitializeComponent();
            sortByName();
        }

        private void gridSortByName_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            
        }
        private void sortByName() {
            string sampleXmlFile = @"E:\College\3rd Year\Application Development\StudentReport.xml";
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
            gridSortByName .ItemsSource = dataView;
        }

        private void btnSortByName_Click(object sender, RoutedEventArgs e) {
            DataView dataView = new DataView(buffer); // setting the itemsource to table
            dataView.Sort = "Name ASC";
            gridSortByName.ItemsSource = dataView;

        }
    }
}
