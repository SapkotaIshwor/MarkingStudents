using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
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
using DataHandler;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Globalization;

namespace CourseWorkAD
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        DataTable dataTable;
        public StudentForm()
        {
            InitializeComponent();
        }

        public Window1 Window1
        {
            get => default;
            set
            {
            }
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string phoneNumber { get; set; }
            public string Courseenroll { get; set; }
            public string RegDate { get; set; }
        }

        private void buttonclick(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = new DataSet();

            if (File.Exists(@"D:\student.xml"))
            {
                dataSet.ReadXml(@"D:\student.xml");
            }
            else
            {

                dataSet = handler.CreateDataSet();


            }
            AddSampleData(dataSet);
            dataSet.WriteXml(@"D:\student.xml");
            LoadGrid();
        }

        void LoadGrid()
        {
            if (File.Exists(@"D:\student.xml"))
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(@"D:\student.xml");
                dataTable = dataSet.Tables["Student"];
                datagrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void AddSampleData(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["ID"] = studentid.Text;
            dr1["Name"] = studentname.Text;
            dr1["Address"] = studentaddress.Text;
            dr1["ContactNo"] = studentphone.Text;
            dr1["CourseEnroll"] = studentcourse.Text;
            dr1["RegistrationDate"] = studentdate.Text;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }



        private void sortname_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"D:\student.xml"))
            {
                dataTable.DefaultView.Sort = "Name ASC";
                // dataSet.ReadXml(@"D:\student.xml");
                datagrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void sortregd_Click(object sender, RoutedEventArgs e)
        {

               if (File.Exists(@"D:\student.xml"))
            {
                var dataSet = new DataSet();
                dataTable.DefaultView.Sort = "Name ASC";
                dataSet.ReadXml(@"D:\student.xml");
                datagrid.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
            
        }

        private void btnweeklyreport_Click(object sender, RoutedEventArgs e)
        {
            int sum_computing = 1;
            int sum_mediatechnology = 2;
            int sum_networksanditsecurity = 2;
            

            DataTable dtable = new DataTable("tbl");
            dtable.Columns.Add("Course Enroll", typeof(String));
            dtable.Columns.Add("Sum Students", typeof(int));

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                String lol = dtable.Rows[i]["CourseEnroll"].ToString();
                if (lol == "Computing")
                {
                    sum_computing++;
                }
                else if (lol == "Multimedia Technology")
                {
                    sum_mediatechnology++;
                }
                else if (lol == "Networks and IT Security")
                {
                    sum_networksanditsecurity++;
                }
                
            }

            dtable.Rows.Add("Computing", sum_computing);
            dtable.Rows.Add("Multimedia Technology", sum_mediatechnology);
            dtable.Rows.Add("Networks and IT Security", sum_networksanditsecurity);
           

            datagrid.ItemsSource = dtable.DefaultView;
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = System.IO.Path.GetDirectoryName(path);
            string fileName = System.IO.Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {


            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".CSV";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DataTable tableStd = GetDataTableFromCsv(dlg.FileName, true);
                datagrid.DataContext = tableStd.DefaultView;
            }



            //var dataSet = new DataSet();
            //dataSet.ReadXml(@"D:\student.xml");
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    string filePath = openFileDialog.FileName;
            //    //read all std from file code copy  

            //    using (var reader = new StreamReader(filePath))
            //    {
            //        reader.ReadLine();
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            var values = line.Split(',');
            //            var newRow = dataSet.Tables["Student"].NewRow();
            //            newRow["ID"] = values[0];
            //            newRow["Name"] = values[1];
            //            newRow["Address"] = values[2];
            //            newRow["ContactNo"] = values[3];
            //            newRow["CourseEnrol"] = values[4];
            //            newRow["RegistrationDate"] = values[5];
            //            dataSet.Tables["Student"].Rows.Add(newRow);

            //            dataSet.WriteXml(@"D:\student.xml");
            //        }
            //     }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();

    
        }
    }
    }


       



        
    

       
    


