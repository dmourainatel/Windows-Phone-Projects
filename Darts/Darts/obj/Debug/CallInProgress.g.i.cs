﻿#pragma checksum "C:\Users\diegou\Desktop\MyApps\Darts\Darts\CallInProgress.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D75A720CB3BA626BA46D580B337D9C0C"
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
    
    
    public partial class CallInProgress : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock CurrentTextBlock;
        
        internal System.Windows.Controls.TextBlock CarrierTextBlock;
        
        internal System.Windows.Controls.TextBlock CallDurationTextBlock;
        
        internal System.Windows.Controls.TextBlock PhoneNumberTextBlock;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Darts;component/CallInProgress.xaml", System.UriKind.Relative));
            this.CurrentTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CurrentTextBlock")));
            this.CarrierTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CarrierTextBlock")));
            this.CallDurationTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("CallDurationTextBlock")));
            this.PhoneNumberTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("PhoneNumberTextBlock")));
        }
    }
}

