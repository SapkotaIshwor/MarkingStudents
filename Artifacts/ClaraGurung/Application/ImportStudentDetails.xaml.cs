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
using System.Data;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Window
    {
        public StudentDetails()
        {
            InitializeComponent();
        }

        private void ImportDetails_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

                if (openFileDlg.ShowDialog() == true)
                {
                    
                    string filePath = openFileDlg.FileName;
                    //read all std from file code copy
                    using (var read = new StreamReader(filePath))
                    {
                        read.ReadLine();
                        while (!read.EndOfStream)
                        {
                            var line = read.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["Information"].NewRow();
                           
                            newRow["StudentRegistrationDate"] = values[0];
                            newRow["StudentID"] = values[1];
                            newRow["StudentName"] = values[2];
                            newRow["StudentAddress"] = values[3];
                            newRow["StudentContact"] = values[4];
                            newRow["StudentCourse"] = values[5];
                            dataSet.Tables["Information"].Rows.Add(newRow);
                           

                            dataSet.WriteXml(@"StudentDetails.xml");
                        }
                    }
                    MessageBox.Show("Successfully Imported and Recorded all Student Details.", "Import Sucessfull!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            Close();
        }
    }
}
