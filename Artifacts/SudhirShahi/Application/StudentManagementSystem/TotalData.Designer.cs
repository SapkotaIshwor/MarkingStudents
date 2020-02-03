namespace StudentManagementSystem
{
    partial class TotalData
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
            this.TotalDataGridView = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalDataGridView
            // 
            this.TotalDataGridView.AllowUserToAddRows = false;
            this.TotalDataGridView.AllowUserToDeleteRows = false;
            this.TotalDataGridView.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.TotalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TotalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.TotalStudent});
            this.TotalDataGridView.Location = new System.Drawing.Point(39, 61);
            this.TotalDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalDataGridView.Name = "TotalDataGridView";
            this.TotalDataGridView.ReadOnly = true;
            this.TotalDataGridView.RowHeadersWidth = 51;
            this.TotalDataGridView.RowTemplate.Height = 24;
            this.TotalDataGridView.Size = new System.Drawing.Size(499, 313);
            this.TotalDataGridView.TabIndex = 2;
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
            // TotalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TotalDataGridView);
            this.Name = "TotalData";
            this.Text = "TotalData";
            this.Load += new System.EventHandler(this.TotalData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TotalDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TotalDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudent;
    }
}