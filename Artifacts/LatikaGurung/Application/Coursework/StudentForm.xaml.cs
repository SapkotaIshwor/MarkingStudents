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
using DataHandler;
using Microsoft.Win32;

namespace Coursework
{

    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        DataTable dataTable;
        
        public StudentForm()
        {
            InitializeComponent();
            viewGrid();
        }
        public void viewGrid()
        {
            if (File.Exists(@"D:\student.xml"))
            {


                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\student.xml");
                dataTable = dataSet.Tables["Student"];
                DataGridXAML.ItemsSource = dataTable.DefaultView;

            }
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = new DataSet();

            if (File.Exists(@"D:\student.xml"))
            {
                dataSet.ReadXml(@"D:\student.xml");

            }
            else
            {
                dataSet = handler.CreateDataSet();
            }
            AddStudentData(dataSet);
            dataSet.WriteXml(@"D:\student.xml");
            viewGrid();
        }
        private void AddStudentData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["ID"] = txtId.Text;
            dr1["Name"] = txtname.Text;
            dr1["Address"] = txtAddress.Text;
            dr1["Contact"] = txtContact.Text;
            dr1["CourseEnroll"] = txtCrsEnrl.Text;
            dr1["RegDate"] = txtRegidate.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }



        private void btn_sorting_Click(object sender, RoutedEventArgs e)
        {
            dataTable.DefaultView.Sort = "Name ASC";
            DataGridXAML.DataContext = dataTable.DefaultView;



        }

        private void btn_datesorting_Click(object sender, RoutedEventArgs e)
        {
            dataTable.DefaultView.Sort = "RegDate ASC";
            DataGridXAML.DataContext = dataTable.DefaultView; 
        }

        private void btn_chart_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Weeklyreport weeklyReport = new Weeklyreport();
            weeklyReport.ShowDialog();
        }
            

        private void DataGridXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"D:\student.xml");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                //read all std from file code copy  

                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        var newRow = dataSet.Tables["Student"].NewRow();
                        newRow["ID"] = values[0];
                        newRow["Name"] = values[1];
                        newRow["Address"] = values[2];
                        newRow["Contact"] = values[3];
                        newRow["CourseEnroll"] = values[4];
                        newRow["RegDate"] = values[5];
                        dataSet.Tables["Student"].Rows.Add(newRow);

                        dataSet.WriteXml(@"D:\student.xml");
                    }



                }
            }
        }
    }
}


            

            
