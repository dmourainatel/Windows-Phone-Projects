using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeuEnum.Resources;

namespace MeuEnum
{
    enum DiasDaSemana {  Segunda,Terca,Quarta,Quinta,Sexta,Sabado,Domingo}
    enum Meses { Janeiro = 1 ,Fevereiro = 2 , Marco = 3  , Abril = 4 , Maio = 5 , Junho = 6, Julho = 7 , Agosto= 8, Setembro , Outrubro, Novembro,Dezembro}


    public partial class MainPage : PhoneApplicationPage
    {
        //Meses _mes;
        Meses _mes;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button content = sender as Button;
     
            if (content.Content.Equals("Janeiro"))
            {
                _mes = Meses.Janeiro;
            }

            if (content.Content.Equals("Fevereiro"))
            {
                _mes = Meses.Fevereiro;
            }

            if (content.Content.Equals("Marco"))
            {
                _mes = Meses.Marco;
            }

            if (content.Content.Equals("Abril"))
            {
                _mes = Meses.Abril;
            }

            if (content.Content.Equals("Maio"))
            {
                _mes = Meses.Maio;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int txt = (int)_mes;
            MessageBox.Show(_mes.ToString());
            MessageBox.Show(txt.ToString());
            // digita -se swit TAB + TAB coloca-se o membro operador e aperta-se TAB+ENTER
            //switch (_mes)
            //{
            //    case Meses.Janeiro:
            //        break;
            //    case Meses.Fevereiro:
            //        break;
            //    case Meses.Marco:
            //        break;
            //    case Meses.Abril:
            //        break;
            //    case Meses.Maio:
            //        break;
            //    case Meses.Junho:
            //        break;
            //    case Meses.Julho:
            //        break;
            //    case Meses.Agosto:
            //        break;
            //    case Meses.Setembro:
            //        break;
            //    case Meses.Outrubro:
            //        break;
            //    case Meses.Novembro:
            //        break;
            //    case Meses.Dezembro:
            //        break;
            //    default:
            //        break;
            //}   
        }

       

    }
}