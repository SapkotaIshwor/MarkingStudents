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

namespace Coursework
{
    /// <summary>
    /// Interaction logic for SortingDetail.xaml
    /// </summary>
    public partial class SortingDetail : Window
    {
        DataTable buffer;
        

        public SortingDetail()
        {
            InitializeComponent();
        }
        private void DataShow()
        {
            string dataXMLFile = @"D:\student.xml";
            System.Data.DataSet dataSet = new DataSet();
            dataSet.ReadXml(dataXMLFile);

            buffer = new DataTable("dt");
            buffer.Columns.Add("ID", typeof(string));
            buffer.Columns.Add("Name", typeof(string));
            buffer.Columns.Add("Address", typeof(string));
            buffer.Columns.Add("Contact", typeof(string));
            buffer.Columns.Add("CourseEnroll", typeof(string));
            buffer.Columns.Add("RegistrationDate", typeof(string));

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                string s = dataSet.Tables[0].Rows[i][5].ToString();
                DateTime dtime = DateTime.Parse(s);
                buffer.Rows.Add(
                    dataSet.Tables[0].Rows[i][0].ToString(),
                    dataSet.Tables[0].Rows[i][1].ToString(),
                    dataSet.Tables[0].Rows[i][2].ToString(),
                    dataSet.Tables[0].Rows[i][3].ToString(),
                    dataSet.Tables[0].Rows[i][4].ToString(),
                    dtime.ToShortDateString());
            }
            DataView dataView = new DataView(buffer);
            DataGridView2.ItemsSource = dataView;
        }

        private void buttonbysortname(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "Name";
            DataGridView2.ItemsSource = dataView;

        }

        private void buttonbysortdate(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(buffer);
            dataView.Sort = "RegistrationDate ";
            DataGridView2.ItemsSource = dataView;

        }

        private void buttonretrieve(object sender, RoutedEventArgs e)
        {
            DataShow();

        }

       
    }
}
