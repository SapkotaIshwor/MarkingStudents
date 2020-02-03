using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ApplicationDevelopmentCw1
{
    /// <summary>
    /// Interaction logic for viewChart.xaml
    /// </summary>
    public partial class viewChart : Window
    {
        private string CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecords.xml";
        private string CurrentSchemaPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\StudentRecordsSchema.xml";
        public viewChart()
        {
            InitializeComponent();
            List<Bar> _bar = new List<Bar>();
            var dataset = new DataSet();
            if (File.Exists(CurrentPath) && File.Exists(CurrentSchemaPath))
            {
                dataset.ReadXmlSchema(CurrentSchemaPath);
                dataset.ReadXml(CurrentPath);
                dataset.WriteXmlSchema(CurrentSchemaPath);
                dataset.WriteXml(CurrentPath);
              
               

            }
            else
            {
                dataset.WriteXmlSchema(CurrentSchemaPath);
                dataset.WriteXml(CurrentPath);
                dataset.ReadXml(CurrentPath);


            }
            try
            {


                DataTable stdReports = dataset.Tables[0];
                int total_Computing = 0;
                int total_Networking = 0;
                int multi_media = 0;
                int AI = 0;

                DataTable dt = new DataTable("WeeklyData");

                dt.Columns.Add("Course Enroll", typeof(string));
                dt.Columns.Add("Total Students", typeof(int));
                for (int i = 0; i < stdReports.Rows.Count; i++)
                {
                    string col = stdReports.Rows[i]["CourseEnroll"].ToString();

                    if (col == "Computing")
                    {
                        total_Computing++;
                    }
                    else if (col == "Multimedia Technologies")
                    {
                        multi_media++;

                    }
                    else if (col == "Networking")
                    {
                        total_Networking++;
                    }
                    else if (col == "Artificial Intelligence")
                    {
                        AI++;
                    }
                }
                dt.Rows.Add("Multimedia Technologies", multi_media);
                dt.Rows.Add("Computing", total_Computing);
                dt.Rows.Add("Networking", total_Networking);
                dt.Rows.Add("Artificial Intelligence", AI);
                _bar.Add(new Bar() { BarName = "Multimedia Technologies", Value = multi_media });
                _bar.Add(new Bar() { BarName = "Computing", Value = total_Computing });
                _bar.Add(new Bar() { BarName = "Networking", Value = total_Networking });
                _bar.Add(new Bar() { BarName = "Artificial Intelligence", Value = AI });
                this.DataContext = new RecordCollection(_bar);
                gridTotalstd.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No Data found", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
    }
    class Bar
    {

        public string BarName { set; get; }

        public int Value { set; get; }

    }
    class RecordCollection : ObservableCollection<Record>
    {

        public RecordCollection(List<Bar> barvalues)
        {
            Random rand = new Random();
            BrushCollection brushcoll = new BrushCollection();

            foreach (Bar barval in barvalues)
            {
                int num = rand.Next(brushcoll.Count / 3);
                Add(new Record(barval.Value, brushcoll[num], barval.BarName));
            }
        }

    }
    class BrushCollection : ObservableCollection<Brush>
    {
        public BrushCollection()
        {
            Type _brush = typeof(Brushes);
            PropertyInfo[] props = _brush.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Brush _color = (Brush)prop.GetValue(null, null);
                if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                     _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                     _color != Brushes.LightYellow && _color != Brushes.Linen)
                    Add(_color);
            }
        }
    }
    class Record : INotifyPropertyChanged
    {
        public Brush Color { set; get; }

        public string Name { set; get; }

        private int _data;
        public int Data
        {
            set
            {
                if (_data != value)
                {
                    _data = value;

                }
            }
            get
            {
                return _data;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Record(int value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    }
}
