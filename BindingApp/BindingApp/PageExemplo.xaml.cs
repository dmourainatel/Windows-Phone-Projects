using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BindingApp
{
    public partial class PageExemplo : PhoneApplicationPage
    {
        Carro _carro;

        public PageExemplo()
        {
            InitializeComponent();

            _carro = new Carro()
            {
                Id = 0,
                Marca = "Chevrolet",
                Modelo = "Camaro",
                Preco = 20000,
                VelocidadeMaxima = 220
            };
        }

        private void btnCarregaBinding_Click(object sender, RoutedEventArgs e)
        {  
            // É atravez do dataContext que se faz o Binding, logo o DataContext vai receber
            // todos os valores das propriedades de carro, e como carro tem as propriedades buscadas no Binding,
            // o campo text receberá as infos de carro
            gridInformacoes.DataContext = _carro;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _carro.Marca = "ALTEROU";
            _carro.Modelo = "ALTEROU";
            _carro.Preco = 30000;
            _carro.Id = 10;
        }

        private void btnAlteraTextBlockCarro_Click(object sender, RoutedEventArgs e)
        {
            txbModelo.Text = "TEXT BLOCK CARRO";
            txbPreco.Text = "123";
            txbMarca.Text = "TEXT BLOCK CARRO";
            txbId.Text = "123";
        }

        private void btnInfoObjetoCarro_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modelo: "+_carro.Modelo +
                            "Marca: "+_carro.Marca +
                            "Id: "+_carro.Id+
                            "Preco: "+_carro.Preco.ToString());
        }
    }
}