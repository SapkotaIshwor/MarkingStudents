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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentReport.xaml
    /// </summary>
    public partial class StudentReport
    {
        DataTable buffer;
        public StudentReport()
        {
            InitializeComponent();
        }
        private void display_info()
        {
            string displayreport = @"D:\studentData.xml";
            DataSet dataset = new DataSet();
            dataset.ReadXml(displayreport);

            buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("Phone", typeof(String));
            buffer.Columns.Add("CourseEnroll", typeof(String));
            buffer.Columns.Add("RegistrationDate", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());
            }
            DataView datainfo = new DataView(buffer);
            DataGridReport.ItemsSource = datainfo;
        }
        private void btn_retrive_Click(object sender, RoutedEventArgs e)
        {
            display_info();
        }

        private void btn_sortbydate_Click(object sender, RoutedEventArgs e)
        {
            DataView view = new DataView(buffer);
            view.Sort = "RegistrationDate ASC";
            DataGridReport.ItemsSource = view;
        }

        private void btn_sortbyname_Click(object sender, RoutedEventArgs e)
        {
            DataView view = new DataView(buffer);
            view.Sort = "Name ASC";
            DataGridReport.ItemsSource = view;
        }

        private void btn_weeklyreport_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();

            dataSet.ReadXml(@"D:\studentData.xml");

            DataTable dtStdReport = dataSet.Tables[0];

            int total_Networking = 0;
            int total_Multimedia = 0;
            int total_Computing = 0;

            DataTable dt = new DataTable("newTable");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dtStdReport.Rows.Count; i++)
            {
                String col = dtStdReport.Rows[i]["CourseEnroll"].ToString();
                if (col == "Networking")
                {
                    total_Networking++;
                }
                else if (col == "Multimedia")
                {
                    total_Multimedia++;
                }
                else if (col == "Computing")
                {
                    total_Computing++;
                }

            }

            dt.Rows.Add("Networking", total_Networking);
            dt.Rows.Add("Multimedia", total_Multimedia);
            dt.Rows.Add("Computing", total_Computing);

            DataGridReport.DataContext = dt.DefaultView;
        }

        private void btn_chart_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }

        private void btn_Csv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\studentData.xml");
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    string filename = dialog.FileName;
                    using (var read = new StreamReader(filename))
                    {
                        read.ReadLine();
                        while (!read.EndOfStream)
                        {
                            var line = read.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["StudentInfo"].NewRow();

                            newRow["ID"] = values[0];
                            newRow["Name"] = values[1];
                            newRow["Address"] = values[2];
                            newRow["Phone"] = values[3];
                            newRow["CourseEnroll"] = values[4];
                            newRow["RegistrationDate"] = values[5];
                            dataSet.Tables["StudentInfo"].Rows.Add(newRow);

                            dataSet.WriteXml(@"D:\studentData.xml");
                        }
                    }
                    MessageBox.Show("Student record sucessfully imported");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
