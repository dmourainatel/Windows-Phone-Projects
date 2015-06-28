using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoApp
{
    
    public class Carro
    {
        public delegate void SofreuAlteracao(string propriedade);
        public event SofreuAlteracao AlteracaoOcorreu;
        
        private string _nome;

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
                if(AlteracaoOcorreu!=null)
                    AlteracaoOcorreu("Nome");
            }
        }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int VelocidadeMaxima { get; set; }
        
        

        //public string getNome()
        //{
        //    return _nome;
        //}

        //public void SetNome(string nome)
        //{
        //    _nome = nome;
        //}
    }
}
