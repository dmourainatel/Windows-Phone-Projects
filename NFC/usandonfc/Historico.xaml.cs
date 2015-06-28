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

namespace usandonfc
{
    public partial class Historico : PhoneApplicationPage
    {

        
        TimeSpan tempoTotal;

        public Historico()
        {
            InitializeComponent();

            lsbHistorico.ItemsSource = (List<Check>) App._isoStorage["lista"];

            List<Check> lista = (List<Check>) App._isoStorage["lista"];

            int contador;

            if (lista.Count % 2 == 0)
                contador = lista.Count;
            else
                contador = lista.Count - 1;


            for (int i = 0; i < contador; i+=2)
            {
                Check checkIn = (Check)lista[i];
                Check checkOut = (Check)lista[i + 1];

                tempoTotal += checkOut.data.Subtract(checkIn.data);

            }

            total.Text = tempoTotal.Hours+" Horas "+tempoTotal.Minutes+" Minutos "+tempoTotal.Seconds+" Segundos";

        }
    }
}