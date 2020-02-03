
## Student Information System
#### course-work-1-pratimagtm977

#### Research:
	
*   Only Numbers in a wpf textbox with regular expressions

    https://programmingistheway.wordpress.com/2017/02/17/only-numbers-in-a-wpf-textbox-with-regular-expressions/

*   The DatePicker Control
    <DatePicker x:Name="regDate"  SelectedDate="2020-01-01" HorizontalAlignment="Left" Margin="205,253.2,0,0" Grid.Row="1" VerticalAlignment="Top" Width="202" Height="30" SelectedDateFormat="Short"/>

    https://www.wpf-tutorial.com/misc-controls/the-datepicker-control/

*   Login and Registration
    https://www.c-sharpcorner.com/UploadFile/prathore/login-and-registration-process-in-wpf-application/

*   Message Box
    
    ```
    MessageBox.Show("Hello, world!", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
    ```
    
    https://www.c-sharpcorner.com/UploadFile/mahesh/messagebox-in-wpf/
    https://www.wpf-tutorial.com/dialogs/the-messagebox/

*   How do you center your main window in WPF?
    https://stackoverflow.com/questions/4019831/how-do-you-center-your-main-window-in-wpf

*   Textbox - text centering
    https://stackoverflow.com/questions/3485727/textbox-text-centering
    ```
    VerticalAlignment="Stretch" 
    VerticalContentAlignment="Center"
    ```

    https://codedocu.com/Details?d=1820&a=9&f=273&l=0&v=d
    ```xml
    <TextBox VerticalAlignment="Center" Padding="5" >
    Center+Padding
    </TextBox>
    ```

*   Making Non-editable textbox in WPF
    IsReadOnly = "True" in xaml of textbox.

*   Check if combobox value is empty
    https://stackoverflow.com/questions/26773729/check-if-combobox-value-is-empty

    ```csharp   
    if (string.IsNullOrEmpty(comboBox1.Text))  
    ```

    or

    ```csharp   
    if (comboBox1.SelectedIndex == -1)
    ```

*   Using Markdown

    https://docs.microsoft.com/en-us/contribute/how-to-write-use-markdown

*   The name 'InitializeComponent' does not exist in the current context.

    https://stackoverflow.com/questions/6925584/the-name-initializecomponent-does-not-exist-in-the-current-context

    Check the Designer file.

    I had this same issue. In my case, the cause was that the namespace for FileName.Designer.cs did not match the (correct) namespace used in FileName.cs.

    Changing the namespace of FileName.Designer.cs to match that of FileName.cs solved the problem immediately.

*   String was not recognized as a valid DateTime “ format dd/MM/yyyy”

    https://stackoverflow.com/questions/2193012/string-was-not-recognized-as-a-valid-datetime-format-dd-mm-yyyy

*   Loading CSV file to DataGrid: Example
  
    ```csharp
    //Location of CSV File
    string CSVDataBase = @"D:\temp\Book1.csv";

    //Create Collection for DataGrid Source
    ICollection CreateDataSource()
    {
        //Create new DataTables and Rows
        DataTable dt = new DataTable();
        DataRow dr;

        //Create Column Headers
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("Age", typeof(string)));
        dt.Columns.Add(new DataColumn("Gender", typeof(string)));


        //For each line in the File
        foreach (string Line in File.ReadLines(CSVDataBase))
        {
            //Split lines at delimiter ';''

            //Create new Row
            dr = dt.NewRow();

            //ID=
            dr[0] = Line.Split(';').ElementAt(0);

            //Name =
            dr[1] = Line.Split(';').ElementAt(1);

            //Age=
            dr[2] = Line.Split(';').ElementAt(2);

            //Gender= 
            dr[3] = Line.Split(';').ElementAt(3);

            //Add the row we created
            dt.Rows.Add(dr);
        }

        //Return Dataview 
        DataView dv = new DataView(dt);
        return dv;
    }
    ```

*   How can I get the current user directory?   

    ```csharp
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    ```

*   Sort a wpf datagrid programmatically

    ```csharp
    dgv.Items.SortDescriptions.Clear();
    dgv.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Descending));
    dgv.Items.Refresh();
    ```

*   Charting in WPF
    https://www.c-sharpcorner.com/UploadFile/mahesh/charting-in-wpf/