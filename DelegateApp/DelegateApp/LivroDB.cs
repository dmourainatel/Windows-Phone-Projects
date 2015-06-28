using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    public class LivroDB
    {
        List<Livro> _livros = new List<Livro>();

        public void AdicionaLivro(Livro livro)
        {
            _livros.Add(livro);
        }

        //public void RemoverLivro();

        public void AdicionaLivro(string nome, string autor, decimal preco, bool capaDura)
        {
            Livro livro = new Livro(nome,autor,preco,capaDura);
            _livros.Add(livro);
        }
    }

    public class Livro
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public bool CapaDura { get; set; }

        public Livro(string nome, string autor, decimal preco, bool capaDura)
        {
            this.Nome = nome;
            this.Autor = autor;
            this.Preco = preco;
            this.CapaDura = capaDura;
        }
    }
}
