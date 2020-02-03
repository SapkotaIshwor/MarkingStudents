using Microsoft.Win32;
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
    /// Interaction logic for StudentEnrol.xaml
    /// </summary>
    public partial class StudentEnrol : Window
    {

        public StudentEnrol()
        {
            InitializeComponent();

            LoadGrid();

        }
        private void AddStudentData(DataSet dataSet)
        {
            var newRow = dataSet.Tables["Student"].NewRow();
            newRow["studentId"] = txtID.Text;
            newRow["studentName"] = txtName.Text;
            newRow["studentAddress"] = txtAddress.Text;
            newRow["studentContact"] = txtContact.Text;
            newRow["courseEnrol"] = cbCourse.Text;
            newRow["registrationDate"] = date.SelectedDate.Value.ToString("yyyy-MM-dd");
            dataSet.Tables["Student"].Rows.Add(newRow);

            /*Student dataStudent = new Student();
            dataStudent.studentId = txtID.Text;
            dataStudent.studentName = txtName.Text;
            dataStudent.studentAddress = txtAddress.Text;
            dataStudent.studentContact = txtContact.Text;
            dataStudent.courseEnrol = cbCourse.Text;
            dataStudent.registrationDate = date.Text;

            DataGridXAML.Items.Add(dataStudent);*/
        }

        private void btnSave_clicked(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtContact.Text == "" || cbCourse.Text == "" || date.Text == "")
            {
                MessageBox.Show("Enter a valid input field.","Message", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    var handler = new DataHandler();
                    var dataSet = new DataSet();

                    if (File.Exists(@"C:\DataHandler\StudentData.xml"))
                    {
                        dataSet.ReadXml(@"C:\DataHandler\StudentData.xml");


                    }
                    else
                    {
                        dataSet = handler.CreateDataSet();

                    }
                    AddStudentData(dataSet);
                    dataSet.WriteXml(@"C:\DataHandler\StudentData.xml");
                    LoadGrid();
                    txtID.Text = "";
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtContact.Text = "";
                    cbCourse.Text = "";
                    date.Text = "";
                    MessageBox.Show("Added Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {

                }
            }

            

        }
        public void LoadGrid()
        {
            var dataSet = new DataSet();
            if (File.Exists(@"C:\DataHandler\StudentData.xml"))
            {
                dataSet.ReadXml(@"C:\DataHandler\StudentData.xml");
                DataGridXAML.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        }

        private void btnBack_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartPage back = new StartPage();
            back.ShowDialog();
        }
    }
}
