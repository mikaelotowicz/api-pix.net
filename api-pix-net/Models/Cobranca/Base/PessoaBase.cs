using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca.Base
{
    public abstract class PessoaBase : EnderecoBase
    {
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("nomeFantasia")]
        public string NomeFantasia { get; set; }
        

        [JsonIgnore]
        public bool IsCNPJ => !string.IsNullOrEmpty(CNPJ);

        [JsonIgnore]
        public bool IsCPF => !string.IsNullOrEmpty(CPF);
    }
}
