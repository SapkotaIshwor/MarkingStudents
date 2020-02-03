using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
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

namespace AppDevCoursewrk
{
    /// <summary>
    /// Interaction logic for OpenCsv.xaml
    /// </summary>
    public partial class OpenCsv : Window
    {
        public OpenCsv()
        {
            InitializeComponent();
        }

       
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Appxml\StudentReport.xml");
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
                        var dr1 = dataSet.Tables["Student"].NewRow();
                        dr1["ID"] = values[0];
                        dr1["Name"] = values[1];
                        dr1["Address"] = values[2];
                        dr1["ContactNo"] = values[3];

                        dr1["CourseEnroll"] = values[5];
                        dr1["ProgramEnroll"] = values[6];

                        dr1["RegistrationDate"] = values[6];
                        dataSet.Tables["Student"].Rows.Add(dr1);

                        dataSet.WriteXml(@"C:\Appxml\StudentReport.xml");
                    }
                }
                dataGrid1.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
        } 
        }
    }


