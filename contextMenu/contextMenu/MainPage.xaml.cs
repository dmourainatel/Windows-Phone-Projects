using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace contextMenu
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Watch_Click(object sender, RoutedEventArgs e)
        {
            txbTeste.Text = "clikWatch";
           
        }
        private void Share_Click(object sender, RoutedEventArgs e)
        {
            txbTeste.Text = "clikShare";
            
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            txbTeste.Text = "clikBuy";

        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Context");
            //Microsoft.Phone.Controls.Primitives.MenuBase contexMenu = new ContextMenu();
           
           
            //ContextMenu ctx = new ContextMenu();
            //DependencyObject dep = ctx;
            //ContextMenu obj =  ContextMenuService.GetContextMenu(dep);

            
        
        }
    }
}