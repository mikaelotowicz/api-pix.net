using Newtonsoft.Json;
using api_pix_net.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Webhook
{
    public class WebhookList
    {
        [JsonProperty("parametros")]
        public ParametrosBase Parametros { get; set; }

        [JsonProperty("webhooks")]
        public List<Webhook> Webhooks { get; set; }
    }
}
