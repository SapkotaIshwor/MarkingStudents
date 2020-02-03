using DataHandler;
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
using System.Data;

namespace CourseWorkSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtRegNo.Text = Read_from_file();
        }

        private void AddStudent(DataSet dataSet)
        {
            if (txtName.Text=="" || txtAddress.Text=="" || txtContact.Text=="" || comboBox.Text=="") {
                if (txtName.Text == "" && txtAddress.Text == "" && txtContact.Text == "" && comboBox.Text == "") {
                    MessageBox.Show("Please insert all data");
                }
                else if (txtName.Text == "")
                {
                    MessageBox.Show("Please insert Name");
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please insert Address");
                }
                else if (txtContact.Text == "")
                {
                    MessageBox.Show("Please insert Contact Number");
                }
                else if (comboBox.Text == "") {
                    MessageBox.Show("Please select a Course");
                }
            }

            else
            {
                var handler = new Handler();

                dataSet.Tables["StudentReport"].ReadXml("Files/StudentReport.xml");

                var dr2 = dataSet.Tables["StudentReport"].NewRow();
                dr2["RegNo"] = txtRegNo.Text;
                dr2["Name"] = txtName.Text;
                dr2["Address"] = txtAddress.Text;
                dr2["ContactNo"] = txtContact.Text;
                dr2["CourseEnroll"] = comboBox.Text;
                DateTime? selectedDate = date.SelectedDate;
                if (selectedDate.HasValue)
                {
                    string date1 = selectedDate.Value.ToString("yyyy/MM/dd");
                    dr2["RegistrationDate"] = date1;
                }
                dataSet.Tables["StudentReport"].Rows.Add(dr2);

                dataSet.Tables["StudentReport"].WriteXml("Files/StudentReport.xml");

                ClearFields();

                MessageBox.Show("Data Saved Successfully");
            }   
        }


        private void saveStuDetails_Click(object sender, RoutedEventArgs e)
        {
                var handler = new Handler();
                var dataSet = handler.CreateDataSet();
                AddStudent(dataSet);

                var regno = txtRegNo.Text;
                var name = txtName.Text;
                //dataSet.Tables["Student"].WriteXml(@"D:\" + name + "CWData" + regno + ".xml");

                Write_to_file(txtRegNo.Text);

                txtRegNo.Text = Read_from_file();
        }

        private void Write_to_file(string text)
        {
            System.IO.File.WriteAllText("Files/count.txt", text);
        }


        private string Read_from_file()
        {

            string text = System.IO.File.ReadAllText("Files/count.txt");

            int i;
            
            if (txtName.Text == "" || txtContact.Text == "" || txtContact.Text == "")
            {
                i = int.Parse(text.ToString());
                return i.ToString();
            }
            else
            {
                i = int.Parse(text.ToString());
                i = i + 1;
                return i.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }

        private void MenuStuDetails_Click(object sender, RoutedEventArgs e)
        {
            Window1 studentDetails = new Window1();
            studentDetails.Show();
        }

        private void menuReport_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
    }
}
