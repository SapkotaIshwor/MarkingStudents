using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Student_Management_System.Views
{
    /// <summary>
    /// Interaction logic for EnrollView.xaml
    /// </summary>
    public partial class EnrollView : UserControl
    {
        XmlSerializer xs;
        List<StudentInfo> ls;
        string Gender;
        public EnrollView()
        {
            InitializeComponent();
            ls = new List<StudentInfo>();
            xs = new XmlSerializer(typeof(List<StudentInfo>));
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ResetBtnClicked(object sender, RoutedEventArgs e)
        {
            StdIDTextbox.Clear();
            NameTextbox.Clear();
            AddressTextbox.Clear();
            ContactTextbox.Clear();
            EmailTextbox.Clear();
            PgComboBox.Items.Clear();
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("D:\\StudentDetails.Xml", FileMode.Create, FileAccess.Write);
            StudentInfo stdobj = new StudentInfo();

         
          
            if(RegDate.ToString() == "" || StdIDTextbox.Text=="" || NameTextbox.Text =="" || PgComboBox.Text =="" || AddressTextbox.Text =="")
            {
                MessageBox.Show("Please fill up all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                stdobj.ID = StdIDTextbox.Text;
                stdobj.Student_Name = NameTextbox.Text;
                stdobj.Address = AddressTextbox.Text;
                stdobj.Contact = ContactTextbox.Text;
                stdobj.Gender = Gender;
                stdobj.Email = EmailTextbox.Text;
                stdobj.Programme = PgComboBox.Text;
                stdobj.Registration_Date = RegDate.SelectedDate.Value.Date.ToShortDateString();
                

                try
                {
                    // Saving all student details in .csv format. New entries will be added to old entries as well.
                    if (File.Exists("studentDetails.csv"))
                    {
                        stdobj.Registration_Date = RegDate.SelectedDate.Value.Date.ToShortDateString();
                        ls.Add(stdobj);                                   
                        MessageBox.Show("Successfully Enrolled and Saved to CSV", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        ExportToCSV(ls, "studentDetails.csv");
                      

                    }
                    else
                    {
                        stdobj.Registration_Date = RegDate.SelectedDate.Value.Date.ToShortDateString();
                        ls.Add(stdobj);                      
                        MessageBox.Show("Successfully Enrolled and Saved to CSV and XML File.", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        ExportToCSV(ls, "studentDetails.csv");

                    }
                    // Using Serialization for creating XML file which will hold data unless and unitll new data entries are enrolled
                    xs.Serialize(fs, ls);
                    fs.Close();
                    StdIDTextbox.Clear();
                    NameTextbox.Clear();
                    AddressTextbox.Clear();
                    ContactTextbox.Clear();
                    EmailTextbox.Clear();
                    PgComboBox.SelectedItem = "";


                }
                catch
                {
                    MessageBox.Show("Error Occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

            
        }

        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }

        private void ContactTextInput_keypress(object sender, TextCompositionEventArgs e)
        {
            ValidateInteger(e);   
        }

        public void ValidateInteger(TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
        }

      

        

        private void RadioMale_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void RadioFemale_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void RadioOthers_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Others";
        }

        public void ExportToCSV(List<StudentInfo> students, string filePath)
        {
            try
            {
                if (students.Count > 0)
                {
                    var propList = students[0].GetType().GetProperties().Select(prop => prop.Name).ToList();
                    //TextWriter is used to create output and streamWriter is used to read file location

                    using (TextWriter TW = new StreamWriter(filePath, append: true))
                    {
                      
                        foreach (var val in students)
                        {
                            foreach (PropertyInfo prop in val.GetType().GetProperties())
                            {
                                TW.Write(prop.GetValue(val, null).ToString() + ",");
                            }
                            TW.WriteLine();

                        }
                    }
                    
                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
                
            }

        }

        private void EmailPreview_validate(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (IsEmailAllowed(EmailTextbox.Text.Trim()) == false)
            {
                e.Handled = true;
                MessageBox.Show("E-Mail expected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailTextbox.Focus();
            }
        }

        private static bool IsEmailAllowed(string text)
        {
            bool blnValidEmail = false;
            Regex regEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (text.Length > 0)
            {
                blnValidEmail = regEMail.IsMatch(text);
            }

            return blnValidEmail;
        }
    }

 
}
