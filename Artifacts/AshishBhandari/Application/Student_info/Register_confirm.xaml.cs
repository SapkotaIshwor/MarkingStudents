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

namespace Student_info
{
    
    public partial class Register_confirm : Window
    {
     
        public Register_confirm( string Fname, string Lname, int Id, string Department, string Faculty, string Program, int Phone, string Email, string Gender, string currentAddr, string permanentAddr, string Religion, string Nationality, string MarritalStatus)
        {
            InitializeComponent();
            name_lbl.Content = $"{Fname} {Lname}";
            id_lbl.Content = Id;
            department_lbl.Content = Department;
            faculty_lbl.Content = Faculty;
            program_lbl.Content = Program;
            phone_lbl.Content = Phone;
            emil_lbl.Content = Email;
            gender_lbl.Content = Gender;
            current_addr_lbl.Content = currentAddr;
            per_address_lbl.Content = permanentAddr; 
            religion_lbl.Content = Religion;
            nationality_lbl.Content = Nationality;
            marrital_lbl.Content = MarritalStatus;


        }

    
        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure wanna cancel ?", "Cancel Confirmation", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Hide();
                Register_student register_Student = new Register_student();
                register_Student.Close();

                RegisterMainWindow RmWindow = new RegisterMainWindow();
                RmWindow.Show();
            }
            else
            {
                //
            }

          
        }

        private void register_btn(object sender, RoutedEventArgs e)
        {
            Startup();
            this.Close();
            Register_student register_Student = new Register_student();
            register_Student.Close();

        }

        public void Startup()
        {
            string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory;

            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            //dataSet.ReadXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");

            dataSet = new DataSet();
            string DataFilepath = @"D:\Student_Management\StudentRegistrationData.xml";
            if (File.Exists(DataFilepath))
            {

                dataSet.ReadXml(@"D:\Student_Management\StudentRegistrationData.xml");
                AddData(dataSet);
                dataSet.WriteXml(@"D:\Student_Management\StudentRegistrationData.xml");

                MessageBox.Show("Successfully Registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();

                Register_student register_Student = new Register_student();
                register_Student.Close();
                RegisterMainWindow rmWindow = new RegisterMainWindow();
                rmWindow.Show();

            }
            else
            {
                //dataSet.ReadXmlSchema(@CurrentPath + "\\StudentCWSchema.xml");
                 handler = new Handler();
                 dataSet = handler.CreateDataSet();
                AddData(dataSet);
                dataSet.WriteXmlSchema(@"D:\Student_Management\StudentRegistrationSchema.xml");
                dataSet.WriteXml(@"D:\Student_Management\StudentRegistrationData.xml");

                MessageBox.Show("Successfully Registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();

                Register_student register_Student = new Register_student();
                register_Student.Close();

                RegisterMainWindow rmWindow = new RegisterMainWindow();
                rmWindow.Show();

            }
            



        }

        private void AddData(DataSet dataSet)
        {
                      
            var dr = dataSet.Tables["Student"].NewRow();
            dr["Name"] = name_lbl.Content;
            dr["StudentID"] = id_lbl.Content;
            dr["Department"] = department_lbl.Content;
            dr["Faculty"] = faculty_lbl.Content;
            dr["Program"] = program_lbl.Content;
            dr["Phone"] = phone_lbl.Content;
            dr["Email"] = emil_lbl.Content;
            dr["Gender"] = gender_lbl.Content;
            dr["CurrentAddress"] = current_addr_lbl.Content;
            dr["PermanentAddress"] = per_address_lbl.Content;
            dr["Religion"] = religion_lbl.Content;
            dr["Nationality"] = nationality_lbl.Content;
            dr["MaritalStatus"] = marrital_lbl.Content;
            dr["RegistrationDate"] = DateTime.Today;
            
            dataSet.Tables["Student"].Rows.Add(dr);

        }
       
    }
}
