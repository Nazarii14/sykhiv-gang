﻿#pragma checksum "..\..\..\Menu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C9102A21794562FF5D2E2205B03EFDA5AFBD4473"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation;
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


namespace Presentation {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 51 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BrigadeName;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WeaponButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddWeaponButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AmmunitionButton;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddAmmunitionButton;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SoldiersButton;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddSoldiersButton;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RoutesButton;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AnalyticsButton;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OutButton;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logoutImage;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView WeaponListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Presentation;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 50 "..\..\..\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BrigadeName_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BrigadeName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.WeaponButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Menu.xaml"
            this.WeaponButton.Click += new System.Windows.RoutedEventHandler(this.WeaponButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddWeaponButton = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\Menu.xaml"
            this.AddWeaponButton.Click += new System.Windows.RoutedEventHandler(this.AddWeaponButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AmmunitionButton = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Menu.xaml"
            this.AmmunitionButton.Click += new System.Windows.RoutedEventHandler(this.AmmunitionButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddAmmunitionButton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\Menu.xaml"
            this.AddAmmunitionButton.Click += new System.Windows.RoutedEventHandler(this.AddAmmunitionButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SoldiersButton = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\Menu.xaml"
            this.SoldiersButton.Click += new System.Windows.RoutedEventHandler(this.SoldierButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddSoldiersButton = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\Menu.xaml"
            this.AddSoldiersButton.Click += new System.Windows.RoutedEventHandler(this.AddSoldierButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RoutesButton = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\Menu.xaml"
            this.RoutesButton.Click += new System.Windows.RoutedEventHandler(this.RoutesButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AnalyticsButton = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.OutButton = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\Menu.xaml"
            this.OutButton.Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.logoutImage = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.WeaponListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 174 "..\..\..\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteWeaponButton_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 182 "..\..\..\Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditWeaponButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

