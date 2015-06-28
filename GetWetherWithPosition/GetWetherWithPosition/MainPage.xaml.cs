using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GetWetherWithPosition.Resources;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.Devices.Geolocation;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;

namespace GetWetherWithPosition
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpClient client;
        UserInfo user = new UserInfo();
        string latitude = "";
        string longitude = ""; 

        //Lat aflenas = -21.421922
        //Long alfenas = -45.9675292

        

        public MainPage()
        {
            InitializeComponent();
            GetLocation();
        }

        //Pega as informações de tempo a partir de uma cidade e pais
        #region GetWether
        private async System.Threading.Tasks.Task getWether()
        {
            if (user.Cidade.Contains(" "))
            {
                user.Cidade = user.Cidade.Replace(" ", "-");
            }

            if (user.Pais.Contains(" "))
            {
                user.Pais = user.Pais.Replace(" ", "-");
            }


            string _url = @"http://api.openweathermap.org/data/2.5/weather?q=" + user.Cidade + "," + user.Pais;

            if (user.Cidade.Contains("-"))
            {
                user.Cidade = user.Cidade.Replace("-", " ");
            }

            if (user.Pais.Contains("-"))
            {
                user.Pais = user.Pais.Replace("-", " ");
            }

            try
            {
                client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync(_url);
                string resultado = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(resultado))
                {
                    RootObject root = await JsonConvert.DeserializeObjectAsync<RootObject>(resultado);

                    if (root != null)
                        user.Temperature = (root.main.temp - 273.15).ToString();    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            ContentPanel.DataContext = user;
        }
        #endregion

        //pega as informações de localização apartir das coordenadas geográficas de latitudo e longitude
        #region getLocation
        private async System.Threading.Tasks.Task GetLocation()
        {

            //await getLatitudeAndLongitude();

            latitude = "-21.421922";
            longitude = "-45.9675292";
            string _url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&sensor=true";

            HttpClient clientGetPosition = new HttpClient();
            HttpResponseMessage responseGetPosition = await clientGetPosition.GetAsync(_url);

            string result = await responseGetPosition.Content.ReadAsStringAsync();

            JObject parseJson = JObject.Parse(result);
            var getJsonres = parseJson["results"][1];
            var getJsonrespAdress = getJsonres["formatted_address"];
            string formattedAdress = getJsonrespAdress.ToString();

            string[] arrayStrings = formattedAdress.Split(',','-');

            user.Cidade = arrayStrings[1];
            user.Bairro = arrayStrings[0];
            user.Pais = arrayStrings[3];
            user.Estado = arrayStrings[2];

            await getWether();
        }

        private async System.Threading.Tasks.Task getLatitudeAndLongitude()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 10000;

            try
            {

                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                maximumAge: TimeSpan.FromMinutes(5),
                timeout: TimeSpan.FromSeconds(10)
                );

                latitude = geoposition.Coordinate.Latitude.ToString("0.0000000000000");
                longitude = geoposition.Coordinate.Longitude.ToString("0.0000000000000");

            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    MessageBox.Show("location  is disabled in phone settings. " + ex.Message);
                }
            }
        }
        #endregion
    
    }
}