﻿#pragma checksum "..\..\..\GUI\AkcijaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8BC2118C7ECC126A66FB15DECDFCB091"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF07_16_GUI.GUI;
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


namespace POP_SF07_16_GUI.GUI {
    
    
    /// <summary>
    /// AkcijaWindow
    /// </summary>
    public partial class AkcijaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal POP_SF07_16_GUI.GUI.AkcijaWindow Akcija;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDatumPocetka;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatumPocetka;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDatumZavrsetka;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatumZavrsetka;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbPopust;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPopust;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btPotvrdi;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\GUI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOtkazi;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF07-16-GUI;component/gui/akcijawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\AkcijaWindow.xaml"
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
            this.Akcija = ((POP_SF07_16_GUI.GUI.AkcijaWindow)(target));
            return;
            case 2:
            this.lbDatumPocetka = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dpDatumPocetka = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.lbDatumZavrsetka = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.dpDatumZavrsetka = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.lbPopust = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.tbPopust = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btPotvrdi = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\GUI\AkcijaWindow.xaml"
            this.btPotvrdi.Click += new System.Windows.RoutedEventHandler(this.btPotvrdi_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\GUI\AkcijaWindow.xaml"
            this.btOtkazi.Click += new System.Windows.RoutedEventHandler(this.btOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

