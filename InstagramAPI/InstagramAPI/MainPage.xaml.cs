using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using InstagramAPI.Resources;
using MyInstagramAPI;

namespace InstagramAPI
{
    public partial class MainPage : PhoneApplicationPage
    {
        Instagram _instagram;

        public MainPage()
        {
            InitializeComponent();

            _instagram = new Instagram("e1548c2c94944f59b59af937f04fce22", "http://www.idonthave.com");
        }

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            _instagram.Concect();
        }

        private void PegaFotoUsuario(string codUsuario)
        { }
    }
}