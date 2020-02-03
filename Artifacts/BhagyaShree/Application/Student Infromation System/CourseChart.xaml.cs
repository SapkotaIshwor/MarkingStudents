using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Student_Infromation_System
{
    /// <summary>
    /// Interaction logic for CourseChart.xaml
    /// </summary>
    public partial class CourseChart : Window
    {
        public CourseChart()
        {
            InitializeComponent();

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

                SeriesCollection = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Computing",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(computing) },
                        DataLabels = true
                    },
                    new PieSeries
                    {
                        Title = "Multimedia Technologies",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(multimedia) },
                        DataLabels = true
                    },
                    new PieSeries
                    {
                        Title = "Networks and IT Security",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(network) },
                        DataLabels = true
                    }
                };

                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home back = new Home();
            back.ShowDialog();
        }
    }
}
