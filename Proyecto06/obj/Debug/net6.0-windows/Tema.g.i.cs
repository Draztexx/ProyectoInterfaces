﻿#pragma checksum "..\..\..\Tema.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E3C765A538C0EA5691C61AC6BA90EF7B29A8C0A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto05;
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


namespace Proyecto05 {
    
    
    /// <summary>
    /// Tema
    /// </summary>
    public partial class Tema : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBtitulo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Contenido;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MIN;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SEC;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser MiNavegadorWeb;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTVolver;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Tema.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTActividades;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto05;component/tema.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Tema.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TBtitulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Contenido = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MIN = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SEC = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.MiNavegadorWeb = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 6:
            this.BTVolver = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Tema.xaml"
            this.BTVolver.Click += new System.Windows.RoutedEventHandler(this.BTVolver_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BTActividades = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Tema.xaml"
            this.BTActividades.Click += new System.Windows.RoutedEventHandler(this.BTActividades_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

