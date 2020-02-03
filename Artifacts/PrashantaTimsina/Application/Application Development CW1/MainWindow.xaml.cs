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
        
        public void clearField()//function to clear textfields,datagrid and radiobuttons.
        {
            tbox_id.Text = "";
            tbox_name.Text = "";
            tbox_address.Text = "";
            tbox_contact.Text = "";
            tbox_email.Text = "";
            tbox_regdate.Text = "";
            datagrid_1.ItemsSource = "";
            radbutton_advdat.IsChecked = false;
            radbutton_appdev.IsChecked = false;
            radbutton_artint.IsChecked = false;
            radbutton_sortbydate.IsChecked = false;
            radbutton_sortbyname.IsChecked = false;
            
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }
        //function to add student record on csv file with several input parameters.
        private void addRecord(string id, string name, string address, string contactno, string email, string enrolprogram, string enroldate)
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine(id + "," + name + "," + address + "," + contactno + "," + email + "," + enrolprogram + "," + enroldate);
            string csvfilepath = "StudentRecord.csv";
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
                if (radbutton_advdat.IsChecked == true) { program = "Advance Database"; }
                else if (radbutton_appdev.IsChecked == true) { program = "Application Development"; }
                else if (radbutton_artint.IsChecked == true) { program = "Artificial Intelligence"; }
                addRecord(tbox_id.Text, tbox_name.Text, tbox_address.Text, tbox_contact.Text, tbox_email.Text, program, tbox_regdate.Text);
                MessageBox.Show("The record was added succesfully");
                clearField();
            }
        }
        private void retrieveStudentRecord()//function to retrieve student record for displaying in datagrid.
        {
            string delimiter = ",";
            string tableName = "Student Record";
            String FileName = "StudentRecord.csv";

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
        private void getProgramRecord()//function to retrieve program record with no of students on each.
        {
            var temp = File.ReadAllLines("StudentRecord.csv");
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
            dt.Rows.Add("Application Development", appdev);
            dt.Rows.Add("Artificial Intelligence", artint);
            dt.Rows.Add("Advance Database", advdat);
            this.datagrid_1.ItemsSource = dt.DefaultView;
            int total = advdat + artint + appdev;
            drawPie((advdat * 360 / total), Brushes.Red, advdat);//drawpie function is called with angle as an input along with respective program.
            drawPie((artint * 360 / total), Brushes.Green, artint);
            drawPie((appdev * 360 / total), Brushes.Blue, appdev);
        }

        Point lastArcPoint = new Point(9999, 9999);
        int lastAngle = 0;

        private void drawPie(int angle, SolidColorBrush color,int prog)//function to draw pie chart with input angle along with color.
        {
            int curentSliceAngle = angle;
            lastAngle += angle;
            angle = lastAngle;
            PieCanvas.Width = 200;
            PieCanvas.Height = 200;
            Double midPoint = 100.0;

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
            PieCanvas.Children.Add(path);
            Point labelPoint = new Point(midPoint + Math.Cos((angle - curentSliceAngle / 2) * Math.PI / 180) * radius * 0.8, midPoint + Math.Sin((angle - curentSliceAngle / 2) * Math.PI / 180) * radius * 0.8);
            drawText(labelPoint.X - 7, labelPoint.Y - 7, prog.ToString());

        }

        private void drawText(double x, double y, string text)//function to draw text for pie chart.
        {

            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            textBlock.Foreground = Brushes.White;

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            PieCanvas.Children.Add(textBlock);

        }

        private void button_progrec_Click(object sender, RoutedEventArgs e)
        {
            getProgramRecord();
            tbox1.Text = "Application Dvelopment";
            tbox2.Text = "Advance Database";
            tbox3.Text = "Artificial Intelligence";
            tblock_title.Text = "Pie Chart based on Program record.";
        }

        private void Sort(string sortBy)//function to sort the datagrid base on given parameter.
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(datagrid_1.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
        public void readUploadRecord()
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
                MessageBox.Show("The record was updated successfully.");

            }
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            readUploadRecord();
        }
    }
}
