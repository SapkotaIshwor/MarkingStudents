using System;
using System.Collections.Generic;
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
using System.Data;
using System.Xml.Serialization;


namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for TotalStudents.xaml
    /// </summary>
    public partial class TotalStudents : Window
    {
        public TotalStudents()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            var dataSet = new DataSet();

            dataSet.ReadXml(@"C:\\Users\\Shristita Kunwar\\Documents\\Visual Studio 2013\\Projects\\StudentInformationSystem\\StudentInformationSystem\\bin\\Debug\\StudentDetails.xml");

            DataTable dataTable = dataSet.Tables[0];
            int total_Com = 0;
            int total_Net = 0;
            int total_Mul = 0;

            DataTable dt = new DataTable("tbl");
            dt.Columns.Add("Course Enroll", typeof(String));
            dt.Columns.Add("Total Students", typeof(int));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                String col = dataTable.Rows[i][6].ToString();

                if (col == "Computing")
                {
                    total_Com++;
                }
                else if (col.Equals("Network and It Security"))
                {
                    total_Net++;
                }
                else if (col.Equals("Multimedia Technologies"))
                {
                    total_Mul++;
                }


            }

            dt.Rows.Add("Computing", total_Com);
            dt.Rows.Add("Network and It Security", total_Net);
            dt.Rows.Add("Multimedia Technology", total_Mul);

            Console.WriteLine(dt.Rows.Count);

            dG.DataContext = dt.DefaultView;
        }
    }
}
