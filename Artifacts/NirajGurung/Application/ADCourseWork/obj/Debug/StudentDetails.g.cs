﻿#pragma checksum "..\..\StudentDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6BA12B224A4891B1CC9DE28043CA8B4CA77383C7BCE4372901C0D502C4513875"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWorkSample;
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


namespace CourseWorkSample {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdStd;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDisplayData;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDate;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReport;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWorkSample;component/studentdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentDetails.xaml"
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
            this.grdStd = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnDisplayData = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\StudentDetails.xaml"
            this.btnDisplayData.Click += new System.Windows.RoutedEventHandler(this.displayDataInGrid_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDate = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\StudentDetails.xaml"
            this.btnDate.Click += new System.Windows.RoutedEventHandler(this.btnSortDate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnName = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\StudentDetails.xaml"
            this.btnName.Click += new System.Windows.RoutedEventHandler(this.btnSortName_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnReport = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\StudentDetails.xaml"
            this.btnReport.Click += new System.Windows.RoutedEventHandler(this.btnReport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\StudentDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.displayCSV_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
