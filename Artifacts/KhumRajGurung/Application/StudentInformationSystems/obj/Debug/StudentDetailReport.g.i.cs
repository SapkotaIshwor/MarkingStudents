﻿#pragma checksum "..\..\StudentDetailReport.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5BD827B54EAE451C8628902F54BAA791662DD9529099A6B821F21DBC21538D0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StudentInformationSystems;
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


namespace StudentInformationSystems {
    
    
    /// <summary>
    /// StudentDetailReport
    /// </summary>
    public partial class StudentDetailReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStudentRecord;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortRegDate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdStudentDetails;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StudentDetailReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddStudent;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentInformationSystems;component/studentdetailreport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentDetailReport.xaml"
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
            this.btnStudentRecord = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\StudentDetailReport.xaml"
            this.btnStudentRecord.Click += new System.Windows.RoutedEventHandler(this.btnStudentRecord_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnSortRegDate = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\StudentDetailReport.xaml"
            this.btnSortRegDate.Click += new System.Windows.RoutedEventHandler(this.btnSortRegDate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSortName = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\StudentDetailReport.xaml"
            this.btnSortName.Click += new System.Windows.RoutedEventHandler(this.btnSortName_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\StudentDetailReport.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grdStudentDetails = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnAddStudent = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\StudentDetailReport.xaml"
            this.btnAddStudent.Click += new System.Windows.RoutedEventHandler(this.btnAddStudent_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
