using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Data;

namespace CWAD
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Page
    {
        public Import()
        {
            InitializeComponent();
        }

        private void btnRecordDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

                if (openFileDlg.ShowDialog() == true)
                {
                    txtImport.Text = openFileDlg.FileName;
                    string filePath = openFileDlg.FileName;
                    //read all std from file code copy
                    using (var reader = new StreamReader(filePath))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["Details"].NewRow();
                            newRow["StudentRegistrationID"] = values[0];
                            newRow["StudentRegistrationDate"] = values[1];
                            newRow["StudentID"] = values[2];
                            newRow["StudentName"] = values[3];
                            newRow["StudentAddress"] = values[4];
                            newRow["StudentEmail"] = values[5];
                            newRow["StudentContact"] = values[6];
                            newRow["StudentCourse"] = values[7];
                            dataSet.Tables["Details"].Rows.Add(newRow);

                            dataSet.WriteXml(@"StudentDetails.xml");
                        }
                    }
                    MessageBox.Show("Student details are successfully imported and recorded.", "Import Sucessful!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("No xml file is created to import data into.", "Xml file not created!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
