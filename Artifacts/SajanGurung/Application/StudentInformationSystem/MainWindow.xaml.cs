using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using Microsoft.Win32;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean err;
        private String errMsg;
        private String sortName = "asc";
        private String sortRegistrationDate = "asc";

        public MainWindow()
        {
            InitializeComponent();

            // Change the format of the date picker
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            ci.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        /**
         * Enrol students and save the data in a file.
         */
        private void btnEnrol_Click(object sender, RoutedEventArgs e)
        {
            String name = txtName.Text.ToString();
            String dob = txtDob.Text.ToString();
            String address = txtAddress.Text.ToString();
            String contact = txtContact.Text.ToString();
            String course = txtCourse.Text.ToString();
            String registrationDate = txtRegistrationDate.Text.ToString();

            // Validation
            err = false;
            errMsg = "";

            if (name.Length <= 0)
            {
                err = true;
                errMsg += "Name is required.\n";
            }

            if (dob.Length <= 0)
            {
                err = true;
                errMsg += "DOB is required.\n";
            }

            if (address.Length <= 0)
            {
                err = true;
                errMsg += "Address is required.\n";
            }

            if (contact.Length <= 0)
            {
                err = true;
                errMsg += "Contact no. is required.\n";
            }

            if (course.Length <= 0)
            {
                err = true;
                errMsg += "Course is required.\n";
            }

            if (registrationDate.Length <= 0)
            {
                err = true;
                errMsg += "Registration date is required.\n";
            }

            if (err)
            {
                // If validation fails
                MessageBox.Show(errMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If validation succeeds
                try
                {
                    String id = GetTimestamp();
                    String csv = id + "," + name + "," + dob + "," + address + "," + contact + "," + course + "," + registrationDate + "\r\n";

                    // Create a csv file and add students data
                    File.AppendAllText("students.csv", csv);
                    MessageBox.Show("Student enroled successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Clear fields
                    txtName.Text = String.Empty;
                    txtDob.Text = String.Empty;
                    txtAddress.Text = String.Empty;
                    txtContact.Text = String.Empty;
                    txtCourse.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /**
         * Generate current timestamp.
         */
        private static String GetTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /**
         * Import students and save the data in a file.
         */
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true }; // Allow only csv file to open
                
                if (fileDialog.ShowDialog() == true)
                {
                    // If file opens successfully
                    using (var streamReader = new StreamReader(new FileStream(fileDialog.FileName, FileMode.Open)))
                    {
                        // Skip first line and add data to a csv file 'students.csv'
                        String line;
                        int counter = 0;

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (counter != 0)
                            {
                                String[] data = line.Split(',');
                                String csv = GetTimestamp() + "," + data[0] + "," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "\r\n";
                                File.AppendAllText("students.csv", csv);
                            }

                            counter++;
                        }
                    }
                    
                    MessageBox.Show("Student imported successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Handle request on tab selection.
         */
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Name as string;

            switch (tabItem)
            {
                case "tabStudents":
                    GenerateStudents();
                    break;

                case "tabReport":
                    GenerateReport();
                    break;

                case "tabChart":
                    GenerateChart();
                    break;

                case "tabLogout":
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                    break;

                default:
                    return;
            }
        }

        /**
         * List all the students.
         */
        private void GenerateStudents()
        {
            try
            {
                String line;
                List<Student> students = new List<Student>();
                using (StreamReader streamReader = new StreamReader("students.csv"))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] data = line.Split(',');
                        students.Add(new Student() { ID = data[0], Name = data[1], DOB = data[2], Contact = data[3], Address = data[4], Course = data[5], RegistrationDate = data[6] });
                    }
                }

                gridStudents.ItemsSource = students; // Add students info in data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Sort students by name.
         */
        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = new List<Student>();
            students = (List<Student>)gridStudents.ItemsSource;

            if (sortName.Equals("asc"))
            {
                List<Student> sortedList = students.OrderBy(o => o.Name).ToList();
                gridStudents.ItemsSource = sortedList;
                sortName = "desc";
            }
            else
            {
                List<Student> sortedList = students.OrderByDescending(o => o.Name).ToList();
                gridStudents.ItemsSource = sortedList;
                sortName = "asc";
            }
        }

        /**
         * Sort students by registration date.
         */
        private void btnSortRegistrationDate_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = new List<Student>();
            students = (List<Student>)gridStudents.ItemsSource;

            if (sortRegistrationDate.Equals("asc"))
            {
                List<Student> sortedList = students.OrderBy(o => o.RegistrationDate).ToList();
                gridStudents.ItemsSource = sortedList;
                sortRegistrationDate = "desc";
            }
            else
            {
                List<Student> sortedList = students.OrderByDescending(o => o.RegistrationDate).ToList();
                gridStudents.ItemsSource = sortedList;
                sortRegistrationDate = "asc";
            }
        }

        /**
         * Create a report for the total no. of students enroled in all courses.
         */
        private void GenerateReport()
        {
            try
            {
                String line;
                int appDev = 0;
                int ai = 0;
                int advDb = 0;

                using (StreamReader streamReader = new StreamReader("students.csv"))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] data = line.Split(',');

                        if (data[5].Equals("Application Development"))
                        {
                            appDev++;
                        }
                        else if (data[5].Equals("Artificial Intelligence"))
                        {
                            ai++;
                        }
                        else if (data[5].Equals("Advance Database"))
                        {
                            advDb++;
                        }
                    }
                }

                // Add course info in the data grid
                List<Course> courses = new List<Course>();
                courses.Add(new Course() { SN = "1.", Program = "Application Development", TotalStudent = appDev });
                courses.Add(new Course() { SN = "2.", Program = "Artificial Intelligence", TotalStudent = ai });
                courses.Add(new Course() { SN = "3.", Program = "Advance Database", TotalStudent = advDb });
                
                gridReport.ItemsSource = courses; // Add course info in data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Create a chart showing the total no. of students enroled in all courses.
         */
        private void GenerateChart()
        {
            try
            {
                String line;
                int appDev = 0;
                int ai = 0;
                int advDb = 0;

                using (StreamReader streamReader = new StreamReader("students.csv"))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        String[] data = line.Split(',');

                        if (data[5].Equals("Application Development"))
                        {
                            appDev++;
                        }
                        else if (data[5].Equals("Artificial Intelligence"))
                        {
                            ai++;
                        }
                        else if (data[5].Equals("Advance Database"))
                        {
                            advDb++;
                        }
                    }
                }

                PointLabel = chartPoint =>
                    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                pieChart.Series = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Application Development",
                        Values = new ChartValues<double> {appDev},
                        DataLabels = true
                    },
                    new PieSeries
                    {
                        Title = "Artificial Intelligence",
                        Values = new ChartValues<double> {ai},
                        DataLabels = true
                    },
                    new PieSeries
                    {
                        Title = "Advance Database",
                        Values = new ChartValues<double> {advDb},
                        DataLabels = true
                    }
                };

                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            // Clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
