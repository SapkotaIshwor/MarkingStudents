using DataHandler;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace AppDevelopmentCW
{
    /// <summary>
    /// Interaction logic for Course.xaml
    /// </summary>
    public partial class Course : Page
    {
        public Course()
        {
            InitializeComponent();
        }

        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage());

        }

        private void SaveCourseData(object sender, RoutedEventArgs e)
        {
            var handler = new Handler();
            var dataSet = handler.CreateDataSet();
            AppendCourseData(dataSet);

            var courseName = txtCourseName.Text.ToUpper();
            var displayName = txtDisplayName.Text;
            dataSet.Tables["Student"].WriteXml(@"../../Files/courseList/" + courseName + ".xml");


            MessageBox.Show("Course is saved!!");
            ClearControls();

        }

        private void AppendCourseData(DataSet dataSet)
        {
            var handler = new Handler();
            if (System.IO.File.Exists(@"../../Files/AllCourses.xml"))
            {
                dataSet.Tables["AllCourses"].ReadXml(@"../../Files/AllCourses.xml");
            }

            var dr = dataSet.Tables["AllCourses"].NewRow();
            dr["Name"] = txtCourseName.Text;
            dr["DisplayText"] = txtDisplayName.Text;
            dataSet.Tables["AllCourses"].Rows.Add(dr);

            dataSet.Tables["AllCourses"].WriteXml(@"../../Files/AllCourses.xml");

        }

        public void ClearControls()
        {
            txtCourseName.Text = "";
            txtDisplayName.Text = "";

        }


    }
}
