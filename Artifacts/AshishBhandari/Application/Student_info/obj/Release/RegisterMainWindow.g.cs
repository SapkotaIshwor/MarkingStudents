﻿#pragma checksum "..\..\RegisterMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "89A56EA7731E77EF6D77F1B09FC5673C91E45B0ED8A8E4E341F46FF19A5AC6D7"
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
    /// RegisterMainWindow
    /// </summary>
    public partial class RegisterMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\RegisterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button individualRegister;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\RegisterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bilkRegister;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\RegisterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Student_info;component/registermainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterMainWindow.xaml"
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
            this.individualRegister = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\RegisterMainWindow.xaml"
            this.individualRegister.Click += new System.Windows.RoutedEventHandler(this.individualRegister_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bilkRegister = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\RegisterMainWindow.xaml"
            this.bilkRegister.Click += new System.Windows.RoutedEventHandler(this.bilkRegister_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\RegisterMainWindow.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.back_btn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

