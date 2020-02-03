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
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.DefaultExt = ".csv";

            bool? fileselect = openFileDialog.ShowDialog();
            if (fileselect == true)
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
                        var newRow = dataSet.Tables["StudentReport"].NewRow();
                        newRow["ID"] = values[0];
                        newRow["RegNo"] = values[1];
                        newRow["Name"] = values[2];
                        newRow["Address"] = values[3];
                        newRow["ContactNo"] = values[4];
                        newRow["ProgramEnroll"] = values[5];
                        newRow["RegistrationDate"] = values[6];
                        dataSet.Tables["StudentReport"].Rows.Add(newRow);

                    }

                    dataSet.WriteXml(@"C:\Appxml\StudentReport.xml");
                    dataGrid1.ItemsSource = dataSet.Tables["StudentReport"].DefaultView;


                }
            }
        }
    }
}

