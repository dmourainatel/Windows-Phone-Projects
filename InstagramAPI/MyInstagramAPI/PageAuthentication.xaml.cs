using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MyInstagramAPI
{
    public partial class PageAuthentication : PhoneApplicationPage
    {
        public string _url;
        
        public PageAuthentication()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(!NavigationContext.QueryString.TryGetValue("url",out _url))
            {
                NavigationService.GoBack();
            }

            _url = _url.Replace("redirect_uri=", "&redirect_uri=");
            _url = _url.Replace("response_type=", "&response_type=");
            base.OnNavigatedTo(e); 
        }

        private void webBrowser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            //Fecho o browser caso a navegação falhar
            NavigationService.GoBack();
        }

        private void webBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            MessageBox.Show(e.Uri.ToString());
        }

        private void webBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            string response = e.Uri.ToString();
            string tagInicial = "#access_token";
            if (e.Uri.ToString().Contains(tagInicial))
            {             
                response = response.Substring(response.LastIndexOf(tagInicial) + tagInicial.Length);
                
                InstagramHelper.RecebeuToken(response);
                webBrowser.Navigated -= webBrowser_Navigated;
                NavigationService.GoBack();
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(_url, UriKind.Absolute);
            webBrowser.Navigate(uri);
        }


    }
}