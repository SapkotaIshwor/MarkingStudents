using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Login2
{
    /// <summary>
    /// Interaction logic for Import_CSV.xaml
    /// </summary>
    public partial class Import_CSV : Page
    {
        private List<Student> _studentList = new List<Student>();
        public Import_CSV()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "CSV files|*.csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var csvData = System.IO.File.ReadAllText(dlg.FileName);
                ReadFromCSV(csvData);

            }
        }

        public List<Student> ReadFromCSV(string csvData)
        {
            List<Student> studentList = new List<Student>();
            try
            {
                //1st row contains property name so skipping the first row.
                var lines = csvData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                foreach (var item in lines)
                {
                    var values = item.Split(',');
                    Student student = new Student();
                    student.ID = Convert.ToString(values[0]);
                    student.FirstName = Convert.ToString(values[1]);
                    student.LastName = Convert.ToString(values[2]);
                    student.Address = Convert.ToString(values[3]);
                    student.ContactNo = Convert.ToString(values[4]);
                    student.CourseName = Convert.ToString(values[5]);
                    student.RegisterDate = Convert.ToString(values[6]);
                    studentList.Add(student);
                }
                _studentList = studentList;
                this.dgSecond.ItemsSource = _studentList;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                using (FileStream fileStream = new FileStream("studentDetails.xml", FileMode.Append, FileAccess.Write))
                {
                    serializer.Serialize(fileStream, _studentList);
                    MessageBox.Show("Successfully Imported and Saved to XML", "Success");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
            return studentList;

        }
    }
}
