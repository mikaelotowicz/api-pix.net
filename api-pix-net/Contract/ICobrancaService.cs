using api_pix_net.Models.Cob;
using api_pix_net.Models.CobV;
using api_pix_net.Models.Pix;
using api_pix_net.Models.Webhook;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace api_pix_net.Contract
{
    public interface ICobrancaService 
    {
        /// <summary>
        /// Criar cobrança imadiata
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        Task<Cob> CobPutAsync(string txId, Cob cob);

        /// <summary>
        /// Revisar cobrança
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        Task<Cob> CobPatchAsync(string txId, Cob cob);

        /// <summary>
        /// Consultar cobrança imediata
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        Task<Cob> CobGetAsync(string txId);

        /// <summary>
        /// Consulta lista de cobranças imediatas
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        Task<CobList> CobListGetAsync(Dictionary<string, string> parameters);


        /// <summary>
        /// Criar cobrança com vencimento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cobv"></param>
        /// <returns></returns>
       Task<Cobv> CobvPutAsync(string txId, Cobv cobv);


        /// <summary>
        /// Revisar cobrança com vencimento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cobv"></param>
        /// <returns></returns>
        Task<Cobv> CobvPatchAsync(string txId, Cobv cobv);

        /// <summary>
        /// Consultar cobrança com vencimento
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        Task<Cobv> CobvGetAsync(string txId);


        /// <summary>
        /// Consultar lista de cobranças com vencimento
        /// </summary>
        /// <returns></returns>
        Task<CobvList> CobvListGetAsync(Dictionary<string, string> parameters);


        /// <summary>
        /// Consultar lista de Pix recebidos
        /// </summary>
        /// <returns></returns>
        Task<PixList> PixListGetAsync(Dictionary<string, string> parameters);


        /// <summary>
        /// Consultar Pix através de um e2eid
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <returns></returns>
        Task<Pix> PixGetAsync(string endToEndId);


        /// <summary>
        /// Solicitar devolução
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Devolucao> PixDevolucaoPutAsync(string endToEndId, string id);


        /// <summary>
        /// Consultar devolução
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Devolucao> PixDevolucaoGetAsync(string endToEndId, string id);


        /// <summary>
        /// Configurar o Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="webhook"></param>
        /// <returns></returns>
        Task<Webhook> WebhookPutAsync(string chave, Webhook webhook);


        /// <summary>
        /// Exibir informações do Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        Task<Webhook> WebhookGetAsync(string chave);


        /// <summary>
        /// Consultar Webhooks cadastrados
        /// </summary>
        /// <returns></returns>
        Task<WebhookList> WebhookListGetAsync(Dictionary<string, string> parameters);


        /// <summary>
        /// Cancelar o Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        Task<bool> WebhookDeleteAsync(string chave);

    }
}
