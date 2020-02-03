using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Application_Dev
{
    /// <summary>
    /// Interaction logic for SerializerDeserializer.xaml
    /// </summary>
    public partial class SerializerDeserializer : Window
    {
        public SerializerDeserializer()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog().ToString().Equals("OK")) {

                var path = dlg.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(List<SD>));
                StreamReader reader = new StreamReader(path);

                var input = serializer.Deserialize(reader);

                datagrid1.DataContext = input;
            }

        }
    }
}
