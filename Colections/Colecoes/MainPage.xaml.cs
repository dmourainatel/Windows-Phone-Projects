using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Colecoes.Resources;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Colecoes
{
    //Implementa a interface
    public class SortCarrosByIdDescending : IComparer<Carro>
    {
        public int Compare (Carro x, Carro y)
        {
            if(x.Id> y.Id)
                return -1;
            else if(x.Id == y.Id)
                return 0;
            else
                return 1;
        }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        List<Carro> listCar = new List<Carro>();

        public MainPage()
        {
            InitializeComponent();

            #region Creation Cars

            listCar.Add(new Carro(1, Marcas.Audi, "City", "Preto", 2001, 14500));
            listCar.Add(new Carro(2, Marcas.BMW, "Sport", "Branco", 2014, 54500));
            listCar.Add(new Carro(3, Marcas.Chevrolet, "Sedam", "Marrom", 2007, 2000));
            listCar.Add(new Carro(4, Marcas.Ferrari, "Sedam", "Vermelha", 2014, 750000));
            listCar.Add(new Carro(5, Marcas.Fiat, "Uno", "Azul", 2014, 7000));
            listCar.Add(new Carro(6, Marcas.Forde, "Fiesta", "Laranja", 2014, 77000));
            #endregion 
        }

        private void bntList_Click(object sender, RoutedEventArgs e)
        {
           

            #region MessegeBox
            //string value = "";

            //for (int i = 0; i < listCar.Count; i++)
            //{
            //    value += listCar[i].Id.ToString() + " " + listCar[i].Marca.ToString() + " " +
            //        listCar[i].Modelo + " " + listCar[i].Cor + " " + listCar[i].Ano.ToString() + " "
            //        + listCar[i].Preco.ToString();
            //}
            //MessageBox.Show(value);
            #endregion
            
            foreach (Carro item in listCar)
            {
                Debug.WriteLine(item.Marca);
            }

            //Array de carro, que tem um tamanho defido por [listCar.Count+10]
            Carro[] arrayCarros = new Carro[listCar.Count+10];
            listCar.CopyTo(3,arrayCarros,2,1);

            //Pega a primeira ocorrencia da condialçao especificada
            Carro carroBarato = listCar.Find(carroBuscado => carroBuscado.Preco < 5000);

            // Pega a ultima ocorrencia da condiação especificada
            Carro carroUltimaOcorrencia = listCar.FindLast(ultimaOcorrencia => ultimaOcorrencia.Preco<100000);

            //Pega a lista de ocorrencia da condiação espeficicada
            List<Carro> lista = listCar.FindAll(buscaCarros => buscaCarros.Preco>15000);

            //Pega o index do carro da condição especificada
            int indexReturn = listCar.FindIndex(carro => carro.Marca == Marcas.Ferrari);

            //Insere na minha lista a partir do elemento 2 um novo carro, cujo ID = 9
            listCar.Insert(2,new Carro(9,Marcas.Volkswagen,"Gol","Vermelho",2014,150000));

            // Retorna o carro da lista na quarta posição
            Carro carroNaPosicao4 = listCar.ElementAt(4);

            //Retorna o numero de carros removidos da lista que atendam a seguinte expressão lambda
            int itensRemovidos = listCar.RemoveAll(remove => remove.Marca == Marcas.Ferrari);

            //Cria uma instancia da classe que herda a interface IComparer para a implementação 
            // do método sort
            SortCarrosByIdDescending sortDescending = new SortCarrosByIdDescending();
            listCar.Sort(sortDescending);

            for (int i = 0; i < listCar.Count; i++)
            {
                Debug.WriteLine(listCar.ElementAt(i).Id);
            }

            listCar.Sort();
            
           
        }

        private void bntDictionary_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Carro> dictionaryCarros = new Dictionary<string, Carro>();
     

            //Preenche Dictionary com os valores da lista
            for (int i = 0; i < listCar.Count; i++)
            {
                dictionaryCarros.Add(""+i,listCar.ElementAt(i));
            }

            Carro carroParaTeste = dictionaryCarros.Values.ElementAt(1);

            //Busca linda por linha os elementos do dicionario, Key e Value
            foreach (KeyValuePair<string,Carro> linha in dictionaryCarros)
            {
                Debug.WriteLine("{0}, {1}", linha.Key, linha.Value.Marca);
            }

            // Busca os carros do dictionary 
            foreach (Carro item in dictionaryCarros.Values)
            {
                Debug.WriteLine(item.Marca);
            }

            bool valueBool = dictionaryCarros.ContainsKey("4");

            bool pegaCarroParaVerSeExisteNoDicionario = dictionaryCarros.ContainsValue(carroParaTeste);
    
        }

        private void bntQueue_Click(object sender, RoutedEventArgs e)
        {
            Queue<string> minhaFila = new Queue<string>();

            for (int i = 0; i < listCar.Count; i++)
            {
                minhaFila.Enqueue(listCar[i].Marca.ToString());
            }

            foreach (String item in minhaFila)
                Debug.WriteLine(item);

            string primeiroElemento = minhaFila.Peek();

            string ultimoElemento = minhaFila.Last();

            List<string> minhaList = new List<string>();
        }
        private void bntObservable_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> obsCollection = new ObservableCollection<string>();
            obsCollection.CollectionChanged += obsCollection_CollectionChanged;
            for (int i = 0; i < listCar.Count; i++)
            {
                obsCollection.Add(listCar.ElementAt(i).Marca.ToString());   
            }

            obsCollection.RemoveAt(obsCollection.IndexOf(obsCollection.ElementAt(3)));
        }
        void obsCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("\nUma alteração na coleção aconteceu.:");

            NotifyCollectionChangedAction acao = e.Action;
            Debug.WriteLine(acao.ToString());

            if(acao == NotifyCollectionChangedAction.Add)
            {
                foreach (var element in e.NewItems)
                {
                    Debug.WriteLine("Elemento Adicionado: "+element);
                }
            }
            if (acao == NotifyCollectionChangedAction.Remove)
            {
                foreach (var element in e.OldItems)
                {
                    Debug.WriteLine("Elemento Removido: " + element);
                }
            }

           
        }

    }
}