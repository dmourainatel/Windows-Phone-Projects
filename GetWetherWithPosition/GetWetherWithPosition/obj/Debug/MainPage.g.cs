﻿#pragma checksum "C:\Users\DiegoMoura\OneDrive\WindowsPhone\GetWetherWithPosition\GetWetherWithPosition\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45296E0BE6C8E0F08CFF79EBC7982885"
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


namespace GetWetherWithPosition {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtBlock_ReceiveWether;
        
        internal System.Windows.Controls.TextBlock txtBlock_ReceivePosition;
        
        internal System.Windows.Controls.TextBlock txtBlock_1;
        
        internal System.Windows.Controls.TextBlock txtBlock_2;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/GetWetherWithPosition;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtBlock_ReceiveWether = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlock_ReceiveWether")));
            this.txtBlock_ReceivePosition = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlock_ReceivePosition")));
            this.txtBlock_1 = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlock_1")));
            this.txtBlock_2 = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlock_2")));
        }
    }
}
