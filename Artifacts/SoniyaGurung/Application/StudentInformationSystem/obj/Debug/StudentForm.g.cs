﻿#pragma checksum "..\..\StudentForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C80AE68061752770AD5F3B189B8DF47288413230731BD1EB722D477B6B390595"
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
    /// StudentForm
    /// </summary>
    public partial class StudentForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtContact;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker rDate;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cEnroll;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridXAML;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWeekly;
        
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
            System.Uri resourceLocater = new System.Uri("/StudentInformationSystem;component/studentform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentForm.xaml"
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
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtContact = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.rDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.cEnroll = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.saveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\StudentForm.xaml"
            this.saveBtn.Click += new System.Windows.RoutedEventHandler(this.BtnSave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DataGridXAML = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 41 "..\..\StudentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSort);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 42 "..\..\StudentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnImport);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnWeekly = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\StudentForm.xaml"
            this.btnWeekly.Click += new System.Windows.RoutedEventHandler(this.BtnWeekly);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 44 "..\..\StudentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnChart);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
