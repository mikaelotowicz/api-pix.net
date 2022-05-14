using Newtonsoft.Json;
using api_pix_net.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Pix
{
    public class PixList
    {
        [JsonProperty("parametros")]
        public ParametrosBase Parametros { get; set; }

        [JsonProperty("pix")]
        public List<Pix> pix { get; set; }
    }
}
