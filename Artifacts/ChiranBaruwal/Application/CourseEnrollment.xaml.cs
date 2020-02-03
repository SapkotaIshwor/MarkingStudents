using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Information_System
{
    /// <summary>
    /// Interaction logic for CourseEnrollment.xaml
    /// </summary>
    public partial class CourseEnrollment : UserControl
    {

        private FileHandler filehandler = new FileHandler();
        ObservableCollection<StudentDetails> students;
        private IDictionary<string, int> studentCounter = new Dictionary<string, int>();
        public CourseEnrollment()
        {
            InitializeComponent();
            displayChart();
        }

        public void displayChart()
        {
            countStudents();
            List<Bar> _bar = new List<Bar>();
            _bar.Add(new Bar() { BarName = "Computing", Value = studentCounter["Computing"] });
            _bar.Add(new Bar() { BarName = "Multimedia", Value = studentCounter["Multimedia"] });
            _bar.Add(new Bar() { BarName = "Programming", Value = studentCounter["Programming"] });
            this.DataContext = new RecordCollection(_bar);
        }

        public void countStudents()
        {
            students = filehandler.getData();
            studentCounter["Computing"] = studentCounter["Multimedia"] = studentCounter["Programming"] = 0;

            for (int i = 0; i < students.Count; i++)
            {
                switch (students[i].CourseEnrolled)
                {
                    case "Computing":
                        studentCounter["Computing"]++;
                        break;
                    case "Multimedia":
                        studentCounter["Multimedia"]++;
                        break;
                    case "Programming":
                        studentCounter["Programming"]++;
                        break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            displayChart();
        }
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

    class Bar
    {

        public string BarName { set; get; }

        public int Value { set; get; }

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


