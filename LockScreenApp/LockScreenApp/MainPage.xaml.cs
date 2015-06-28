using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LockScreenApp.Resources;
using Windows.Phone.System.UserProfile;

namespace LockScreenApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAlteraImage_Click(object sender, RoutedEventArgs e)
        {
            //Alterar a imagem da LockScreen
            try
            {     
                Uri uri = LockScreen.GetImageUri();
                MessageBox.Show("O caminho da imagem eh.:" + uri.AbsolutePath);
                //Verifico se o meu app eh o responsavel pela lockscreen
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            if (!LockScreenManager.IsProvidedByCurrentApplication)
            {
                // pergunta ao usuario se deseja trocar as imagens
                await LockScreenManager.RequestAccessAsync();
            }

            if(LockScreenManager.IsProvidedByCurrentApplication)
            {   
                string schema = "ms-apx://";
                Uri uri = new Uri(schema+"/Images/img.jpg",UriKind.RelativeOrAbsolute);           
                LockScreen.SetImageUri(uri);
            }
           
        }

        private async void btnAlteraIcone_Click(object sender, RoutedEventArgs e)
        {
            //Chama o launcher para definir o app como background
           await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
          
           //A classe shellTile guarda todos os tiles(icones) do meu app
           // o icone definido para na LockScreen Sempre eh o primeiro 
           // vou altera-lo com um FlipTileDate
           ShellTile.ActiveTiles.First().Update(
               new FlipTileData() 
               { 
                Count = 212,
                WideBackContent = "bla bla bla",         
               });
        }
    }
}