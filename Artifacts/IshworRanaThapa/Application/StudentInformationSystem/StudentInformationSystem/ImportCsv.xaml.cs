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
    /// Interaction logic for ImportCsv.xaml
    /// </summary>
    public partial class ImportCsv : Window
    {
        private string fileName;

        public ImportCsv()
        {
            InitializeComponent();
        }

        private void Button_Csv(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml((@"D:\StudentData.xml"));
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "CSV Files|*.csv";
                openfile.DefaultExt = ".csv";
                openfile.FilterIndex = 1;
                openfile.Multiselect = false;
                bool? fileselect = openfile.ShowDialog();
                if (fileselect != null || fileselect == true)
                {
                    fileName = openfile.FileName;

                    using (var reader = new StreamReader(fileName))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            var dr1 = dataSet.Tables["Student"].NewRow();
                            //dr1["ID"] = values[0];
                            dr1["RegistrationNumber"] = values[1];
                            dr1["FirstName"] = values[2];
                            dr1["LastName"] = values[3];
                            dr1["Address"] = values[4];
                            dr1["ContactNo"] = values[5];
                            dr1["CourseEnroll"] = values[6];
                            dr1["RegistrationDate"] = values[7];
                            dataSet.Tables["Student"].Rows.Add(dr1);
                            dataSet.WriteXml(@"D:\StudentData.xml");
                        }
                    }
                    grdDataImport.ItemsSource = dataSet.Tables["Student"].DefaultView;
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void Btn_Back3(object sender, RoutedEventArgs e)
        {
            HomePage hm = new HomePage();
            this.Close();
            hm.Show();
        }
    }
}
