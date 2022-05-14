using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca
{
    public class Juros
    {
        [JsonProperty("modalidade")]
        public int Modalidade { get; set; }

        [JsonProperty("valorPerc")]
        public string ValorPerc { get; set; }

    }
}
