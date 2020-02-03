using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Application_Development_CW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!Login.isLoggedIn)//login windows is called for authentification purpose.
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }

        }
        
        public void clearField()
        {
            tbox_id.Text = "";
            tbox_name.Text = "";
            tbox_address.Text = "";
            tbox_contact.Text = "";
            tbox_email.Text = "";
            tbox_regdate.Text = "";
            datagrid_1.ItemsSource = "";
            combox_1.SelectedItem = "";
            radbutton_sortbydate.IsChecked = false;
            radbutton_sortbyname.IsChecked = false;

            datagrid_2.ItemsSource = "";

        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }
        private void addRecord(string id, string name, string address, string contactno, string email, string enrolprogram, string enroldate)
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine(id + "," + name + "," + address + "," + contactno + "," + email + "," + enrolprogram + "," + enroldate);
            string csvfilepath = "Record.csv";
            File.AppendAllText(csvfilepath, csvcontent.ToString());
        }

        private void button_addrec_Click(object sender, RoutedEventArgs e)
        {

            if (tbox_id.Text.Trim() == "" || tbox_name.Text.Trim() == "" || tbox_address.Text.Trim() == "" || tbox_contact.Text.Trim() == "" || tbox_email.Text.Trim() == "" || tbox_regdate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter all the details.");
            }
            else
            {
                string program = "";
                if (combox_1.Text == "Computing") {
                    program = "Computing";
                }
                else if (combox_1.Text == "Multimedia Technology") {
                    program = "Multimedia Technology";
                }
                else if (combox_1.Text == "Network And IT Security")
                {
                    program = "Network And IT Security";
                }
                else if (combox_1.Text == "Database")
                {
                    program = "Database";
                }
                addRecord(tbox_id.Text, tbox_name.Text, tbox_address.Text, tbox_contact.Text, tbox_email.Text, program, tbox_regdate.Text);
                MessageBox.Show("The record was added succesfully");
                clearField();
            }
        }
        private void retrieveStudentRecord()
        {
            string delimiter = ",";
            string tableName = "Student Record";
            String FileName = "Record.csv";

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

            foreach (string r in rows)
            {
                string[] items = r.Split(delimiter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);

            }
            this.datagrid_1.ItemsSource = dataset.Tables[0].DefaultView;
        }

        private void button_retrec_Click(object sender, RoutedEventArgs e)
        {
            if (radbutton_sortbyname.IsChecked == true)
            {
                retrieveStudentRecord();                
                Sort("Name");
            }
            else if (radbutton_sortbydate.IsChecked == true)
            {
                retrieveStudentRecord();
                Sort("Registration Date");
            }
            else
            {
                retrieveStudentRecord();
            }
        }
        private void getProgramRecord()
        {
            var temp = File.ReadAllLines("Record.csv");
            int com = 0, mul = 0, net = 0, dat =0;
            foreach (string line in temp)
            {
                var delimitedLine = line.Split(',');
                if (delimitedLine[5] == "Computing")
                {
                    com++;
                }
                else if (delimitedLine[5] == "Multimedia Technology")
                {
                    mul++;
                }
                else if (delimitedLine[5] == "Network And IT Security")
                {
                    net++;
                }
                else if (delimitedLine[5] == "Database")
                {
                    dat++;
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Program", typeof(String)),
            new DataColumn("No of Students",typeof(int))});
            dt.Rows.Add("Computing", com);
            dt.Rows.Add("Multimedia Technology", mul);
            dt.Rows.Add("Network And IT Security", net);
            dt.Rows.Add("Database", dat);
            this.datagrid_2.ItemsSource = dt.DefaultView;
            int total = com + mul + net+ dat;
            drawPie((com * 360 / total), Brushes.Red, com);
            drawPie((mul * 360 / total), Brushes.Green, mul);
            drawPie((net * 360 / total), Brushes.Blue, net);
            drawPie((dat * 360 / total), Brushes.Gray, dat);

        }

        Point lastArcPoint = new Point(9999, 9999);
        int lastAngle = 0;

        private void drawPie(int angle, SolidColorBrush color,int prog)
        {
            int curentSliceAngle = angle;
            lastAngle += angle;
            angle = lastAngle;
            PieCanvas2.Width = 200;
            PieCanvas2.Height = 200;
            Double midPoint = 100;

            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            path.Fill = color;
            path.Stroke = color;
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(midPoint, midPoint);
            pathFigure.IsClosed = true;
            Double radius = midPoint;

            LineSegment lineSegment = new LineSegment(new Point(radius + midPoint, midPoint), true);
            if (lastArcPoint.X != 9999 && lastArcPoint.Y != 9999)
            {
                lineSegment = new LineSegment(new Point(lastArcPoint.X, lastArcPoint.Y), true);
            }
            pathFigure.Segments.Add(lineSegment);
            ArcSegment arcSegment = new ArcSegment();
            arcSegment.Point = new Point(midPoint + Math.Cos(angle * Math.PI / 180) * radius, midPoint + Math.Sin(angle * Math.PI / 180) * radius);
            lastArcPoint = new Point(arcSegment.Point.X, arcSegment.Point.Y);
            arcSegment.Size = new Size(radius, radius);
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            pathFigure.Segments.Add(arcSegment);
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            PieCanvas2.Children.Add(path);
            Point labelPoint = new Point(midPoint + Math.Cos((angle - curentSliceAngle / 2) * Math.PI / 180) * radius * 0.8, midPoint + Math.Sin((angle - curentSliceAngle / 2) * Math.PI / 180) * radius * 0.8);
            drawText(labelPoint.X - 7, labelPoint.Y - 7, prog.ToString());

        }

        private void drawText(double x, double y, string text)
        {

            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            textBlock.Foreground = Brushes.White;

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            PieCanvas2.Children.Add(textBlock);

        }

        private void button_progrec_Click(object sender, RoutedEventArgs e)
        {
            getProgramRecord();
            tblox_piechart2.Text = "Pie Chart based on Program Record.";
        }

        private void Sort(string sortBy)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(datagrid_1.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


        private void button_clear1_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }

        private void button_uploadcsv_Click(object sender, RoutedEventArgs e)
        {
            uploadRecord();
        }
        public void uploadRecord()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string[] raw_text = System.IO.File.ReadAllLines(openFileDialog.FileName);
                string[] data_col = null;
                int x = 0;
                DataTable dataTable = new DataTable();
                foreach (string text_line in raw_text)
                {
                    data_col = text_line.Split(",");
                    if (x == 0)

                        for (int i = 0; i <= data_col.Count() - 1; i++)
                        {
                            dataTable.Columns.Add(data_col[i]);
                            //MessageBox.Show(data_col[i]);
                        }
                    else
                    {
                        dataTable.Rows.Add(data_col);
                        addRecord(data_col[0], data_col[1], data_col[2], data_col[3], data_col[4], data_col[5], data_col[6]);
                    }

                    x++;

                }
                this.datagrid_1.ItemsSource = dataTable.DefaultView;
                MessageBox.Show("The record is upadated to database.");

            }
        }

        private void CourseEnrollBtn_Click(object sender, RoutedEventArgs e)
        {
            getProgramRecord();
            
        }

        private void CourseEnrollClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }

        private void combox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pieTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
