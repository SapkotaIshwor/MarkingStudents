using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace Application_Development_CW1
{
    /// <summary>
    /// Interaction logic for retrieve_record.xaml
    /// </summary>
    public partial class retrieve_record : Window
    {
        public retrieve_record()
        {
            InitializeComponent();
        }
        

        private void button_retrecord_Click(object sender, RoutedEventArgs e)
        {
            readRecord();
        }
        private void readRecord()
        {
            string delimiter = ",";
            string tableName = "Student Record";
            String FileName = "C:\\Users\\Prashanta Timsina\\Desktop\\StudentRecord.csv";

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(FileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("ID");
            dataset.Tables[tableName].Columns.Add("Name");
            dataset.Tables[tableName].Columns.Add("Address");
            dataset.Tables[tableName].Columns.Add("Contact No");
            dataset.Tables[tableName].Columns.Add("Email");
            dataset.Tables[tableName].Columns.Add("Enrolled Program");
            dataset.Tables[tableName].Columns.Add("Registration Date");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach (string r in rows) {
                string[] items = r.Split(delimiter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);
            }
            this.datagrid_student.ItemsSource = dataset.Tables[0].DefaultView;
        }

        private void button_sortbyname_Click(object sender, RoutedEventArgs e)
        {
            Sort("Name");
        }
        private void Sort(string sortBy)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(datagrid_student.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void button_sortbyregdate_Click(object sender, RoutedEventArgs e)
        {
            Sort("Registration Date");
        }
    }
}
