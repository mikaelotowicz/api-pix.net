using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Base
{
    public  class ParametrosBase
    {
        [JsonProperty("inicio")]
        public DateTime Inicio { get; set; }

        [JsonProperty("fim")]
        public DateTime Fim { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("txIdPresente")]
        public bool? TxIdPresente { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("paginacao")]
        public PaginacaoBase Paginacao { get; set; }
    }
}
