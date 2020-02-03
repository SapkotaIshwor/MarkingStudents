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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        private string sortBy = "name";

        public Report()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home back = new Home();
            back.ShowDialog();
        }

        /**
         * Sort by name.
         */
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sortBy = "name";
        }

        /**
         * Sort by reg dates.
         */
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            sortBy = "date";
        }

        /**
         * Generate report.
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string line;
                List<StudentDetails> students = new List<StudentDetails>();

                using (StreamReader reader = new StreamReader("students.csv"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] details = line.Split(',');
                        students.Add(new StudentDetails(details[0], details[1], details[2], details[3], details[4], details[5]));
                    }
                }

                if (sortBy.Equals("name"))
                {
                    List<StudentDetails> sortedStudents = students.OrderBy(o => o.StudentName).ToList();
                    gridStudents.ItemsSource = sortedStudents;
                }
                else
                {
                    List<StudentDetails> sortedStudents = students.OrderBy(o => o.RegistrationDate).ToList();
                    gridStudents.ItemsSource = sortedStudents;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }        
}
    


