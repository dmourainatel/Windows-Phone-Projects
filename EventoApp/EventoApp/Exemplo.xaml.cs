using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace EventoApp
{
    public partial class Exemplo : PhoneApplicationPage
    {
        Carro _meuCarro;

        public Exemplo()
        {
            InitializeComponent();

            _meuCarro = new Carro() { 
                Id = 0,
                Marca = "Volks",
                Modelo = "Gol",
                Nome = "Diego",
                VelocidadeMaxima = 220
            };

            _meuCarro.AlteracaoOcorreu += _meuCarro_AlteracaoOcorreu;
        }

        void _meuCarro_AlteracaoOcorreu(string propriedade)
        {
            MessageBox.Show("A propriedade "+ propriedade + " foi alterada!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _meuCarro.Nome +=" Moura";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _meuCarro.VelocidadeMaxima += 10; 
        }
    }
}