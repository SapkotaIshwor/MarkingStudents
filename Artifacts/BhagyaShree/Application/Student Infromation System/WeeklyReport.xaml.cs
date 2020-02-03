using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Student_Infromation_System
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home back = new Home();
            back.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                String line;
                int computing = 0;
                int multimedia = 0;
                int network = 0;

                using (StreamReader streamReader = new StreamReader("students.csv"))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] data = line.Split(',');

                        if (data[3].Equals("Computing"))
                        {
                            computing++;
                        }
                        else if (data[3].Equals("Multimedia Technologies"))
                        {
                            multimedia++;
                        }
                        else if (data[3].Equals("Networks and IT Security"))
                        {
                            network++;
                        }
                    }
                }

                // Add course info in the data grid
                List<WeeklyReportData> weeklyReport = new List<WeeklyReportData>();
                weeklyReport.Add(new WeeklyReportData() { Programme = "Computing", TotalStudent = computing });
                weeklyReport.Add(new WeeklyReportData() { Programme = "Multimedia Technologies", TotalStudent = multimedia });
                weeklyReport.Add(new WeeklyReportData() { Programme = "Networks and IT Security", TotalStudent = network });
                
                dataGridWeek.ItemsSource = weeklyReport;          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
