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
using System.Text.RegularExpressions;

namespace ConsumindoWebServiceGEOIP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "http://www.myweather2.com/developer/forecast.ashx?uac=5ShkfaAgMs&output=xml&query=SW1";
            
            //string input = @"\s*";


            //Regex rgx = new Regex(input, RegexOptions.RightToLeft);
            //MatchCollection mach = rgx.Matches(url);

           
            try
            {
                WebClient client = new WebClient();

                client.DownloadStringCompleted += client_DownloadStringCompleted;

                Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);

                client.DownloadStringAsync(uri);
            }
            catch (Exception)
            {
                throw new Exception("Erro durante a conexao com o webservice");
            }

            
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string str = e.Result;
            resposta.Text = str;
            MessageBox.Show(str);
        }
    }
}