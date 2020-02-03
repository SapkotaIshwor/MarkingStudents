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

namespace CourseworkAppDevelopment
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        public Import()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();

                dataSet.ReadXml(@"StudentEnroll.xml");
                
                Microsoft.Win32.OpenFileDialog openFileDlialog = new Microsoft.Win32.OpenFileDialog();

                if (openFileDlialog.ShowDialog() == true) {

                    txtImportBox.Text = openFileDlialog.FileName;

                    string location = openFileDlialog.FileName;
                    
                    using (var read = new StreamReader(location)) {

                        read.ReadLine();
                        
                        while (!read.EndOfStream) {
                            
                            var line = read.ReadLine();
                            
                            var values = line.Split(',');
                            
                            var newRow = dataSet.Tables["StudentInformationClass"].NewRow();
                            
                            newRow["StudentId"] = values[0];
                            
                            newRow["StudentName"] = values[1];
                            
                            newRow["StudentAddress"] = values[2];
                            
                            newRow["StudentContactNo"] = values[3];
                            
                            newRow["StudentEmail"] = values[4];
                            
                            newRow["StudentCourseEnroll"] = values[5];
                            
                            newRow["StudentRegistrationDate"] = values[6];
                            
                            newRow["StudentRegistrationId"] = values[7];
                            
                            dataSet.Tables["StudentInformationClass"].Rows.Add(newRow);

                            dataSet.WriteXml(@"StudentEnroll.xml");

                        }
                    }

                    MessageBox.Show("Students Record Imported and Saved", "Student Information System", MessageBoxButton.OK);

                    msgImport.Visibility = Visibility.Visible;
                }
            
            }

            catch(Exception ex) {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnImportBack_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow h = new HomeWindow();

            h.Show();
            
            this.Close();
        }
    }
}
