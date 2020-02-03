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
using System.Xml.Serialization;

namespace Student_Infromation_System
{
    /// <summary>
    /// Interaction logic for EnrollStudent.xaml
    /// </summary>
    public partial class StudentEnroll : Window
    {
        readonly List<DataGridItems> items = new List<DataGridItems>();

        public StudentEnroll()
        {
            InitializeComponent();

        }

        private void save_studentsDetails(object sender, RoutedEventArgs e)
        {
            try
            {
                String id = txt_id.Text.ToString();
                String name = txt_name.Text.ToString();
                String course = courseEnroll.Text.ToString();
                String address = txt_address.Text.ToString();
                String phone = txt_num.Text.ToString();
                String regDate = reg_date.Text.ToString();

                String data = id + "," + name + "," + address + "," + course + "," + phone + "," + regDate + "\r\n";
                File.AppendAllText("students.csv", data);

                items.Add(new DataGridItems() { StudentID = id, StudentName = name, StudentAddress = address, StudentContact = phone, Course = course, RegistrationDate = regDate });
                display.ItemsSource = items;
                display.Items.Refresh();

                MessageBox.Show("Student enrolled successfully.", "Success");

                txt_id.Text = String.Empty;
                txt_name.Text = String.Empty;
                courseEnroll.Text = String.Empty;
                txt_address.Text = String.Empty;
                txt_num.Text = String.Empty;
                reg_date.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public class DataGridItems
        {
            public string StudentID { get; set; }
            public string StudentName { get; set; }
            public string StudentAddress { get; set; }
            public string Course { get; set; }
            public string StudentContact { get; set; }
            public string RegistrationDate { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home form2 = new Home();
            form2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home back = new Home();
            back.ShowDialog();
        }
    }
}


