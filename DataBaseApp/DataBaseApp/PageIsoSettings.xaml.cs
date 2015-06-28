using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace DataBaseApp
{
    public partial class PageIsoSettings : PhoneApplicationPage
    {
        //Restrição da IsolatedStorageSettings:
        // Nao permite salvar objetos do tipo: WritableBitmap, BitmapImage, objetos de imagem, ou objetos de UI ex: Botao.
        IsolatedStorageSettings _isoSettings;

        public PageIsoSettings()
        {
            InitializeComponent();

            _isoSettings = IsolatedStorageSettings.ApplicationSettings;           
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            //Verifico se a chave "nome" existe no ISOSettings
            if (_isoSettings.Contains("keyName"))
                _isoSettings["keyName"] = txbNome.Text; // Se ja existir, atribui valor
            else
                _isoSettings.Add("keyName",txbNome.Text); // Se nao existir cria

            _isoSettings.Save();
        }

        private void btnCarrega_Click(object sender, RoutedEventArgs e)
        {
            string elementos = "";
            for (int i = 0; i < _isoSettings.Count; i++)
            {
                elementos += string.Format("{0} , {1}\n",_isoSettings.ElementAt(i).Key,_isoSettings.ElementAt(i).Value.ToString());
            }

            MessageBox.Show(elementos);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Limpa todo o conteudo do meu ISOSettings
            _isoSettings.Clear();
        }
    }
}