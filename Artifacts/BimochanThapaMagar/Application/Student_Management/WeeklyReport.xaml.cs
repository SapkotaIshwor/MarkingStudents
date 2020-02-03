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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for WeeklyReport.xaml
    /// </summary>
    public partial class WeeklyReport : Window
    {
        public WeeklyReport()
        {
            InitializeComponent();
            var handler = new Handler();

            var dataSet = handler.GenerateDataSet();


            if (System.IO.File.Exists(@"D:\StudentData.xml"))
            {


                dataSet.ReadXml(@"D:\StudentData.xml");

                DataTable weeklyReport = dataSet.Tables["StudentInfo"];

                int computing = weeklyReport.Select("Program = 'Computing' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                int mt = weeklyReport.Select("Program = 'Multimedia Technology' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();
                int ns = weeklyReport.Select("Program = 'Networks and IT security' AND RegistrationDate>='" + DateTime.Today.AddDays(-7) + "'").Count<DataRow>();

                ////asigning value to label 
                //computing_lbl.Content = computing;
                //mtLbl.Content = mt;
                //ntLbl.Content = ns;

            }
            else
            {
                MessageBox.Show("File not found");
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
