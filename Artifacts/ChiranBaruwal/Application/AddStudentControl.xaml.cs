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

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for AddStudentControl.xaml
    /// </summary>
    public partial class AddStudentControl : UserControl
    {
        private FileHandler fileHandler = new FileHandler();
        public AddStudentControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int studentID = int.Parse(stuIdTB.Text);
                string studentName = stuNameTB.Text;
                string studentAddress = stuAddressTB.Text;
                string studentPhone = stuNumTB.Text;
                string courseEnrolled = stdCourseCB.Text;
                DateTime regDate = regDateDT.DisplayDate;

                if (studentName != "" && studentAddress != "" && studentPhone != "" && courseEnrolled != "")
                {
                    fileHandler.saveData(studentID, studentName, studentAddress, studentPhone, courseEnrolled, regDate);

                    MessageBox.Show("Data saved successfully!");
                }
                else
                {
                    MessageBox.Show("One or more fields are empty. Please fill in all the information.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Student ID!");
            }
        }
    }
}
