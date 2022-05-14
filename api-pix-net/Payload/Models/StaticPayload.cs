using api_pix_net.Payload.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Payload.Models
{
    public class StaticPayload : PayloadBase
    {
        /// <summary>
        /// Retorna um objeto pronto para ser gerado um payload para um QRCode ESTATICO
        /// </summary>
        /// <param name="_pixKey">Chave pix do recebedor</param>
        /// <param name="_amount">Valor total do pix</param>
        /// <param name="_txId">Identificado do pagamento</param>
        /// <param name="_merchant">Informações do titular da conta</param>
        /// <param name="_description">Uma descrição que aparecerá no momento do pagamento</param>

        public StaticPayload(string _pixKey, string _txId, string _merchantName, string _merchantCity, string _amount = null, string _description = "")
        {
            PixKey = _pixKey;
            Description = _description;
            MerchantName = _merchantName;
            MerchantCity = _merchantCity;
            TxId = _txId;
            Amount = _amount;
        }

    }
}
