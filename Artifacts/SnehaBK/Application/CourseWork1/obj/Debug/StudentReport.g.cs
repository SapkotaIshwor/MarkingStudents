﻿#pragma checksum "..\..\StudentReport.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E7A74D1A6F65D89CDC6B453C7149CC0896116AE019B9FDE87407872251D35F70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWork1;
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


namespace CourseWork1 {
    
    
    /// <summary>
    /// StudentReport
    /// </summary>
    public partial class StudentReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWeekReport;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDate;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRetrive;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCsv;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWork1;component/studentreport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentReport.xaml"
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
            this.btnWeekReport = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\StudentReport.xaml"
            this.btnWeekReport.Click += new System.Windows.RoutedEventHandler(this.BtnWeekReport_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDate = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\StudentReport.xaml"
            this.btnDate.Click += new System.Windows.RoutedEventHandler(this.BtnDate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSortName = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\StudentReport.xaml"
            this.btnSortName.Click += new System.Windows.RoutedEventHandler(this.BtnSortName_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnRetrive = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\StudentReport.xaml"
            this.btnRetrive.Click += new System.Windows.RoutedEventHandler(this.BtnRetrive_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGrid2 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnCsv = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\StudentReport.xaml"
            this.btnCsv.Click += new System.Windows.RoutedEventHandler(this.BtnCsv_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

