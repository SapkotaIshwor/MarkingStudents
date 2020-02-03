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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Student_Infromation_System
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog importData = new Microsoft.Win32.OpenFileDialog();
                importData.Title = "Import Students";
                importData.Filter = "CSV File|*.csv";

                if (importData.ShowDialog() == true)
                {
                    string path = importData.FileName;
                    string[] data = System.IO.File.ReadAllLines(path);
                    List<StudentDetails> students = new List<StudentDetails>();

                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] details = data[i].Split(',');
                        students.Add(new StudentDetails(details[0], details[1], details[2], details[3], details[4], details[5]));
                        String csv = details[0] + "," + details[1] + "," + details[2] + "," + details[3] + "," + details[4] + "," + details[5] + "\r\n";
                        File.AppendAllText("students.csv", csv);
                    }

                    DataGridXaml.ItemsSource = students;
                    this.DataGridXaml.ItemsSource = students;
                    System.Windows.MessageBox.Show("Successfully Imported and Saved to CSV", "Success");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home back = new Home();
            back.ShowDialog();
        }
    }
}
    
    
