using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Cobranca
{
    public class Valor
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("modalidadeAlteracao")]
        public int ModalidadeAlteracao { get; set; }

        [JsonProperty("multa")]
        public Multa Multa { get; set; }

        [JsonProperty("juros")]
        public Juros Juros { get; set; }

        [JsonProperty("abatimento")]
        public Abatimento Abatimento { get; set; }

        [JsonProperty("desconto")]
        public Desconto Desconto { get; set; }
    }
}
