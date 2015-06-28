using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BindingApp.Resources;

namespace BindingApp
{
    public partial class MainPage : PhoneApplicationPage
    {
    
        public MainPage()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageExemplo.xaml",UriKind.RelativeOrAbsolute));
        }    
    }
}