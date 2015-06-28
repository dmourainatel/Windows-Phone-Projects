using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GettingLocation.Resources;
using System.Net.Http;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;

namespace GettingLocation
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void btnGetLatAndLong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://api.openweathermap.org/data/2.5/weather?q=santa-rita-do-sapucai,mg";
                
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync(url);

                string result = await response.Content.ReadAsStringAsync();

                RootObject objeto = JsonConvert.DeserializeObject<RootObject>(result);

                double realTemperature = ConvertToCelsius(objeto.main.temp);
                MessageBox.Show(realTemperature.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }

        private double ConvertToCelsius(double k)
        {
            double c = k - 273.15;
            return c;
        }

    }
}