﻿#pragma checksum "..\..\..\DodajUczniaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20076C72E44B867AF92ED6804341703D08DB825F"
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
using Szkola_pele;


namespace Szkola_pele {
    
    
    /// <summary>
    /// DodajUczniaWindow
    /// </summary>
    public partial class DodajUczniaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox imie_ui;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwisko_ui;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox wiek_ui;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inteligencja_ui;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sila_ui;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox zwinnosc_ui;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox charyzma_ui;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button zapisz_ui;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\DodajUczniaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button anuluj_ui;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Szkola_pele;component/dodajuczniawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DodajUczniaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.imie_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.nazwisko_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.wiek_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.inteligencja_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.sila_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.zwinnosc_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.charyzma_ui = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.zapisz_ui = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\DodajUczniaWindow.xaml"
            this.zapisz_ui.Click += new System.Windows.RoutedEventHandler(this.zapiszClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.anuluj_ui = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\DodajUczniaWindow.xaml"
            this.anuluj_ui.Click += new System.Windows.RoutedEventHandler(this.anulujClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
