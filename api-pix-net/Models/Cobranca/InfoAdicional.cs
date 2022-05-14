using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca
{
    public class InfoAdicional
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
