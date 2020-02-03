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
    /// Interaction logic for generate_report.xaml
    /// </summary>
    public partial class generate_report : Window
    {
        public generate_report()
        {
            InitializeComponent();
        }

        private void button_generatereport_Click(object sender, RoutedEventArgs e)
        {
            getRecord();
        }
        private void getRecord() {
            var temp = File.ReadAllLines("C:\\Users\\Prashanta Timsina\\Desktop\\StudentRecord.csv");
            int advdat = 0, artint = 0, appdev = 0;
            foreach (string line in temp)
            {
                var delimitedLine = line.Split(',');
                if (delimitedLine[5] == "Advance Database")
                {
                    advdat++;
                }
                else if (delimitedLine[5] == "Artificial Intelligence")
                {
                    artint++;
                }
                else if (delimitedLine[5] == "Application Development")
                {
                    appdev++;
                }
                               
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Program", typeof(String)),
            new DataColumn("No of Students",typeof(int))});
            dt.Rows.Add("Application Development",appdev);
            dt.Rows.Add("Artificial Intelligence", artint);
            dt.Rows.Add("Advance Database", advdat);
            datagrid_programrecord.ItemsSource = dt.DefaultView;
        }

        
    }
}
