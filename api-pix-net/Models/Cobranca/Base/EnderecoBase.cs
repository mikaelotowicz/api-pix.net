using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca.Base
{
    public abstract class EnderecoBase
    {
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }
    }
}
