﻿#pragma checksum "C:\Users\diegou\Desktop\MyApps\Darts\Darts\IncomingCallPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "00C7EF46C0B338EE279F5EBA2F1217F0"
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


namespace Darts {
    
    
    public partial class IncomingCallPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.StackPanel WaitingForCallPanel;
        
        internal System.Windows.Controls.TextBlock CountdownTextBlock;
        
        internal System.Windows.Controls.TextBlock TapToHideTextBlock;
        
        internal System.Windows.Controls.StackPanel IncomingCallPanel;
        
        internal System.Windows.Controls.TextBlock CurrentTimeTextBlock;
        
        internal System.Windows.Controls.TextBlock CarrierTextBlock;
        
        internal System.Windows.Controls.TextBlock PhoneNumberTextBlock;
        
        internal System.Windows.Controls.Button btnIgnore;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Darts;component/IncomingCallPage.xaml", System.UriKind.Relative));
            this.WaitingForCallPanel = ((System.Windows.Controls.StackPanel)(this.FindName("WaitingForCallPanel")));
            this.CountdownTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CountdownTextBlock")));
            this.TapToHideTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("TapToHideTextBlock")));
            this.IncomingCallPanel = ((System.Windows.Controls.StackPanel)(this.FindName("IncomingCallPanel")));
            this.CurrentTimeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CurrentTimeTextBlock")));
            this.CarrierTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CarrierTextBlock")));
            this.PhoneNumberTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("PhoneNumberTextBlock")));
            this.btnIgnore = ((System.Windows.Controls.Button)(this.FindName("btnIgnore")));
        }
    }
}

