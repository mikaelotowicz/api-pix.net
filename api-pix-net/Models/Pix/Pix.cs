using Newtonsoft.Json;
using api_pix_net.Models.Cobranca.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Pix
{
    public class Pix
    {
        [JsonProperty("endToEndId")]
        public string EndToEndId { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("horario")]
        public DateTime Horario { get; set; }

        [JsonProperty("infoPagador")]
        public string InfoPagador { get; set; }

        [JsonProperty("devolucoes")]
        public List<Devolucao> Devolucoes { get; set; }

        [JsonProperty("pagador")]
        public Pagador Pagador { get; set; }
    }
}
