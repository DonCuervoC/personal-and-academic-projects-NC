﻿#pragma checksum "..\..\AdministrationInter.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A7B10FF67BA0CF376B0EB89F67724B9475A5E5E6170DC04A6B6AA9D2FC67767"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfChantierApp1._2;


namespace WpfChantierApp1._2 {
    
    
    /// <summary>
    /// AdministrationInter
    /// </summary>
    public partial class AdministrationInter : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBlockPrenom;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegleSecurite;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnListOuvriers;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnListOuvrage;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnListSoutraitent;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AdministrationInter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLivraison;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfChantierApp1.2;component/administrationinter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdministrationInter.xaml"
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
            this.txtBlockPrenom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnRegleSecurite = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\AdministrationInter.xaml"
            this.btnRegleSecurite.Click += new System.Windows.RoutedEventHandler(this.btnRegleSecurite_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnListOuvriers = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\AdministrationInter.xaml"
            this.btnListOuvriers.Click += new System.Windows.RoutedEventHandler(this.btnListOuvriers_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnListOuvrage = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\AdministrationInter.xaml"
            this.btnListOuvrage.Click += new System.Windows.RoutedEventHandler(this.btnListOuvrage_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnListSoutraitent = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\AdministrationInter.xaml"
            this.btnListSoutraitent.Click += new System.Windows.RoutedEventHandler(this.btnListSoutraitent_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLivraison = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\AdministrationInter.xaml"
            this.btnLivraison.Click += new System.Windows.RoutedEventHandler(this.btnLivraison_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

