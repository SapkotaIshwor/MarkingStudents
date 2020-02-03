using System;
using System.Collections.Generic;
using System.Data;
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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting : Window
    {
        DataTable buffer;

        public Sorting()
        {
            InitializeComponent();
        }

        private void DataShow()
        {
            string dataXMLFile = @"D:\student.xml";
            System.Data.DataSet dataset = new DataSet();
            dataset.ReadXml(dataXMLFile);

            buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(String));
            buffer.Columns.Add("Name", typeof(String));
            buffer.Columns.Add("Address", typeof(String));
            buffer.Columns.Add("Contact", typeof(String));
            buffer.Columns.Add("CourseEnrol", typeof(String));
            buffer.Columns.Add("RegistrationDate", typeof(String));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                string s = dataset.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataset.Tables[0].Rows[i][0].ToString(),
                    dataset.Tables[0].Rows[i][1].ToString(),
                    dataset.Tables[0].Rows[i][2].ToString(),
                    dataset.Tables[0].Rows[i][3].ToString(),
                    dataset.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());
            }
            DataView dataView = new DataView(buffer);
            DataGridSorting.ItemsSource = dataView;
        }

        private void btn_SortByName(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "Name ASC";
            DataGridSorting.ItemsSource = dataView;
        }

        private void btn_SortByDate(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "RegistrationDate ASC";
            DataGridSorting.ItemsSource = dataView;
        }

        private void btn_Retrieve(object sender, RoutedEventArgs e)
        {
            DataShow();
        }
    }
}
