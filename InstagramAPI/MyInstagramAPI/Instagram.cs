using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyInstagramAPI
{
    public class Instagram
    {
        public enum ResponseType { Code, Token };
        public string token { get; set; }

        private string _clientId;
        private string _redirectUrl;

        Dictionary<string, string> _urls;
        InstagramHelper _instagramHelper;

        

        public Instagram(string clientId, string redirectUrl)
        {
            _clientId = clientId;
            _redirectUrl = redirectUrl;

            //Carrego todas as urls
            _urls = new Dictionary<string, string>();
            
            _urls.Add("authentication", string.Format( // url de authenticacao
                @"https://api.instagram.com/oauth/authorize/?client_id={0}redirect_uri={1}response_type={2}",
                _clientId,
                _redirectUrl,
                ResponseType.Token.ToString().ToLower()));
            
            _instagramHelper = new InstagramHelper();
            InstagramHelper.ReceivedToken += InstagramHelper_ReceivedToken;
        }
        
        public void Concect()
        {
            _instagramHelper.GetToken(_urls["authentication"]);
        }

        void InstagramHelper_ReceivedToken(string token)
        {
            
        }
    }

    internal class InstagramHelper
    {
        public delegate void ReceivedTokenHandler(string token);
        public static event ReceivedTokenHandler ReceivedToken;
        public static string Token;

        internal static void RecebeuToken(string token)
        {
            if (ReceivedToken != null)
                ReceivedToken(token);
        }

        public void GetToken(string url)
        {
            Uri uri = new Uri("/MyInstagramAPI;component/PageAuthentication.xaml?url=" + url,
                UriKind.Relative);
            (Application.Current.RootVisual as Frame).Navigate(uri);
        }
    }
}
