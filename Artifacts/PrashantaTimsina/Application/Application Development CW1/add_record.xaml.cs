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

namespace Application_Development_CW1
{
    /// <summary>
    /// Interaction logic for add_record.xaml
    /// </summary>
    public partial class add_record : Window
    {
        public add_record()
        {
            InitializeComponent();
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }
        public void clearField() {
            tbox_id.Text = "";
            tbox_name.Text = "";
            tbox_address.Text = "";
            tbox_contactno.Text = "";
            tbox_email.Text = "";
            tbox_enrolledprogram.Text = "";
            tbox_regdate.Text = "";
        }

        private void button_addrecord_Click(object sender, RoutedEventArgs e)
        {
            if (tbox_id.Text.Trim() == "" || tbox_name.Text.Trim() == "" || tbox_address.Text.Trim()=="" || tbox_contactno.Text.Trim() == "" || tbox_email.Text.Trim() == "" || tbox_enrolledprogram.Text.Trim() == "" || tbox_regdate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter all the details.");
            }
            else { 
                string filename = tbox_id.Text + "_" + tbox_name.Text;
                addRecord(tbox_id.Text, tbox_name.Text, tbox_address.Text, tbox_contactno.Text, tbox_email.Text, tbox_enrolledprogram.Text, tbox_regdate.Text, filename + ".csv");
                MessageBox.Show("The record was added succesfully");
                clearField();
            }
        }
        private void addRecord(string id, string name, string address, string contactno, string email, string enrolprogram, string enroldate, string filename) {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine(id + "," + name + "," + address + "," + contactno + "," + email + "," + enrolprogram + "," + enroldate);
            string csvfilepath = "C:\\Users\\Prashanta Timsina\\Desktop\\StudentRecord.csv";
            File.AppendAllText(csvfilepath,csvcontent.ToString());
        }

    }
}
