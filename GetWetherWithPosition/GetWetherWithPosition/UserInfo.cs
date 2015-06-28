using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWetherWithPosition
{
    public class UserInfo : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

         string _cidade;
         string _pais;
         string _estado;
         string _bairro;
   
        public string Bairro {
            get { return _bairro; }
            set
            {
                _bairro = value;
                ChangeValue("Bairro");
            }
        }

        

        public string Estado {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
                ChangeValue("Estado");
            }
        }

        public string Cidade 
         { get
          {
            return _cidade;
          }
             set
             { 
                _cidade = value;
                 ChangeValue("Cidade");
             }
         }
         public string Pais
         { get
            {
                return this._pais;
            }
             set
             {
                 this._pais = value;
                 ChangeValue("Pais");
             }
         }

         string _temperatura;
         public string Temperature 
         { get
             { return _temperatura; }
             set
             {
                 _temperatura = value;
                 ChangeValue("Temperature");
             }
         }

         private void ChangeValue(string str)
         {
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(str));
         }
         

    }
}
