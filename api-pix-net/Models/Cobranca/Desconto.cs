using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca
{
    public class Desconto
    {
        [JsonProperty("modalidade")]
        public int Modalidade { get; set; }

        [JsonProperty("descontoDataFixa")]
        public List<DescontoDataFixa> DescontoDataFixa { get; set; }

    }

    public class DescontoDataFixa
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("valorPerc")]
        public string ValorPerc { get; set; }

    }
}
