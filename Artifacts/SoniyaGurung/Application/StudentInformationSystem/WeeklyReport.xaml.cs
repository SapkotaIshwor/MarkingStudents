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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window
    {
        public WeeklyReport()
        {
            InitializeComponent();
        }

        private void BtnGweeklyR(object sender, RoutedEventArgs e)
        {
            var dataset = new DataSet(); //new data set declared
            dataset.ReadXml(@"C:\XML\student.xml");  //main report read
            DataTable stdReport = dataset.Tables[0];
            int CompTotal = 0;   //initial value of course assign 
            int MultiTotal = 0;
            int NetTotal = 0;

            DataTable dTable = new DataTable("DataT");
            dTable.Columns.Add("Course Enroll", typeof(String));  //two columns created
            dTable.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < stdReport.Rows.Count; i++)
            {
                String col = stdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Computing")
                {
                    CompTotal++;
                }
                else if (col == "Multimedia Technologies")
                {
                    MultiTotal++;
                }
                else if (col == "Networks and IT Security")
                {
                    NetTotal++;
                }
            }

            dTable.Rows.Add("Computing", CompTotal); // final assign
            dTable.Rows.Add("Multimedia Technologies", MultiTotal);
            dTable.Rows.Add("Networks and IT Security", NetTotal);

            WeeklyDataGrid.ItemsSource = dTable.DefaultView; // weekly data grid
        }       
    }    
}
