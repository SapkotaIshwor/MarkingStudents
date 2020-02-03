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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Data;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ImportStudentDetails.xaml
    /// </summary>
    public partial class ImportStudentDetails : Window
    {
        public ImportStudentDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

                if (openFileDlg.ShowDialog() == true)
                {
                    string filePath = openFileDlg.FileName;
                    using (var scan = new StreamReader(filePath))
                    {
                        scan.ReadLine();
                        while (!scan.EndOfStream)
                        {
                            var line = scan.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["Data"].NewRow();
                            newRow["StudentRegistrationID"] = values[0];
                            newRow["StudentRegistrationDate"] = values[1];
                            newRow["StudentID"] = values[2];
                            newRow["StudentName"] = values[3];
                            newRow["StudentAddress"] = values[4];
                            newRow["StudentContact"] = values[5];
                            newRow["StudentCourse"] = values[6];
                            dataSet.Tables["Data"].Rows.Add(newRow);

                            dataSet.WriteXml(@"StudentDetails.xml");
                        }
                    }
                    MessageBox.Show("Student details successfully imported.", "Import Sucessful.", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
