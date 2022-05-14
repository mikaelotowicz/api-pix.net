using Newtonsoft.Json;
using api_pix_net.Payload;
using api_pix_net.Payload.Models;
using System;
using System.Collections.Generic;

namespace api_pix_net.Models.Cobranca.Base
{
    public abstract class CobrancaBase
    {
        public CobrancaBase(string _chave)
        {
            Chave = _chave;
        }


        [JsonProperty("calendario")]
        public Calendario Calendario { get; set; }

        [JsonProperty("devedor")]
        public Devedor Devedor { get; set; }

        [JsonProperty("recebedor")]
        public Recebedor Recebedor { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("revisao")]
        public int Revisao { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pix")]
        public List<Pix.Pix> Pix { get; set; }

        [JsonProperty("valor")]
        public Valor Valor { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; private set; }

        [JsonProperty("solicitacaoPagador")]
        public string SolicitacaoPagador { get; set; }

        [JsonProperty("infoAdicionais")]
        public List<InfoAdicional> InfoAdicionais { get; set; }
    }
}
