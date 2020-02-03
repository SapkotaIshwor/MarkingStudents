using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for ViewChart.xaml
    /// </summary>
    public partial class ViewChart : UserControl
    {
        int countAD = 0;
        int countLogic = 0;
        int countProgramming = 0;

        public ViewChart()
        {
            InitializeComponent();
            List<Bar> _bar = new List<Bar>();
            _bar.Add(new Bar() { BarName = "Application Development", Value = 80 });
            _bar.Add(new Bar() { BarName = "Logic and Problem Solvings", Value = 60 });
            _bar.Add(new Bar() { BarName = "Programming", Value = 40 });

            this.DataContext = new RecordCollection(_bar);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            List<string> resLines = new List<string>();
            var lines = File.ReadLines("studentDetails.csv");

            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });

                if (res[5] == "Application Development")
                {
                    countAD++;
                }
                else if (res[5] == "Programming")
                {
                    countProgramming++;
                }
                else if (res[5] == "Logic and Problem Solving")
                {
                    countLogic++;
                }
            }
        }
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
