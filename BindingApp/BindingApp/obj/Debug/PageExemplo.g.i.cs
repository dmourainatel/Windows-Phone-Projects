﻿#pragma checksum "C:\Users\aluno\Desktop\Curso WP\Windows Phone Avançado II\Apps\BindingApp\BindingApp\PageExemplo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13C4B67816FA15352B51C57DCFA8A41D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BindingApp {
    
    
    public partial class PageExemplo : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid gridInformacoes;
        
        internal System.Windows.Controls.TextBlock txbId;
        
        internal System.Windows.Controls.TextBlock txbModelo;
        
        internal System.Windows.Controls.TextBlock txbMarca;
        
        internal System.Windows.Controls.TextBlock txbPreco;
        
        internal System.Windows.Controls.Button btnCarregaBinding;
        
        internal System.Windows.Controls.Button btnAlteraObjetoCarro;
        
        internal System.Windows.Controls.Button btnAlteraTextBlockCarro;
        
        internal System.Windows.Controls.Button btnInfoObjetoCarro;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/BindingApp;component/PageExemplo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.gridInformacoes = ((System.Windows.Controls.Grid)(this.FindName("gridInformacoes")));
            this.txbId = ((System.Windows.Controls.TextBlock)(this.FindName("txbId")));
            this.txbModelo = ((System.Windows.Controls.TextBlock)(this.FindName("txbModelo")));
            this.txbMarca = ((System.Windows.Controls.TextBlock)(this.FindName("txbMarca")));
            this.txbPreco = ((System.Windows.Controls.TextBlock)(this.FindName("txbPreco")));
            this.btnCarregaBinding = ((System.Windows.Controls.Button)(this.FindName("btnCarregaBinding")));
            this.btnAlteraObjetoCarro = ((System.Windows.Controls.Button)(this.FindName("btnAlteraObjetoCarro")));
            this.btnAlteraTextBlockCarro = ((System.Windows.Controls.Button)(this.FindName("btnAlteraTextBlockCarro")));
            this.btnInfoObjetoCarro = ((System.Windows.Controls.Button)(this.FindName("btnInfoObjetoCarro")));
        }
    }
}

