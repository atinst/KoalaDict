﻿#pragma checksum "..\..\..\UserControl\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D1BDF7069F7DA6854413D08262DBEF40F3680E0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using KoalaDictDemo;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace KoalaDictDemo {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\UserControl\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleBar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControl\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UserControl\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassBox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UserControl\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\UserControl\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserBox;
        
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
            System.Uri resourceLocater = new System.Uri("/KoalaDictDemo;component/usercontrol/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\Login.xaml"
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
            this.TitleBar = ((System.Windows.Controls.Label)(target));
            
            #line 32 "..\..\..\UserControl\Login.xaml"
            this.TitleBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TitleBar_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CloBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\UserControl\Login.xaml"
            this.CloBtn.Click += new System.Windows.RoutedEventHandler(this.CloBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PassBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 62 "..\..\..\UserControl\Login.xaml"
            this.PassBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.PassBox_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LoginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\UserControl\Login.xaml"
            this.LoginBtn.Click += new System.Windows.RoutedEventHandler(this.LoginBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

