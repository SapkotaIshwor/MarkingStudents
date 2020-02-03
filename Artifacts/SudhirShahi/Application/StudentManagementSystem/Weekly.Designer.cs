namespace StudentManagementSystem
{
    partial class Weekly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WeeklyDataGridView = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WeeklyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WeeklyDataGridView
            // 
            this.WeeklyDataGridView.AllowUserToAddRows = false;
            this.WeeklyDataGridView.AllowUserToDeleteRows = false;
            this.WeeklyDataGridView.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.WeeklyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeeklyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.TotalStudent});
            this.WeeklyDataGridView.Location = new System.Drawing.Point(12, 66);
            this.WeeklyDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WeeklyDataGridView.Name = "WeeklyDataGridView";
            this.WeeklyDataGridView.ReadOnly = true;
            this.WeeklyDataGridView.RowHeadersWidth = 51;
            this.WeeklyDataGridView.RowTemplate.Height = 24;
            this.WeeklyDataGridView.Size = new System.Drawing.Size(499, 313);
            this.WeeklyDataGridView.TabIndex = 1;
            this.WeeklyDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeeklyDataGridView_CellContentClick);
            // 
            // Course
            // 
            this.Course.HeaderText = "Programme";
            this.Course.MinimumWidth = 6;
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            this.Course.Width = 125;
            // 
            // TotalStudent
            // 
            this.TotalStudent.HeaderText = "Total Student";
            this.TotalStudent.MinimumWidth = 6;
            this.TotalStudent.Name = "TotalStudent";
            this.TotalStudent.ReadOnly = true;
            this.TotalStudent.Width = 125;
            // 
            // Weekly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WeeklyDataGridView);
            this.Name = "Weekly";
            this.Text = "Weekly";
            this.Load += new System.EventHandler(this.Weekly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeeklyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeeklyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudent;
    }
}