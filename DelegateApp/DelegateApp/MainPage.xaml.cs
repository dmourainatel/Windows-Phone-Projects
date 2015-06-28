using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DelegateApp.Resources;
using System.Diagnostics;

namespace DelegateApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        delegate int MinhaFuncao(int a, int b);

        private void bntDelegate_Click(object sender, RoutedEventArgs e)
        {
            MinhaFuncao soma = Adicao;
            MinhaFuncao subtrai = Subtracao;

            int a = soma(3, 7);
            int b = subtrai(15, 5);

        }

        private int Adicao(int x, int y)
        {
            return x + y;
        }

        private int Subtracao(int x, int y)
        {
            return x - y;
        }



        delegate int AoQuadrado(int i);
        delegate int Multiplica(int a, int b);

        private void bntDelegateComLambda_Click(object sender, RoutedEventArgs e)
        {
            AoQuadrado meuDelegate = chapolin => chapolin * chapolin;
            int resultado = meuDelegate(5);

            Multiplica meuDelegateMultiplica = (chapolin,chaves) => chapolin * chaves;
            int resultado2 = meuDelegateMultiplica(5,2);   
        }

        private void bntLivraria_Click(object sender, RoutedEventArgs e)
        {
            //Crio 5 livros
            Livro livro1 = new Livro("Livro 1", "Autor 1", 1, true);
            Livro livro2 = new Livro("Livro 2", "Autor 2", 2, true);
            Livro livro3 = new Livro("Livro 3", "Autor 3", 3, true);
            Livro livro4 = new Livro("Livro 4", "Autor 4", 4, true);
            Livro livro5 = new Livro("Livro 5", "Autor 5", 5, true);
 
            //Crio lista com estes 5 livros
            List<Livro> listaLivros = new List<Livro>();
            listaLivros.Add(livro1);
            listaLivros.Add(livro2);
            listaLivros.Add(livro3);
            listaLivros.Add(livro4);
            listaLivros.Add(livro5);

            //Predicate eh um Delegate que retorna um Boolean
            Predicate<Livro> livroPredicate = new Predicate<Livro>(EhLivro);

            Livro liv = listaLivros.Find(chapolin => livroPredicate(chapolin));

            //Fazendo Predicate atravez de um método Anonimo
            /*Livro liv = listaLivros.Find(delegate(Livro l)
            {
                return l.Nome == "Livro 3";
            });*/


            //Mais um exemplo de um metodo anonimo
            //Button button = new Button();
            //button.Click += delegate(object ss, RoutedEventArgs ee)
            //{
            //    MessageBox.Show("Ola mundo!");
            //};



        }

        private bool EhLivro(Livro livro)
        {
            return livro.Nome == "Livro 3";
        }


        //Quem quiser ser desse tipo, tem que apontar para um método void e receber uma string
        delegate void MeuDelegate(string s);

        private void bntCombinandoDelegates(object sender, RoutedEventArgs e)
        {
            MeuDelegate a, b, c, d;

            // a esta apontando para o evento ImrimeOla
            a = new MeuDelegate(ImprimeOla); // o mesmo serve para a = ImprimeOla;
            // b aponta para a função ImprimeTchau
            b = ImprimeTchau;
            // c aponta para a combinado com b
            c = a + b;
            d = c -a ;

            //a("Rafael");
            //b("João");
            //c("Diego");

            d("Maria");
        }

        //Metodo que aceita as condições do delegate 
        private void ImprimeOla(string nome)
        {
            Debug.WriteLine("Ola, {0}", nome);
        }

        //Metodo que aceita as condições do delegate
        private void ImprimeTchau(string nome)
        {
            Debug.WriteLine("Tchau, {0}", nome);
        }

       

        
    }
}