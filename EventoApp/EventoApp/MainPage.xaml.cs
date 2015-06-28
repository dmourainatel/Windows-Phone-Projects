using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using EventoApp.Resources;

namespace EventoApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        delegate void TeclaAcionada(DateTime dt);
        //Um evento sempre pede um Delegate, o evento Tecla_R_Acionada aponta para uma 
        //delegate TeclaAcionada, do tipo void que passa um DateTime
        event TeclaAcionada Tecla_R_Acionada;

        public MainPage()
        {
            InitializeComponent();
            //Tecla_R_Acionada += AcionouTelcaR;
        }


        private void txb1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.R)
            {
                if(Tecla_R_Acionada != null)
                    Tecla_R_Acionada(DateTime.Now);
                //AcionouTelcaR(DateTime.Now);
            }

            //EXEMPLO: O evento Click é composto por um delegate do tipo RoutedEventHandler
            // que é do tipo void e recebe parametros como (object sender, RoutedEventArgs e)
            Button bnt = new Button();
            bnt.Click += bnt_Click;
        }
        //Void, com os parametros definido no delegate
        void bnt_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AcionouTelcaR(DateTime dt)
        {
            MessageBox.Show(dt.ToLongTimeString());
        }

        private void bntAltera_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Exemplo.xaml",UriKind.RelativeOrAbsolute));
        }

    }
}