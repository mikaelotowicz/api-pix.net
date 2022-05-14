using api_pix_net.Payload.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Payload.Models
{
    /*
       * Este código foi modificado.
       * AUTOR Original: ALEXANDRE SANLIM
       * GitHub: https://github.com/alexandresanlim
    */

    /// <summary>
    /// Dados do Payload para o QR Code
    /// </summary>
    public class DynamicPayload : PayloadBase
    {
        /// <param name="_txId"></param>
        /// <param name="_merchantName"></param>
        /// <param name="_merchantCity"></param>
        /// <param name="_urlPix"></param>
        /// <param name="_amount"></param>
        /// <param name="_uniquePayment"></param>
        /// <param name="_description"></param>
        public DynamicPayload(string _txId, string _merchantName, string _merchantCity, string _urlPix, string _amount = null, bool _uniquePayment = true, string _description = "")
        {
            Description = _description;
            MerchantName = _merchantName;
            MerchantCity = _merchantCity;
            TxId = _txId;
            Amount = _amount;
            UrlPix = _urlPix;
            UniquePayment = _uniquePayment;
        }


    }
}
