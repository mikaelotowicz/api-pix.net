using Newtonsoft.Json;
using api_pix_net.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cob
{
    public class CobList
    {
        [JsonProperty("parametros")]
        public ParametrosBase Parametros { get; set; }

        [JsonProperty("cobs")]
        public List<Cob> Cobs { get; set; }
    }
}
