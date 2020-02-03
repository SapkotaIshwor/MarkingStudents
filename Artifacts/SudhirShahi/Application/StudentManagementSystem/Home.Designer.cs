namespace StudentManagementSystem
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weakelyEnrolmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortedByRegistrationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortedByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem,
            this.weakelyEnrolmentReportToolStripMenuItem,
            this.coursesToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.studentToolStripMenuItem.Text = "Register Student";
            this.studentToolStripMenuItem.Click += new System.EventHandler(this.studentToolStripMenuItem_Click);
            // 
            // weakelyEnrolmentReportToolStripMenuItem
            // 
            this.weakelyEnrolmentReportToolStripMenuItem.Name = "weakelyEnrolmentReportToolStripMenuItem";
            this.weakelyEnrolmentReportToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.weakelyEnrolmentReportToolStripMenuItem.Text = "Weekly Enrolment Report";
            this.weakelyEnrolmentReportToolStripMenuItem.Click += new System.EventHandler(this.weakelyEnrolmentReportToolStripMenuItem_Click);
            // 
            // coursesToolStripMenuItem
            // 
            this.coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            this.coursesToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.coursesToolStripMenuItem.Text = "Total student on each program";
            this.coursesToolStripMenuItem.Click += new System.EventHandler(this.coursesToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortedByRegistrationDateToolStripMenuItem,
            this.sortedByNameToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // sortedByRegistrationDateToolStripMenuItem
            // 
            this.sortedByRegistrationDateToolStripMenuItem.Name = "sortedByRegistrationDateToolStripMenuItem";
            this.sortedByRegistrationDateToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.sortedByRegistrationDateToolStripMenuItem.Text = "Sorted by Registration Date";
            this.sortedByRegistrationDateToolStripMenuItem.Click += new System.EventHandler(this.sortedByRegistrationDateToolStripMenuItem_Click);
            // 
            // sortedByNameToolStripMenuItem
            // 
            this.sortedByNameToolStripMenuItem.Name = "sortedByNameToolStripMenuItem";
            this.sortedByNameToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.sortedByNameToolStripMenuItem.Text = "Sorted by Name";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::StudentManagementSystem.Properties.Resources.school1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weakelyEnrolmentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortedByRegistrationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortedByNameToolStripMenuItem;
    }
}