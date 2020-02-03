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
using System.Xml;

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

        

        private void generate_weekly_report(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");
                DataTable dtStdReport = dataSet.Tables[0];
                display_total_no.DataContext = dtStdReport.DefaultView;

                int application_development = 0;
                int advance_database = 0;
                int artificial_intelligence = 0;
                int information_system = 0;

                DataTable dtable = new DataTable();
                dtable.Columns.Add("Courses");
                dtable.Columns.Add("Total number of students");

                for (int i = 0; i < dtStdReport.Rows.Count; i++)
                {
                    String course = dtStdReport.Rows[i]["course"].ToString();
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

                display_total_no.ItemsSource = dtable.DefaultView;

            }

            catch
            {
                System.Windows.MessageBox.Show("No data to generate report.", "Action UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);

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
