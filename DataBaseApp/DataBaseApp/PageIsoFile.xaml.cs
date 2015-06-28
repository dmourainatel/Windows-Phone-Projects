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
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Resources;

namespace DataBaseApp
{
    public partial class PageIsoFile : PhoneApplicationPage
    {
        IsolatedStorageFile _fileStorage;
        int count = 0;

        public PageIsoFile()
        {
            InitializeComponent();

            _fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           string[] diretorios = _fileStorage.GetDirectoryNames();
                
           string strDiretorios = "";

           foreach (string dir in diretorios)
           {
               strDiretorios += dir + "\n";
           }
           MessageBox.Show(strDiretorios);
        }
        
        //Trabalhando com diretorios
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _fileStorage.CreateDirectory("Pasta "+count);
            count++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_fileStorage.DirectoryExists("Pasta " + count))
            {
                _fileStorage.DeleteDirectory("Pasta " + count);
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _fileStorage.CreateDirectory("/Pasta 0\\Subpasta " + count);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BitmapImage btm = new BitmapImage();
            btm.ImageOpened += btm_ImageOpened;
            btm.CreateOptions = BitmapCreateOptions.BackgroundCreation;
            btm.UriSource = new Uri("/Logo.png",UriKind.RelativeOrAbsolute);

        }

        void btm_ImageOpened(object sender, RoutedEventArgs e)
        {
            BitmapImage btm = (BitmapImage)sender;
            btm.CreateOptions = BitmapCreateOptions.DelayCreation;
            WriteableBitmap wb = new WriteableBitmap(btm);

            //Salvar em uma pasta no meu ISO Storage
            if(!_fileStorage.DirectoryExists("Arquivos\\Pasta Imagem"))
            {
                _fileStorage.CreateDirectory("Arquivos\\Pasta Imagem");
            }

            IsolatedStorageFileStream outFile = _fileStorage.CreateFile("Arquivos\\Pasta Imagem\\Logo.png");
            Extensions.SaveJpeg(wb,outFile,wb.PixelWidth,wb.PixelHeight,0,100);
           
            outFile.Close();
            //_fileStorage.CreateFile("/Logo.png");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Pega a stream do arquivo XML 
            StreamResourceInfo stream = Application.GetResourceStream(new Uri("XML.xml", UriKind.RelativeOrAbsolute));
            StreamReader sr = new StreamReader(stream.Stream);

            string texto = sr.ReadToEnd();
            //Pega o array de bytes da minha string
            byte[] textoBytes = System.Text.Encoding.UTF8.GetBytes(texto);

            if (!_fileStorage.DirectoryExists("Arquivos\\Pasta Texto"))
                _fileStorage.CreateDirectory("Arquivos\\Pasta Texto");

            IsolatedStorageFileStream outFile = _fileStorage.CreateFile("Arquivos\\Pasta Texto\\MeuXML.xml");
            outFile.Write(textoBytes,0,textoBytes.Length);
        }
    }
}