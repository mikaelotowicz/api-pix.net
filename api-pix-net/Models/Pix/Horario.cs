using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Pix
{
    public class Horario
    {
        [JsonProperty("solicitacao")]
        public DateTime Solicitacao { get; set; }
    }
}
