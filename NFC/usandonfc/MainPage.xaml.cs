using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using usandonfc.Resources;
using Windows.Networking.Proximity;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.IO.IsolatedStorage;





namespace usandonfc
{
    public partial class MainPage : PhoneApplicationPage
    {
        List<Check> listaCheck = new List<Check>();

        int cont;
        private ProximityDevice proximityDevice;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (App._isoStorage.Count == 0) { 
                App._isoStorage.Add("lista", new List<Check>());
                App._isoStorage.Add("cont", 1);
            }

            listaCheck = (List<Check>) App._isoStorage["lista"];

            cont = (int) App._isoStorage["cont"];
            proximityDevice = Windows.Networking.Proximity.ProximityDevice.GetDefault();

            if (proximityDevice != null)
            {
                proximityDevice.DeviceArrived += ProximityDeviceArrived;
                proximityDevice.DeviceDeparted += ProximityDeviceDeparted;

            }




            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }



        private void ProximityDeviceArrived(ProximityDevice sender)
        {
            cont = cont + 1;
            App._isoStorage["cont"] = cont;

            if (cont % 2 == 0)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBlock.Text = "CHECK-IN!";
                    DataBlock.Text = DateTime.Now.ToString();


                    listaCheck.Add(new Check { data = DateTime.Now, tipoCheck = "Check-In" });


                    App._isoStorage["lista"] = listaCheck;
                    App._isoStorage.Save();

                    //HourBlock.Text = Data.Date.ToString();
                    //Data.TimeOfDay.ToString();

                });
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBlock.Text = "CHECK-OUT!";
                    DataBlock.Text = DateTime.Now.ToString();
                    //HourBlock.Text = Data.Kind.ToString();


                    listaCheck.Add(new Check { data = DateTime.Now, tipoCheck = "Check-Out" });

                    App._isoStorage["lista"] = listaCheck;
                    App._isoStorage.Save();

                });
            }
        }


        /*protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            App._isoStorage["lista"] = listaCheck;

            
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App._isoStorage.Contains("lista_teste"))
            {
                listaCheck = (List<Check>)App._isoStorage["lista_teste"];
            }
            else
            {
                App._isoStorage["lista"] = listaCheck;

            }
            
        }*/



        private void ProximityDeviceDeparted(ProximityDevice sender)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
           {
               //MessageBlock.Text = "Dispositivo Desconectado";
               //DataBlock.Text = "";
               //HourBlock.Text = "";
           });
        }


        private void btLista_Click(object sender, RoutedEventArgs e)
        {
            string historico = "";

            List<Check> listar = new List<Check>();

            listar = (List<Check>) App._isoStorage["lista"];

            for (int i = 0; i < listar.Count; i++)
            {
                Check check = (Check)listar[i];

                historico += "\nTipo: "+check.tipoCheck+" Data: "+check.data ;
            }

            MessageBox.Show(historico);
        }

private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
{
    NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.RelativeOrAbsolute));
    // Sobre
}

private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
{
    NavigationService.Navigate(new Uri("/Historico.xaml", UriKind.RelativeOrAbsolute));
    //Go to Historico
}
    }
}

    