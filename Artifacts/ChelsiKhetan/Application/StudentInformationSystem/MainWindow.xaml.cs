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
using Microsoft.Win32;
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;
using System.Threading;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean error;
        private String errorMsg;
        private String sortName = "asc";
        private String sortRegistrationDate = "asc";

        public MainWindow()
        {
            InitializeComponent();

            // Change datepicker format
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            ci.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        /**
         * Enrol student.
         */
        private void btnEnrolStudent_Click(object sender, RoutedEventArgs e)
        {
            // Fetch data from form
            String studentName = txtStudentName.Text.ToString();
            String address = txtAddress.Text.ToString();
            String dob = txtDob.Text.ToString();
            String contact = txtContactNo.Text.ToString();
            String course = cbCourse.Text.ToString();
            String registrationDate = txtRegistrationDate.Text.ToString();

            // Form validation
            error = false;
            errorMsg = "";

            if (studentName.Length <= 0)
            {
                error = true;
                errorMsg += "Student name is required.\n";
            }

            if (address.Length <= 0)
            {
                error = true;
                errorMsg += "Address is required.\n";
            }

            if (dob.Length <= 0)
            {
                error = true;
                errorMsg += "DOB is required.\n";
            }

            if (contact.Length <= 0)
            {
                error = true;
                errorMsg += "Contact no. is required.\n";
            }

            if (course.Length <= 0)
            {
                error = true;
                errorMsg += "Please select a course.\n";
            }

            if (registrationDate.Length <= 0)
            {
                error = true;
                errorMsg += "Registration date is required.\n";
            }

            // If there is error in the form
            if (error == true)
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If there is no error in the form
                try
                {
                    String studentId = GetTimestamp(); // Generate a student ID
                    String csv = studentId + "," + studentName + "," + address + "," + dob + "," + contact + "," + course + "," + registrationDate + "\r\n";

                    // Add student data in 'students.csv'
                    // If there is no file, the file is automatically created
                    File.AppendAllText("students.csv", csv);
                    MessageBox.Show("Student enroled successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    // Clear form fields
                    txtStudentName.Text = String.Empty;
                    txtAddress.Text = String.Empty;
                    txtDob.Text = String.Empty;
                    txtContactNo.Text = String.Empty;
                    txtRegistrationDate.Text = String.Empty;
                    cbCourse.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /**
         * Generate a timestamp and return the value.
         */
        private string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /**
         * Import students from csv file.
         */
        private void btnImportStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a dialog box and allow only csv file to open
                OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true };

                // If a file is opened
                if (openFileDialog.ShowDialog() == true)
                {
                    using (var file = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open)))
                    {
                        String row;

                        int counter = 1;

                        // Fetch every line of code and assign it to 'row' variable
                        while ((row = file.ReadLine()) != null)
                        {
                            // Skip the first line, which is label
                            if (counter != 1)
                            {
                                String[] txtArr = row.Split(','); // Split the row from ',' and assign it to txtArr in the form of array
                                String csv = txtArr[0] + "," + txtArr[1] + "," + txtArr[2] + "," + txtArr[3] + "," + txtArr[4] + "," + txtArr[5] + "," + txtArr[6] + "\r\n";

                                // Add student data in 'students.csv'
                                // If there is no file, the file is automatically created
                                File.AppendAllText("students.csv", csv);
                            }

                            counter++;
                        }
                    }

                    MessageBox.Show("Students imported successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Run this function on clicking tab.
         */
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItemName = ((sender as TabControl).SelectedItem as TabItem).Name as string;

            switch (tabItemName)
            {
                case "tabStudents":
                    addStudentIntoDataGrid();
                    break;

                case "tabReport":
                    addCourseIntoDataGrid();
                    break;

                case "tabChart":
                    addChartIntoGrid();
                    break;

                case "tabLogout":
                    // Open login window and close this window.
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                    break;

                default:
                    return;
            }
        }

        /**
         * Add students into data grid from csv file.
         */
        private void addStudentIntoDataGrid()
        {
            try
            {
                String row;
                List<Student> studentList = new List<Student>();

                // Open the csv file containing students data
                using (StreamReader file = new StreamReader("students.csv"))
                {
                    while ((row = file.ReadLine()) != null)
                    {
                        String[] txtArr = row.Split(','); // Split the row from ',' and assign it to txtArr in the form of array
                        studentList.Add(new Student() { ID = txtArr[0], Name = txtArr[1], Address = txtArr[2], DOB = txtArr[3], Contact = txtArr[4], Course = txtArr[5], RegistrationDate = txtArr[6] });
                    }
                }
                    
                dataGridStudents.ItemsSource = studentList; // Insert students into data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Sort students by name.
         */
        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            // Fetch students from data grid and assign it to 'studentList'
            List<Student> studentList = new List<Student>();
            studentList = (List<Student>)dataGridStudents.ItemsSource;

            if (sortName.Equals("asc"))
            {
                List<Student> sortedStudentList = studentList.OrderBy(o => o.Name).ToList(); // Sort students by name
                dataGridStudents.ItemsSource = sortedStudentList; // Insert sorted list in data grid
                sortName = "desc";
            }
            else
            {
                List<Student> sortedStudentList = studentList.OrderByDescending(o => o.Name).ToList(); // Sort students by name
                dataGridStudents.ItemsSource = sortedStudentList; // Insert sorted list in data grid
                sortName = "asc";
            }
        }

        /**
        * Sort students by registration date.
        */
        private void btnSortRegistrationDate_Click(object sender, RoutedEventArgs e)
        {
            // Fetch students from data grid and assign it to 'studentList'
            List<Student> studentList = new List<Student>();
            studentList = (List<Student>)dataGridStudents.ItemsSource;

            if (sortRegistrationDate.Equals("asc"))
            {
                List<Student> sortedStudentList = studentList.OrderBy(o => o.RegistrationDate).ToList(); // Sort students by registration date
                dataGridStudents.ItemsSource = sortedStudentList; // Insert sorted list in data grid
                sortRegistrationDate = "desc";
            }
            else
            {
                List<Student> sortedStudentList = studentList.OrderByDescending(o => o.RegistrationDate).ToList(); // Sort students by registration date
                dataGridStudents.ItemsSource = sortedStudentList; // Insert sorted list in data grid
                sortRegistrationDate = "asc";
            }
        }

        /**
         * Add course information into data grid from csv file.
         */
        private void addCourseIntoDataGrid()
        {
            try
            {
                String row;
                int computingCount = 0;
                int multimediaCount = 0;
                int networksCount = 0;

                // Open the csv file containing students data
                using (StreamReader file = new StreamReader("students.csv"))
                {
                    while ((row = file.ReadLine()) != null)
                    {
                        String[] txtArr = row.Split(','); // Split the row from ',' and assign it to txtArr in the form of array

                        if (txtArr[5].Equals("Computing"))
                        {
                            computingCount++;
                        }
                        else if (txtArr[5].Equals("Multimedia"))
                        {
                            multimediaCount++;
                        }
                        else if (txtArr[5].Equals("IT Security"))
                        {
                            networksCount++;
                        }
                    }
                }

                List<Report> reportList = new List<Report>();
                reportList.Add(new Report() { Program = "Computing", TotalStudents = computingCount });
                reportList.Add(new Report() { Program = "Multimedia", TotalStudents = multimediaCount });
                reportList.Add(new Report() { Program = "IT Security", TotalStudents = networksCount });
                
                dataGridReport.ItemsSource = reportList; // Insert report into data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /**
         * Add chart into grid from csv file.
         */
        private void addChartIntoGrid()
        {
            try
            {
                String row;
                int computingCount = 0;
                int multimediaCount = 0;
                int networksCount = 0;

                // Open the csv file containing students data
                using (StreamReader file = new StreamReader("students.csv"))
                {
                    while ((row = file.ReadLine()) != null)
                    {
                        String[] txtArr = row.Split(','); // Split the row from ',' and assign it to txtArr in the form of array

                        if (txtArr[5].Equals("Computing"))
                        {
                            computingCount++;
                        }
                        else if (txtArr[5].Equals("Multimedia"))
                        {
                            multimediaCount++;
                        }
                        else if (txtArr[5].Equals("IT Security"))
                        {
                            networksCount++;
                        }
                    }
                }

                SeriesCollection = new SeriesCollection();

                SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Total Students",
                        Values = new ChartValues<int> { computingCount, multimediaCount, networksCount }
                    }
                );

                Labels = new[] { "Computing", "Multimedia", "IT Security" };
                Formatter = value => value.ToString("N");

                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }
    }
}
