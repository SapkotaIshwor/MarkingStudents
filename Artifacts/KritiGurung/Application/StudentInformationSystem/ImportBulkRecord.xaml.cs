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
using System.Xml.Linq;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ImportBulkRecord.xaml
    /// </summary>
    public partial class ImportBulkRecord : Window
    {
        StudentRegistrationDetails details = new StudentRegistrationDetails();
        public ImportBulkRecord()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePage form2 = new HomePage();
            form2.ShowDialog();
        }

        private void btn_save_csv_file_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"StudentDetails.xml");
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();


                if (openFileDlg.ShowDialog() == true)
                {
                    txt_path_view.Text = openFileDlg.FileName;
                    string filePath = openFileDlg.FileName;
                    //read all std from file code copy
                    using (var reader = new StreamReader(filePath))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            var newRow = dataSet.Tables["RegistrationDetails"].NewRow();
                            newRow["registrationID"] = values[0];
                            newRow["registrationDate"] = values[1];
                            newRow["studentID"] = values[2];
                            newRow["name"] = values[3];
                            newRow["address"] = values[4];
                            newRow["email"] = values[5];
                            newRow["contact"] = values[6];
                            newRow["course"] = values[7];
                            dataSet.Tables["RegistrationDetails"].Rows.Add(newRow);

                            dataSet.WriteXml(@"StudentDetails.xml");

                        }
                        System.Windows.MessageBox.Show("It is sucessfully imported to xml file.", "Import Sucessful!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }

                }
            }
            catch
            {
                System.Windows.MessageBox.Show("No xml created for updating data.", "Import UnSucessful", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
        }
            
        }   
    
}
