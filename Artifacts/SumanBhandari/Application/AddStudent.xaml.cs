using DataHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace StudentRegistration
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private List<string> courseList = new List<string>();
        private List<string> zones = new List<string>();
        private List<string> District = new List<string>();
        private string studentId,selectedId;
        private int _Id;
        private string _gender;
        private bool _isValidEmail;
        private bool _isContactNumber;
        private bool _isGuardianContactNumber;
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentCWData.xml";
        
        public AddStudent()
        {
            InitializeComponent();
            studentId= GenerateStudentId();
            tv_stdId.Text = studentId;
           
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            DataTable studentTable = dataSet.Tables["student"];
            _Id = studentTable.Select("stdId = '"+tv_stdId.Text+"'").Count<DataRow>();
            stdId.Content = studentId;
            if (File.Exists(CurrentPath))
            {
                dataSet.ReadXml(CurrentPath);
            }
            else
            {
                dataSet.WriteXml(CurrentPath);
            }
            DataGridTest.ItemsSource = new DataView(dataSet.Tables["Student"]);
            DataTable courseTable = dataSet.Tables["Course"];
            foreach (DataRow row in courseTable.Rows)
            {
                var courseName = row["CourseName"].ToString();
                courseList.Add(courseName);
            }
            course.ItemsSource = courseList;

            zones.Add("gandaki");
            zones.Add("bagmati");
            zones.Add("bheri");
            zones.Add("dhawalagiri");
            zones.Add("gandaki");
            zones.Add("janakpur");
            zones.Add("karnali");
            zones.Add("koshi");
            zones.Add("lumbini");
            zones.Add("mahakali");
            zones.Add("mechi");
            zones.Add("narayani");
            zones.Add("rapti");
            zones.Add("sagarmatha");
            zones.Add("seti");
            cb_zone.ItemsSource = zones;

            District.Add("achham");
            District.Add("arghakhanchi");
            District.Add("baglung");
            District.Add("baitadi");
            District.Add("bajhang");
            District.Add("bajura");
            District.Add("banke");
            District.Add("bara");
            District.Add("bardiya");
            District.Add("bhaktapur");
            District.Add("bhojpur");
            District.Add("chitwan");
            District.Add("dadeldhura");
            District.Add("dailekh");
            District.Add("dang deukhuri");
            District.Add("darchula");
            District.Add("dhading");
            District.Add("dhankuta");
            District.Add("dhanusa");
            District.Add("dholkha");
            District.Add("dolpa");
            District.Add("doti");
            District.Add("gorkha");
            District.Add("gulmi");
            District.Add("humla");
            District.Add("ilam");
            District.Add("jajarkot");
            District.Add("jhapa");
            District.Add("jumla");
            District.Add("kailali");
            District.Add("kalikot");
            District.Add("kanchanpur");
            District.Add("kapilvastu");
            District.Add("kaski");
            District.Add("kathmandu");
            District.Add("kavrepalanchok");
            District.Add("khotang");
            District.Add("lalitpur");
            District.Add("lamjung");
            District.Add("mahottari");
            District.Add("makwanpur");
            District.Add("manang");
            District.Add("morang");
            District.Add("mugu");
            District.Add("mustang");
            District.Add("myagdi");
            District.Add("nawalparasi");
            District.Add("nuwakot");
            District.Add("okhaldhunga");
            District.Add("palpa");
            District.Add("panchthar");
            District.Add("parbat");
            District.Add("parsa");
            District.Add("pyuthan");
            District.Add("ramechhap");
            District.Add("rasuwa");
            District.Add("rautahat");
            District.Add("rolpa");
            District.Add("rukum");
            District.Add("rupandehi");
            District.Add("salyan");
            District.Add("sankhuwasabha");
            District.Add("saptari");
            District.Add("sarlahi");
            District.Add("sindhuli");
            District.Add("sindhupalchok");
            District.Add("siraha");
            District.Add("solukhumbu");
            District.Add("sunsari");
            District.Add("surkhet");
            District.Add("syangja");
            District.Add("tanahu");
            District.Add("taplejung");
            District.Add("terhathum");
            District.Add("udayapur");
            cb_district.ItemsSource = District;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            studentId = GenerateStudentId();

            if (Validation())
            {
                SaveStudent(dataSet);
                if (File.Exists(CurrentPath))
                {
                    dataSet.ReadXml(CurrentPath);
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Enroled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                    tv_stdId.Text = studentId;

                }
                else
                {
                    dataSet.WriteXml(CurrentPath);
                    MessageBox.Show("Enroled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                }

            }
            else
            {
                dataSet.ReadXml(CurrentPath);
            }
        }
        //this method saves student data to xml 
        private void SaveStudent(DataSet dataSet)
        {
            var dr = dataSet.Tables["Student"].NewRow();
            dr["stdId"] = tv_stdId.Text;
            dr["firstName"] = tv_firstName.Text;
            dr["lastName"] = tv_lastName.Text;
            dr["gender"] = _gender;
            dr["ContactNo"] = tv_contactNo.Text;
            dr["email"] = tv_email.Text;
            dr["CourseEnroll"] = course.Text;
            dr["zone"] = cb_zone.Text;
            dr["District"] = cb_district.Text;
            dr["Tole"] = tv_tole.Text;
            dr["guardianNo"] = tv_guardianNo.Text;
            dr["RegistrationDate"] = DateTime.Now;
            dataSet.Tables["Student"].Rows.Add(dr);
            DataGridTest.ItemsSource = new DataView(dataSet.Tables["Student"]);
        }
        //this method is used to clear fields
        public void clearText()
        {
            tv_firstName.Text = "";
            tv_lastName.Text = "";
            tv_email.Text = "";
            tv_contactNo.Text = "";
            tv_email.Clear();
            tv_tole.Clear();
            tv_guardianNo.Clear();
            tv_contactNo.Clear();
            cb_district.SelectedIndex=-1;
            cb_zone.SelectedIndex = -1;
            course.SelectedIndex = -1;
        }

        //this method is used to validate user input before saving data
        public Boolean Validation()
        {
            if (tv_firstName.Text.Equals(""))
            {
                MessageBox.Show("First Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (tv_lastName.Text.Equals(""))
            {
                MessageBox.Show("Last Name cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (cb_district.Text.Equals(""))
            {
                MessageBox.Show("District cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (cb_zone.Text.Equals(""))
            {
                MessageBox.Show("Zone cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (tv_contactNo.Text.Equals(""))
            {
                MessageBox.Show("Contact Number cannot be Empty"+_isContactNumber, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!_isContactNumber)
            {
                MessageBox.Show("please input valid Contact Number", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!_isGuardianContactNumber)
            {
                MessageBox.Show("Please input valid Guardian Nuumber", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (tv_email.Text.Equals(""))
            {

                MessageBox.Show("Email cannot be Empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!_isValidEmail)
            {
                MessageBox.Show("Email not valid", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (_Id>0)
            {
                MessageBox.Show("Student Id already Exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
           
            return true;
        }
        
        //clear the field on clicking clear button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearText();
          
       }
        //close the window on clicking exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //delete  selscted students data on clicking delete button
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {           
            if (!selectedId.Equals(""))
            {
                XDocument doc = XDocument.Load(CurrentPath);
                var removeStudent = doc.Descendants("Student").Where(c => c.Element("stdId").Value == selectedId).FirstOrDefault();
                removeStudent.Remove();
                doc.Save(CurrentPath);
                var result=MessageBox.Show("Deleted sucessfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

                if ( result==MessageBoxResult.OK)
                {
                    var dataHandler = new datahandler();
                    var dataSet = dataHandler.CreateDataSet();
                    dataSet.ReadXml(CurrentPath);
                    DataGridTest.ItemsSource = new DataView(dataSet.Tables["Student"]);
                }                           
            }
            else
            {
                MessageBox.Show("Please select data before deleting", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        //this method is used ti generate unique student id
        public string GenerateStudentId()
        {
            var bytes = new byte[4];
            var randomNo = RandomNumberGenerator.Create();
            randomNo.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        private void tv_stdId_TextChanged(object sender, TextChangedEventArgs e)
        {         
            var dataHandler = new datahandler();
            var dataSet = dataHandler.CreateDataSet();
            DataTable studentTable = dataSet.Tables["student"];
            _Id = studentIdChecker();
            if (_Id > 0)
            {
                stdId.Content = "Student Id Already Exit please change student Id";
            }
            else
            {
                stdId.Content = tv_stdId.Text;
            }
           
        }
        //this method is used to check if student with the same id exist or not
        public int studentIdChecker()
        {
            var dataset = new DataSet();
            dataset.ReadXml(CurrentPath);
            DataTable studentTable = dataset.Tables["student"];
            int stdId = 0;
            for (int i = 0; i < studentTable.Rows.Count; i++)
            {
                string col = studentTable.Rows[i]["stdId"].ToString();
                if (col == tv_stdId.Text)
                {
                    stdId++;
                }
            }
            return stdId;
        }

        private void tv_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isValidEmail = IsValidEmail(tv_email.Text);

        }
        //the method validates the email input
        private  bool IsValidEmail(string emailAddress)
        {
            const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase).IsMatch(emailAddress);
        }
        //this method is used to validate input is number or not
        private bool isInputNumber(string number)
        {
            const string validNumberPattern = "^[0-9]+$";

            return new Regex(validNumberPattern).IsMatch(number);
        }

        private void tv_contactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isContactNumber = isInputNumber(tv_contactNo.Text);

        }

        private void DataGridTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid datagid = sender as DataGrid;
            if ((DataGridRow)DataGridTest.ItemContainerGenerator.ContainerFromIndex(datagid.SelectedIndex) != null)
            {
                DataGridRow row = (DataGridRow)DataGridTest.ItemContainerGenerator.ContainerFromIndex(datagid.SelectedIndex);
                DataGridCell rowColumn = datagid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                selectedId = ((TextBlock)rowColumn.Content).Text;
               
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gender = "Male";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            _gender = "Female";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            _gender = "Other";
        }

        private void tv_guardianNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isGuardianContactNumber = isInputNumber(tv_guardianNo.Text);

        }
    }
}



