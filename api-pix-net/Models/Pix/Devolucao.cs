using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Pix
{
    public class Devolucao
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rtrId")]
        public string RtrId { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("horario")]
        public Horario Horario { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
