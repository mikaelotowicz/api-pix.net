using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Payload.Models.Base
{
    public abstract class PayloadBase
    {
        /// <summary>
        /// Nome do comerciante
        /// </summary>
        public string MerchantName { get; protected set; } = "";

        /// <summary>
        /// Nome do comerciante
        /// </summary>
        public string MerchantCity { get; protected set; } = "";

        /// <summary>
        /// Chave pix, se telefone colocar +55
        /// </summary>
        public string PixKey { get; protected set; } = "";

        /// <summary>
        /// Descrição que aparece no momento do pagamento
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Id da transação
        /// </summary>
        public string TxId { get; protected set; } = "";

        /// <summary>
        /// Valor da transação
        /// </summary>
        public string Amount { get; set; } = "0.00";

        /// <summary>
        /// Url do payload dinâmico
        /// </summary>
        public string UrlPix { get; protected set; } = "";

        /// <summary>
        /// Define se o pagamento pode ser feito apenas uma vez
        /// </summary>
        public bool UniquePayment { get; protected set; } = false;


    }
}
