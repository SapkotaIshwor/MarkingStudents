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
        DataTable dataT;
        public Sorting()
        {
            InitializeComponent();
        }

        private void ShowData()
        {
            string dataXMLFile = @"C:\XML\student.xml";
            System.Data.DataSet dataSet = new DataSet();
            dataSet.ReadXml(dataXMLFile);

            dataT = new DataTable("dt");
            dataT.Columns.Add("ID", typeof(string));
            dataT.Columns.Add("Name", typeof(string));
            dataT.Columns.Add("Address", typeof(string));
            dataT.Columns.Add("Contact", typeof(string));
            dataT.Columns.Add("CourseEnroll", typeof(string));
            dataT.Columns.Add("RegistrationDate", typeof(string));

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                string s = dataSet.Tables[0].Rows[i][5].ToString();
                DateTime dTime = DateTime.Parse(s);
                dataT.Rows.Add(
                    dataSet.Tables[0].Rows[i][0].ToString(),
                    dataSet.Tables[0].Rows[i][1].ToString(),
                    dataSet.Tables[0].Rows[i][2].ToString(),
                    dataSet.Tables[0].Rows[i][3].ToString(),
                    dataSet.Tables[0].Rows[i][4].ToString(),
                    dTime.ToShortDateString());
            }
            DataView dataView = new DataView(dataT);
            DataGridSorting.ItemsSource = dataView;
        }

        private void BtnRdata(object sender, RoutedEventArgs e)
        {
            ShowData();
        }

        private void BtnIName(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(dataT);
            dataView.Sort = "Name";
            DataGridSorting.ItemsSource = dataView;
        }

        private void BtnIRDate(object sender, RoutedEventArgs e)
        {
            DataView dataView = new DataView(dataT);
            dataView.Sort = "RegistrationDate";
            DataGridSorting.ItemsSource = dataView;
        }     
    }
}
