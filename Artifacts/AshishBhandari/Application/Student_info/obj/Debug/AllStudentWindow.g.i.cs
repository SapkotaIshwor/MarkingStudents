﻿#pragma checksum "..\..\AllStudentWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED8782F9D0CBB8AC78364823EA615A5BDCBA0ECB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Student_info;
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


namespace Student_info {
    
    
    /// <summary>
    /// AllStudentWindow
    /// </summary>
    public partial class AllStudentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridView;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortData;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton onBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton offBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ascendingBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AllStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton descendingBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Student_info;component/allstudentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AllStudentWindow.xaml"
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
            this.gridView = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AllStudentWindow.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.back_btn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sortData = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\AllStudentWindow.xaml"
            this.sortData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.sortData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.onBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\AllStudentWindow.xaml"
            this.onBtn.Checked += new System.Windows.RoutedEventHandler(this.onBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.offBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 29 "..\..\AllStudentWindow.xaml"
            this.offBtn.Checked += new System.Windows.RoutedEventHandler(this.offBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ascendingBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\AllStudentWindow.xaml"
            this.ascendingBtn.Checked += new System.Windows.RoutedEventHandler(this.ascending_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.descendingBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\AllStudentWindow.xaml"
            this.descendingBtn.Checked += new System.Windows.RoutedEventHandler(this.descending_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

