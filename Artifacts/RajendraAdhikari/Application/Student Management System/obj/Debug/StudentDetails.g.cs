﻿#pragma checksum "..\..\StudentDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C1099B6D936A7B4BD6C4433D7698338B732C7BF0EB8CA618CBF860B56CF1AA8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Student_Management_System;
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


namespace Student_Management_System {
    
    
    /// <summary>
    /// StudentDetails
    /// </summary>
    public partial class StudentDetails : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg3rd;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SortByNameBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\StudentDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SortByDateBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Student Management System;component/studentdetails.xaml", System.UriKind.Relative);
            
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
            this.dg3rd = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ViewBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\StudentDetails.xaml"
            this.ViewBtn.Click += new System.Windows.RoutedEventHandler(this.ViewBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SortByNameBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\StudentDetails.xaml"
            this.SortByNameBtn.Click += new System.Windows.RoutedEventHandler(this.SortByNameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SortByDateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\StudentDetails.xaml"
            this.SortByDateBtn.Click += new System.Windows.RoutedEventHandler(this.SortByDateBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
