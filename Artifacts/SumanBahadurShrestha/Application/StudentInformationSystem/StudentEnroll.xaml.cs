using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for StudentEnroll.xaml
    /// </summary>
    public partial class StudentEnroll : Window
    {
        private string fileName;
        public StudentEnroll()
        {
            InitializeComponent();
            dataretrieve();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            Checkedempty();
            var handler = new DataHandler();
            var dataSet = new DataSet();
            //AddCSVStudent(dataSet);
            if (File.Exists(@"E:\StudentCWData.xml") && File.Exists(@"E:\StudentCWSchema.schema"))
            {
                dataSet.ReadXml(@"E:\StudentCWData.xml");
               // dataSet.WriteXml(@"E:\StudentCWData.xml");
                dataSet.ReadXmlSchema(@"E:\StudentCWSchema.schema");
                //dataSet.WriteXmlSchema(@"E:\StudentCWSchema.schema");

                MessageBox.Show("student Enroled Sucessfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                //clearall();
            }
            else
            {
                dataSet = handler.CreateDataSet();
                
                // clearall();
            }
            AddStudent(dataSet);
            dataSet.WriteXmlSchema(@"E:\StudentCwSchema.schema");
            dataSet.WriteXml(@"E:\StudentCWData.xml");
            MessageBox.Show("New file Sucessfully generated", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            Loaddata();
            clearall();

        }

        private void Checkedempty()
        {
            var id = autoid.Text;
            var name = editfullname.Text;
            var address = editaddress.Text;
            var phone = editphone.Text;
            var gender = combogender.Text;
            var course = combocourse.Text;
            var date = datepick.Text;
            if (id.Equals("") || name.Equals("") || address.Equals("") || phone.Equals("") || gender.Equals("") || course.Equals("") || date.Equals(""))
            {
                MessageBox.Show("You can't pass empty value", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        private void AddStudent(DataSet dataSet)
        {
            var dr1 = dataSet.Tables["Student"].NewRow();
            dr1["id"] = autoid.Text;
            dr1["name"] = editfullname.Text;
            dr1["address"] = editaddress.Text;
            dr1["number"] = editphone.Text;
            dr1["gender"] = combogender.Text;
            dr1["courseenroll"] = combocourse.Text;
            dr1["date"] = datepick.SelectedDate != null ? datepick.SelectedDate.Value : DateTime.Today;
            dataSet.Tables["Student"].Rows.Add(dr1);
        }
       
        private void clearall()
        {
            autoid.Text = "";
            editfullname.Text = "";
            editaddress.Text = "";
            editphone.Text = "";
            combogender.Text = "";
            combocourse.Text = "";
            datepick.Text = "";
        }
        private void Loaddata()
        {
            var dataSet = new DataSet();
            //var dataSet = datahandler.CreateDataSet();
            if (File.Exists(@"E:\StudentCWData.xml"))
            {
                dataSet.ReadXml(@"E:\StudentCWData.xml");
                datagrid.ItemsSource = dataSet.Tables["Student"].DefaultView;
            }
            
        }
        private void dataretrieve()
        {
            var dataSet = new DataSet();
            //var dataSet = datahandler.CreateDataSet();
            if (File.Exists(@"E:\StudentCWData.xml"))
            {
                dataSet.ReadXml(@"E:\StudentCWData.xml");
                datagrid.ItemsSource = dataSet.Tables["Student"].DefaultView;
                MessageBox.Show("Student detail retrieved");
            }

        }

        private void datasort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortdata = datasort.SelectedIndex;
            if (sortdata == 1)
            {
                datagrid.Items.SortDescriptions.Clear();
                datagrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("date", System.ComponentModel.ListSortDirection.Descending));
                datagrid.Items.Refresh();
            }
            else
            {
                datagrid.Items.SortDescriptions.Clear();
                datagrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("name", System.ComponentModel.ListSortDirection.Ascending));
                datagrid.Items.Refresh();
            }
        }

        private void btnimport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml((@"E:\StudentCWData.xml"));
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
                            dr1["id"] = values[0];
                            dr1["name"] = values[1];
                            dr1["address"] = values[2];
                            dr1["number"] = values[3];
                            dr1["gender"] = values[4];
                            dr1["courseenroll"] = values[5];
                            dr1["date"] = values[6];
                            dataSet.Tables["Student"].Rows.Add(dr1);

                          

                            dataSet.WriteXml(@"E:\StudentCWData.xml");
                        }
                    }
                    datagrid.ItemsSource = dataSet.Tables["Student"].DefaultView;
                }
            }
            catch (Exception)
            {

            }
        }
       
    }
}
