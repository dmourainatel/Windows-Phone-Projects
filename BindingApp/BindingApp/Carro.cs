using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingApp
{
    // Para que o binding de certo para atualizar o objeto de tela é necessário
    // a classe que ta sendo passada para o DataContext a interface INotifyPropertyChanged [ Mode="TwoWay"] FULLDUPLEX
    public class Carro : INotifyPropertyChanged 
    {
        // é necessario implementar esse evento da interface INotifyPropertyChanged
        // Na classe que a implementa
        public event PropertyChangedEventHandler PropertyChanged;

        public int  VelocidadeMaxima { get; set; }

        //Para o binding funcionar eh necessario implementar a PropertyChangeEventArgs para cada propriedade
        // que for se utilizar o recurso de Binding
        private string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set 
            {
                 _modelo = value;        
                 ChangeValue("Modelo");// Passa o nome da propriedade para a UI                                        
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                ChangeValue("Id");

            }
        }

        private string _marca;
        public string Marca
        {
            get { return _marca; }
            set
            { 
                _marca = value;
                ChangeValue("Marca");
            }
        }

        private int _preco;
        public int Preco
        {
            get { return _preco; }
            set 
            { 
                _preco = value;
                ChangeValue("Preco");
            }
        }
        

        // Metodo para avisar que a propriedade foi alterada da propriedade que esta sendo passada
        private void ChangeValue(string str)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
        
      
    }
}
