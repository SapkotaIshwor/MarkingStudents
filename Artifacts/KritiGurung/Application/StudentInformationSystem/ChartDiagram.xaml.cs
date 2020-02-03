using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for BarDiagram.xaml
    /// </summary>
    public partial class ChartDiagram : Window
    {

        public ChartDiagram()
        {
            InitializeComponent();

            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");

                DataTable studentDataReport = dataSet.Tables[0];

                int application_development = 0;
                int advance_database = 0;
                int artificial_intelligence = 0;
                int information_system = 0;

                DataTable dtable = new DataTable();
                dtable.Columns.Add("Courses");
                dtable.Columns.Add("Total number of students");

                for (int i = 0; i < studentDataReport.Rows.Count; i++)
                {
                    String course = studentDataReport.Rows[i]["course"].ToString();
                    if (course == "Application Development")
                    {
                        application_development++;
                    }
                    else if (course == "Advance Database")
                    {
                        advance_database++;
                    }
                    else if (course == "Artificial Intelligence")
                    {
                        artificial_intelligence++;
                    }
                    else if (course == "Information System")
                    {
                        information_system++;
                    }
                }

                dtable.Rows.Add("Application Development", application_development);
                dtable.Rows.Add("Advance Database", advance_database);
                dtable.Rows.Add("Artificial Intelligence", artificial_intelligence);
                dtable.Rows.Add("Information System", information_system);

                ((PieSeries)display_pie_chart).ItemsSource =
                new KeyValuePair<string, int>[]{
            new KeyValuePair<string,int>("Application Development", application_development),
            new KeyValuePair<string,int>("Advance Database", advance_database),
            new KeyValuePair<string,int>("Artificial Intelligence", artificial_intelligence),
            new KeyValuePair<string,int>("Information System", information_system)};
            }

            catch
            {
                System.Windows.MessageBox.Show("No data to create Pie chart.", "Action UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);

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
