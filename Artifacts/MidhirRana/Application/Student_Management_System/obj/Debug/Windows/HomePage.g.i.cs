﻿#pragma checksum "..\..\..\Windows\HomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "597E387E2ABB44F02791D1C8FC2CCB0987AFD73FFCD28354733E02E4A02803CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Student_Management_System.Forms;
using Student_Management_System.ViewModels;
using Student_Management_System.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Student_Management_System.Forms {
    
    
    /// <summary>
    /// HomePage
    /// </summary>
    public partial class HomePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Windows\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnroll;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Windows\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImportFile;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWeeklyReport;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewChart;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Student_Management_System;component/windows/homepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\HomePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnEnroll = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Windows\HomePage.xaml"
            this.btnEnroll.Click += new System.Windows.RoutedEventHandler(this.Enrollbtn_Clicked);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 40 "..\..\..\Windows\HomePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewStudents_ButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnImportFile = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Windows\HomePage.xaml"
            this.btnImportFile.Click += new System.Windows.RoutedEventHandler(this.ImportFileButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnWeeklyReport = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Windows\HomePage.xaml"
            this.btnWeeklyReport.Click += new System.Windows.RoutedEventHandler(this.WeeklyReport_keyAction);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnViewChart = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Windows\HomePage.xaml"
            this.btnViewChart.Click += new System.Windows.RoutedEventHandler(this.ViewInChart_Clicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

