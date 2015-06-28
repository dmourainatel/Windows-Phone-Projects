using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using JsonApp.Resources;
using Newtonsoft.Json;
using System.Net.Http;

namespace JsonApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDeserializa_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            Uri uri = new Uri("http://www.vagalume.com.br/u2/index.js",UriKind.RelativeOrAbsolute);
            webClient.DownloadStringAsync(uri);
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if(e.Result == null || e.Error != null)
            {
                MessageBox.Show("Erro ao trazer o JSON");
                return;
            }

            RootObject artista = JsonConvert.DeserializeObject<RootObject>(e.Result);
            // O Intens.Source é o dataContext da lista, no entanto ele replica o resultado,
            // Uma vez que o dataContext pega resultado apenas para um obj.
            lsbAlbuns.ItemsSource = artista.artist.albums.item;
           
        }

        private void btnSerializa_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            
            user.Nome = "Diego";
            user.EhFeliz = true;
            user.Email = "sadfsa@afsaf";
            user.DtCriacaoConta = new DateTime(1982,5,3);
            user.DtNascimento = new DateTime(1233,12,2);
            
            //Serializando um objeto em um Json
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
        }

        private async void btnDeserializaHttpClient_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://www.vagalume.com.br/u2/index.js";

            HttpResponseMessage resultaddAsync = await client.GetAsync(url);
            string result = await resultaddAsync.Content.ReadAsStringAsync();

            RootObject art = JsonConvert.DeserializeObject<RootObject>(result);
        }


    }
}