using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public class Usuario
    {
        //A assinatura JsonProperty(Order = n) diz em qual ordem o objeto sera passado para o json
        [JsonProperty(Order=1)]
        public int Id { get; set; }
        [JsonProperty(Order = 3)]
        public string Email { get; set; }
        [JsonProperty(Order = 4)]
        public bool EhFeliz { get; set; }
        [JsonProperty(Order = 6)]
        public DateTime DtNascimento { get; set; }
        [JsonProperty(Order = 5)]
        public DateTime DtCriacaoConta { get; set; }
        [JsonProperty(Order = 2)]
        public string Nome { get; set; }
    }
}
