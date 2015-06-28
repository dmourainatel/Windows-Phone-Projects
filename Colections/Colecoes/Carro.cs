using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecoes
{
    public enum Marcas { Volkswagen, Mercedes, Forde, Fiat, Honda, Chevrolet, BMW, Ferrari, Audi}

    public class Carro : IComparable<Carro>
    {
        public int Id { get; set; }
        public Marcas Marca { get; set; }
        public String Modelo { get; set; }
        public String Cor { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        
        public int CompareTo(Carro Other)// Pela implementação do IComperable
        {
            //if(string.IsNullOrEmpty(Other.Modelo))
            //{
            //    return 0;
            //}
            //return Other.Modelo.CompareTo(this.Modelo);
            if (Other.Id > this.Id)
                return -1;
            else if (Other.Id == this.Id)
                return 0;
            else
                return 1;
        }

        public Carro(int id, Marcas marca, String modelo, String cor, int ano, decimal preco)
        {
            this.Id = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Ano = ano;
            this.Preco = preco;
        }
    }
}
