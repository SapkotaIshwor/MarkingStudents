﻿#pragma checksum "..\..\..\retrieve_record.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93B7F37F65216801DD3D45070E2E1D7E74DF65D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Application_Development_CW1;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Application_Development_CW1 {
    
    
    /// <summary>
    /// retrieve_record
    /// </summary>
    public partial class retrieve_record : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\retrieve_record.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_retrecord;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\retrieve_record.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_student;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\retrieve_record.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_sortbyname;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\retrieve_record.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_sortbyregdate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Application Development CW1;component/retrieve_record.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\retrieve_record.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.button_retrecord = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\retrieve_record.xaml"
            this.button_retrecord.Click += new System.Windows.RoutedEventHandler(this.button_retrecord_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datagrid_student = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.button_sortbyname = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\retrieve_record.xaml"
            this.button_sortbyname.Click += new System.Windows.RoutedEventHandler(this.button_sortbyname_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_sortbyregdate = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\retrieve_record.xaml"
            this.button_sortbyregdate.Click += new System.Windows.RoutedEventHandler(this.button_sortbyregdate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
