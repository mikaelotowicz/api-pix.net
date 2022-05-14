using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca
{
    public class Calendario
    {
        [JsonProperty("criacao")]
        public DateTime? Criacao { get; set; }

        [JsonProperty("expiracao")]
        public int? Expiracao { get; set; }

        [JsonProperty("dataDeVencimento")]
        public DateTime? DataDeVencimento { get; set; }

        [JsonProperty("validadeAposVencimento")]
        public int? ValidadeAposVencimento { get; set; }
        
    }
}
