﻿#pragma checksum "C:\Users\DiegoMoura\Desktop\C#\Curso WP\Windows Phone Avançado II\Apps\Colecoes\Colecoes\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F012E63E3E144FC07178A9931229A77B"
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


namespace Colecoes {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button bntList;
        
        internal System.Windows.Controls.Button bntDictionary;
        
        internal System.Windows.Controls.Button bntQueue;
        
        internal System.Windows.Controls.Button bntObservable;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Colecoes;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.bntList = ((System.Windows.Controls.Button)(this.FindName("bntList")));
            this.bntDictionary = ((System.Windows.Controls.Button)(this.FindName("bntDictionary")));
            this.bntQueue = ((System.Windows.Controls.Button)(this.FindName("bntQueue")));
            this.bntObservable = ((System.Windows.Controls.Button)(this.FindName("bntObservable")));
        }
    }
}

