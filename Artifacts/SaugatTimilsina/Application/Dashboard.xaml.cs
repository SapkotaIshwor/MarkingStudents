using System;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private ReadWrite readWrite = new ReadWrite();
        private const String FILE_NAME = "file.dat";
        private String toStore, chosenFile;
        private ReadWrite rw = new ReadWrite();
        string[] str = new string[] {"Computing", "Multimedia Technologies", "Network & IT Security"};
        public Dashboard()
        {
            InitializeComponent();
            cbProgram.ItemsSource = str;
            cbProgram.SelectedIndex = 0;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsNumeric(String Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void btnEnroll_Click(object sender, RoutedEventArgs e)
        {
            int a = readWrite.getLength() + 1;
            Console.WriteLine("Value of file length: " + a);
            int ID = a++;
            String firstName = tbFirstName.Text.Trim();
            String lastName = tbLastName.Text.Trim();
            String contact = tbContact.Text.Trim();
            String email = tbEmail.Text.Trim();
            String address = tbAddress.Text.Trim();
            String program = cbProgram.Text;
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) ||
                String.IsNullOrEmpty(contact) || String.IsNullOrEmpty(email) ||
                String.IsNullOrEmpty(address) || String.IsNullOrEmpty(program))
            {
                MessageBox.Show("Empty Values!", "Please fill all the fields.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (IsValidEmail(email))
                {
                    if (IsNumeric(contact))
                    {
                        String date = DateTime.Now.ToString("yyyy'/'MM'/'dd");
                        toStore = ID + "," + firstName + "," + lastName + "," + address + "," + program + "," + email + "," + contact + "," + date;
                        readWrite.Write(toStore);
                        MessageBox.Show("Student enrolled successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        tbFirstName.Text = "";
                        tbLastName.Text = "";
                        tbContact.Text = "";
                        tbEmail.Text = "";
                        tbAddress.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid Phone number.", "Invalid Phone number", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid email.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            String toSearch = tbSearchName.Text.ToLower().Trim();
            String[,] records = readWrite.Read();
            Boolean matchingFound = false;
            //int rowsOrHeight = ary.GetLength(0);
            //int colsOrWidth = ary.GetLength(1);
            for (int i = 0; i < records.GetLength(0); i++)
            {
                String record = null;
                for (int j = 0; j < records.GetLength(1); j++)
                {
                    record += records[i, j];
                    if (j == 1)
                    {
                        if (records[i, j].ToLower() == toSearch)
                        {
                            matchingFound = true;
                        }
                    }
                }
                if (matchingFound)
                {
                    MessageBox.Show("Id: " + records[i, 0] + "\n" +
                                    "First Name: " + records[i, 1] +"\n"+
                                    "Last Name: " + records[i, 2] +"\n"+
                                    "Address: " + records[i, 3] +"\n"+
                                    "Programme: " + records[i, 4] +"\n"+
                                    "Email: " + records[i, 5] +"\n"+
                                    "Contact: " + records[i, 6] +"\n"+
                                    "Enroll Date: " + records[i, 7] +"\n", "Match found!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            if (!matchingFound)
            {
                MessageBox.Show("No Matching result found", "No match!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            if (rw.Read() != null)
            {
                Report win3 = new Report();
                win3.Show();
                this.Close();
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("The file to be imported should be (.csv comma delimited)\n" +
                "The imported file should also have columns with following data order:\n" +
                "Id, First Name, LastName, Address, Programme, Email, Contact, Date",
                "Do you want to continue importing your file?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel documents (.csv)|*.csv";
                Nullable<bool> result = openFileDialog.ShowDialog();
                // Get the selected file name and display in a TextBox.
                // Load content of file in a TextBlock
                if (result == true)
                {
                    chosenFile = openFileDialog.FileName;
                    Console.WriteLine("FileName: " + openFileDialog.FileName);
                    //TextBlock1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                    //Excel File Handling
                    Excel.Application excelApp = new Excel.Application();
                    if (excelApp != null)
                    {
                        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(chosenFile, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
                        Excel.Range excelRange = excelWorksheet.UsedRange;
                        int rowCount = excelRange.Rows.Count;
                        int colCount = excelRange.Columns.Count;
                        Console.WriteLine("RowCount: " + rowCount + "ColCount: " + colCount);
                        string cellValue = null;
                        Boolean importFlag = false;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            Excel.Range range = (excelWorksheet.Cells[i, 1] as Excel.Range);
                            try
                            {
                                cellValue = range.Value.ToString();
                            }
                            catch
                            {
                                importFlag = true;
                                MessageBox.Show("Sorry! The file you chose had no data.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            Console.WriteLine("CellValue: " + cellValue);
                            readWrite.Write(cellValue);
                        }
                        if (!importFlag)
                        {
                            MessageBox.Show("Data successfully imported.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        excelWorkbook.Close();
                        excelApp.Quit();
                    }
                }
            }
        }
    }
}
