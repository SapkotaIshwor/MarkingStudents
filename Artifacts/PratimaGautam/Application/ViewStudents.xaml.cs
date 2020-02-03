using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for ViewStudents.xaml
    /// </summary>
    public partial class ViewStudents : Window
    {
        private BindingSource _studentsBindingSource = new BindingSource();
        private StudentsRepository _studentsRepository = new StudentsRepository();
        public ViewStudents()
        {
            InitializeComponent();
        }
        private void ViewVisitors_Load(object sender, EventArgs e)
        {
            studentDataGridView.IsReadOnly = true;
            
            _studentsBindingSource.DataSource = _studentsRepository.GetStudents(); //click on GetStudents and press f12 to navigate to the function

            //if set to true creates a new object if the list is empty.
            _studentsBindingSource.AllowNew = false;

            //display data in the binding source in the grid.
            //assign the list to the grid.
            studentDataGridView.ItemsSource = _studentsBindingSource;
            //making the grid readonly.
            studentDataGridView.IsReadOnly = true;
        }
    }
}
