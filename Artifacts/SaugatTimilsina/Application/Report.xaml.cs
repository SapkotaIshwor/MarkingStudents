using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        String[,] returnedRecords = { };
        ReadWrite rw = new ReadWrite();
        public int computing, networking, multimedia;
        string[] str = new string[] { "Weekly tabular report", "Chart with total number of student on each program",
            "Student details (sorted by Name)", "Student details (sorted by registration date)" };
        public Report()
        {
            InitializeComponent();
            cbReport.ItemsSource = str;
            cbReport.SelectedIndex = 0;
            readData();
        }

        private void readData()
        {
            returnedRecords = rw.Read();
        }

        private void btnShowReport(object sender, RoutedEventArgs e)
        {
            String reportType = cbReport.Text;
            Console.WriteLine(reportType + " chosen");
            if (reportType == "Weekly tabular report")
            {
                weeklyTabularReport();
            }
            //Displaying Total Numbers in chart
            else if (reportType == "Chart with total number of student on each program")
            {
                calculateAndSetChart();
            }
            else if (reportType == "Student details (sorted by Name)")
            {
                AllTabularReport();
                SortDataGrid(dgStudent, 1, ListSortDirection.Ascending);
            }
            else if (reportType == "Student details (sorted by registration date)")
            {
                AllTabularReport();
                SortDataGrid(dgStudent, 7, ListSortDirection.Ascending);
            }
        }

        private void weeklyTabularReport()
        {
            multimedia = 0;computing = 0; networking = 0;
            try
            {
                string[] lines = rw.getLines();
                DateTime dateNow = DateTime.Now;
                List<String> dateTimeSubtracted = new List<String>();
                //Date Column
                for (int k = 0; k < 7; k++)
                {
                    DateTime check = dateNow.AddDays(-k);
                    String finalDate = check.ToString("yyyy'/'MM'/'dd");
                    dateTimeSubtracted.Add(finalDate);
                }
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("DateTime Subtracted: ");
                //Checking list values
                for (int k = 0; k < 7; k++)
                {
                    Console.WriteLine(dateTimeSubtracted[k]);
                }
                Console.WriteLine("\n****************************************\n");
                //Storing data from the file in variable
                for (int i = 0; i < lines.Length; i++)
                {
                    //Splitting and storing the variables in list
                    List<string> cells = lines[i].Split(',').ToList();
                    String subject = cells[4];
                    for (int j = 0; j < cells.Count; j++)
                    {
                        //Storing subject of the current line
                        if (j == 7)
                        {
                            Console.WriteLine("Date: "+ cells[j]);
                            //If the date is of current week
                            if (dateTimeSubtracted.Contains(cells[j]))
                            {
                                if (subject == "Multimedia Technologies")
                                {
                                    multimedia++;
                                    Console.WriteLine("Subject: Multimedia");
                                }
                                else if (subject == "Computing")
                                {
                                    computing++;
                                    Console.WriteLine("Subject: Computing");
                                }
                                else if (subject == "Network & IT Security")
                                {
                                    networking++;
                                    Console.WriteLine("Subject: Networking & IT Security");
                                }
                            }
                            //allDate.Add(cells[j]);
                        }
                    }
                }
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("For this week:");
                Console.WriteLine("Multimedia:" + multimedia);
                Console.WriteLine("Computing:" + computing);
                Console.WriteLine("Networking & IT Security:" + networking);
                List<StudentCount> details = new List<StudentCount>();
                details.Add(new StudentCount() { Programme = "Computing", Students = computing });
                details.Add(new StudentCount() { Programme = "Multimedia Technologies", Students = multimedia });
                details.Add(new StudentCount() { Programme = "Network & IT Security", Students = networking });
                dgStudent.ItemsSource = details;
                dgStudent.Columns[0].Width = 400;
                dgStudent.Columns[1].Width = 500;

            }
            catch (Exception e)
            {
                MessageBox.Show("The data file is corrupted.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex, ListSortDirection sortDirection)
        {
            var column = dataGrid.Columns[columnIndex];
            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();
            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));
            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;
            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }

        private void btnShowDashboard(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }

        private void AllTabularReport()
        {
            List<AllStudentDetails> allStudentDetails = new List<AllStudentDetails>();
            for (int i = 0; i < returnedRecords.GetLength(0); i++)
            {
                allStudentDetails.Add(new AllStudentDetails() {
                    Id = returnedRecords[i, 0],
                    FirstName = returnedRecords[i, 1],
                    LastName = returnedRecords[i, 2],
                    Address = returnedRecords[i, 3],
                    Program = returnedRecords[i, 4],
                    Email = returnedRecords[i, 5],
                    Contact = returnedRecords[i, 6],
                    Date = returnedRecords[i, 7]
                });
            }
            dgStudent.ItemsSource = allStudentDetails;
            dgStudent.Columns[0].Width = 30;
            dgStudent.Columns[1].Width = 100;
            dgStudent.Columns[2].Width = 100;
            dgStudent.Columns[3].Width = 100;
            dgStudent.Columns[4].Width = 100;
            dgStudent.Columns[5].Width = 120;
            dgStudent.Columns[7].Width = 110;
        }

        private void calculateAndSetChart()
        {
            multimedia = 0; computing = 0; networking = 0;
            //int rowsOrHeight = ary.GetLength(0);
            //int colsOrWidth = ary.GetLength(1);
            Console.WriteLine("Returned Record Length: " + returnedRecords.Length);
            for (int i = 0; i <returnedRecords.GetLength(0); i++)
            {
                Console.WriteLine("Value at : [" + i + ", 4]" + returnedRecords[i, 3]);
                if (returnedRecords[i,4]== "Multimedia Technologies")
                {
                    multimedia++;
                }
                else if (returnedRecords[i,4] == "Computing")
                {
                    computing++;
                }
                else if (returnedRecords[i,4] == "Network & IT Security")
                {
                    networking++;
                }
            }
            List<StudentCount> details = new List<StudentCount>();
            details.Add(new StudentCount() { Programme = "Computing", Students = computing });
            details.Add(new StudentCount() { Programme = "Multimedia Technologies", Students = multimedia});
            details.Add(new StudentCount() { Programme = "Network & IT Security", Students = networking});
            dgStudent.ItemsSource = details;
            dgStudent.Columns[0].Width = 400;
            dgStudent.Columns[1].Width = 500;
            Window1 chart = new Window1();
            chart.Show();
            chart.setGraph(new String[] {"Computing", "Multimedia Technologies", "Network & IT Security"}, new int[] {computing, multimedia, networking});
        }
    }


    public class AllStudentDetails
    {
            public String Id { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Contact { get; set; }
            public String Email { get; set; }
            public String Address { get; set; }
            public String Program { get; set; }
            public String Date { get; set; }
    }

    public class StudentCount
    {
        public String Programme { get; set; }
        public int Students { get; set; }
    }
}
