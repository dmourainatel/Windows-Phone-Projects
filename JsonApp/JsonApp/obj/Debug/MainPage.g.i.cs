﻿#pragma checksum "C:\Users\DiegoMoura\Desktop\C#\Curso WP\Windows Phone Avançado II\Apps\JsonApp\JsonApp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "938073FA0DE1333BDA6BB33830796578"
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


namespace JsonApp {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnDeserializa;
        
        internal System.Windows.Controls.Button btnSerializa;
        
        internal System.Windows.Controls.ListBox lsbAlbuns;
        
        internal System.Windows.Controls.Button btnDeserializaHttpClient;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/JsonApp;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnDeserializa = ((System.Windows.Controls.Button)(this.FindName("btnDeserializa")));
            this.btnSerializa = ((System.Windows.Controls.Button)(this.FindName("btnSerializa")));
            this.lsbAlbuns = ((System.Windows.Controls.ListBox)(this.FindName("lsbAlbuns")));
            this.btnDeserializaHttpClient = ((System.Windows.Controls.Button)(this.FindName("btnDeserializaHttpClient")));
        }
    }
}

