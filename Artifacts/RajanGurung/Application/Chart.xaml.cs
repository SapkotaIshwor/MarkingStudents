using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CourseworkAppDevelopment
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();

            try {

                var dataSet = new DataSet();
                
                dataSet.ReadXml(@"StudentEnroll.xml");

                DataTable studentTable = dataSet.Tables[0];

                int computing = 0;
                
                int network= 0;
                
                int multiple= 0;

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Course", typeof(String));

                dataTable.Columns.Add("Total", typeof(int));

                for (int i = 0; i < studentTable.Rows.Count; i++) {

                    String course = studentTable.Rows[i]["StudentCourseEnroll"].ToString();
                    
                    if (course == "Computing") {

                        computing++;
                    }

                    else if (course == "Network and IT Security") {

                        network++;

                    }

                    else if (course == "Multimedia Technologies") {

                        multiple++;
                    
                    }
                }

                dataTable.Rows.Add("Computing", computing);
                
                dataTable.Rows.Add("Network and IT Security", network);
                
                dataTable.Rows.Add("Multimedia Technologies", multiple);

                ((PieSeries)display_pie_chart).ItemsSource =

                new KeyValuePair<string, int>[]{

                new KeyValuePair<string,int>("Computing", computing),

                new KeyValuePair<string,int>("Network and IT Security", network),

                new KeyValuePair<string,int>("Multimedia Technologies", multiple) };

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void display_pie_chart_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void btnChartBack_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow hwc = new HomeWindow();
            hwc.Show();
            this.Close();
        }
    }
}
