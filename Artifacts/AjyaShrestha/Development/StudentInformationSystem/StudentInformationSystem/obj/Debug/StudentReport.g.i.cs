﻿#pragma checksum "..\..\StudentReport.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D67C1509E12D1F67A44EB93CE33DB84C2088E90BEB49D69F4A0347538193AE3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentInformationSystem;
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


namespace StudentInformationSystem {
    
    
    /// <summary>
    /// StudentReport
    /// </summary>
    public partial class StudentReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridReport;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_retrive;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_sortbydate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_sortbyname;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_weeklyreport;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_chart;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\StudentReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Csv;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentInformationSystem;component/studentreport.xaml", System.UriKind.Relative);
            
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
            this.DataGridReport = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btn_retrive = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\StudentReport.xaml"
            this.btn_retrive.Click += new System.Windows.RoutedEventHandler(this.btn_retrive_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_sortbydate = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\StudentReport.xaml"
            this.btn_sortbydate.Click += new System.Windows.RoutedEventHandler(this.btn_sortbydate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_sortbyname = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\StudentReport.xaml"
            this.btn_sortbyname.Click += new System.Windows.RoutedEventHandler(this.btn_sortbyname_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_weeklyreport = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\StudentReport.xaml"
            this.btn_weeklyreport.Click += new System.Windows.RoutedEventHandler(this.btn_weeklyreport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_chart = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\StudentReport.xaml"
            this.btn_chart.Click += new System.Windows.RoutedEventHandler(this.btn_chart_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Csv = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\StudentReport.xaml"
            this.btn_Csv.Click += new System.Windows.RoutedEventHandler(this.btn_Csv_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
