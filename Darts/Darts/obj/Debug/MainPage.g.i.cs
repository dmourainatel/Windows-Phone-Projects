﻿#pragma checksum "C:\Users\diegou\Desktop\MyApps\Darts\Darts\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC19908BD68DA294020576B9997ADC62"
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Button btnWaitForCall;
        
        internal Microsoft.Phone.Controls.TimePicker TimePicker;
        
        internal System.Windows.Controls.TextBox phoneNumberTextBox;
        
        internal System.Windows.Controls.TextBox carrierTextBox;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Darts;component/MainPage.xaml", System.UriKind.Relative));
            this.btnWaitForCall = ((System.Windows.Controls.Button)(this.FindName("btnWaitForCall")));
            this.TimePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("TimePicker")));
            this.phoneNumberTextBox = ((System.Windows.Controls.TextBox)(this.FindName("phoneNumberTextBox")));
            this.carrierTextBox = ((System.Windows.Controls.TextBox)(this.FindName("carrierTextBox")));
        }
    }
}

