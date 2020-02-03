using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Xml.Linq;

namespace Student_info
{
    
    public partial class AllStudentWindow : Window
    {
        string path = @"D:\Student_Management\StudentRegistrationData.xml";

        private string order = "";

        int i = 0;
        string sex = "";
        Boolean editMode = false;
        public AllStudentWindow()
        {
            InitializeComponent();         
            loadData();
     
        }

        private void loadData()
        {
            var handler = new Handler();

            var dataSet = handler.CreateDataSet();
         try
            {

                if (System.IO.File.Exists(path))
                {


                    dataSet.ReadXml(path);

                    gridView.ItemsSource = new DataView(dataSet.Tables["Student"]);
                    DataTable stdReportTbl = dataSet.Tables["Student"];
                }
                else
                {
                    System.Windows.MessageBox.Show("Sorry! XML file is missing", "FIle Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Sorry! Error occured","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                ReportMainWindow rpw = new ReportMainWindow();
                rpw.Show();

            }

        }
        private void maleRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Male";
        }

        private void femaleRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Female";

        }

        private void otherRdb_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Other";
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

          
        }

        private void sortData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (editMode == false)
            {

                if (sortData.SelectedIndex == 1)
                {

                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
                    gridView.Items.Refresh();

                }
                else if (sortData.SelectedIndex == 0)
                {
                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    gridView.Items.Refresh();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please turn off edit mode", "sorting", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void ascending_Checked(object sender, RoutedEventArgs e)
        {
            if (editMode == false) {
                order = "Ascending";
                if (sortData.SelectedIndex == 1)
                {

                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Ascending));
                    gridView.Items.Refresh();

                }
                else if (sortData.SelectedIndex == 0)
                {
                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    gridView.Items.Refresh();
                }
            }
            else 
            {
                System.Windows.MessageBox.Show("Please turn off edit mode", "sorting", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void descending_Checked(object sender, RoutedEventArgs e)
        {
            if (editMode == false)
            {
                order = "Descending";
                if (sortData.SelectedIndex == 1)
                {

                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("RegistrationDate", ListSortDirection.Descending));
                    gridView.Items.Refresh();

                }
                else if (sortData.SelectedIndex == 0)
                {
                    gridView.Items.SortDescriptions.Clear();
                    gridView.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
                    gridView.Items.Refresh();
                }
            }

            else
            {
                System.Windows.MessageBox.Show("Please turn off edit mode", "sorting", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }


        private void onBtn_Checked(object sender, RoutedEventArgs e)
        {
            editMode = true;
            XDocument doc = XDocument.Load(path);
            var resource = doc.Descendants("Student").Select(x => new
            {
                name = x.Element("Name").Value,
                id = x.Element("StudentID").Value,
                department = x.Element("Department").Value,
                faculty = x.Element("Faculty").Value,
                program = x.Element("Program").Value,
                phone = x.Element("Phone").Value,
                email = x.Element("Email").Value,
                gender = x.Element("Gender").Value,
                current_address = x.Element("CurrentAddress").Value,
                permanent_address = x.Element("PermanentAddress").Value,
                religion = x.Element("Religion").Value,
                nationality = x.Element("Nationality").Value,
                marrital_status = x.Element("MaritalStatus").Value,
                //registration_date = x.Element("RegistrationDate").Value

            });
            gridView.ItemsSource = resource;
            gridView.Items.Refresh();
            XElement lastStudent = doc.Descendants("Student").Last();
            //string lastStudentID = lastStudent.Element("ID").Value();

        }

        private void offBtn_Checked(object sender, RoutedEventArgs e)
        {
            loadData();
            editMode = false;
        }

        private void back_btn(object sender, RoutedEventArgs e)
            {
                this.Close();
                ReportMainWindow rpw = new ReportMainWindow();
                rpw.Show();
            }
        
    }
}
