using Newtonsoft.Json;
using api_pix_net.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.CobV
{
    public class CobvList
    {
        [JsonProperty("parametros")]
        public ParametrosBase Parametros { get; set; }

        [JsonProperty("cob")]
        public List<Cobv> Cob { get; set; }
    }
}
