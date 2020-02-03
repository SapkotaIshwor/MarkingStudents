using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        private int course;
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory+ "\\StudentCWData.xml";
        public AddCourse()
        {
            InitializeComponent();
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            if (File.Exists(CurrentPath))
            {
                dataSet.ReadXml(CurrentPath);
            }
            else
            {
                dataSet.WriteXml(CurrentPath);
            }
            
        }

        private void savveCourse_Click(object sender, RoutedEventArgs e)
        {
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            SaveCourse(dataSet);
    
            if (ValidateInputs())
            {
                if (File.Exists(CurrentPath))
                {
                    dataSet.ReadXml(CurrentPath);
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Course Added Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                }
                else
                {
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Course Added Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                }

            }
        }
        //This method is used to save course data in xml by taking input from form
        private void SaveCourse(DataSet dataSet)
        {
            var dr = dataSet.Tables["Course"].NewRow();
            dr["CourseName"] = courseName.Text;
            dr["CreditHours"] = courseFee.Text;
            dr["CourseFee"] = creditHours.Text;
            dataSet.Tables["Course"].Rows.Add(dr);
        }
        //this method is used to clear fields
        public void clearText()
        {
            courseName.Text = "";
            courseFee.Text = "";
            creditHours.Text = "";
            
        }
        //This method is used to check the user input
        public Boolean ValidateInputs()
        {
            if (courseName.Text.Equals(""))
            {
                MessageBox.Show("Course Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (courseFee.Text.Equals(""))
            {
                MessageBox.Show("Course Fee Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (creditHours.Text.Equals(""))
            {
                MessageBox.Show("Credit Hours cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (course>0)
            {
                MessageBox.Show("Course already Exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
        //this method iis used to check if same course exist or not
        public int courseNameChecker()
        {
            var dataset = new DataSet();
            dataset.ReadXml(CurrentPath);
            DataTable studentTable = dataset.Tables["course"];

            int course = 0;

            for (int i = 0; i < studentTable.Rows.Count; i++)
            {
                string col = studentTable.Rows[i]["CourseName"].ToString();
                if (col == courseName.Text)
                {
                    course++;
                }

            }
            return course;


        }

        private void courseName_TextChanged(object sender, TextChangedEventArgs e)
        {
            course = courseNameChecker();
        }
    }
}