using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using api_pix_net.Contract;
using api_pix_net.Models;
using api_pix_net.Models.Cob;
using api_pix_net.Models.CobV;
using api_pix_net.Models.Pix;
using api_pix_net.Models.Webhook;
using api_pix_net.Services.Base;
using RestSharp;

namespace api_pix_net.Services
{
    /// <summary>
    /// Classe Responsável pela Comunicação com o Web Service
    /// </summary>
    [ComVisible(true)]
    public class RestWS : RequestBase, ICobrancaService
    {
        public RestWS(ConfigPSP configPSP)
            : base(configPSP)
        {
        }

        /// <summary>
        /// Criar cobrança imediata
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<Cob> CobPutAsync(string txId, Cob cob)
        {
            await Validator.Cob(txId, cob);
            SetUrlReq("/cob" + "/" + txId);

            var response = await SendRequestAsync(Method.Put, cob, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cob>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Revisar cobrança
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<Cob> CobPatchAsync(string txId, Cob cob)
        {
            await Validator.Cob(txId, cob);
            SetUrlReq("/cob" + "/" + txId);

            var response = await SendRequestAsync(Method.Patch, cob, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cob>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar cobrança imediata
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <returns></returns>
        public async Task<Cob> CobGetAsync(string txId)
        {
            SetUrlReq("/cob" + "/" + txId);

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cob>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar lista de cobranças imediatas
        /// </summary>
        /// <returns></returns>
        public async Task<CobList> CobListGetAsync(Dictionary<string, string> parameters)
        {
            SetUrlReq("/cob");

            if (Config.Parameters != null)
            {
                foreach (var kvp in Config.Parameters)
                {
                    parameters.Add(kvp.Key, kvp.Value);
                }
            }

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<CobList>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Criar cobrança com vencimento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cobv"></param>
        /// <returns></returns>
        public async Task<Cobv> CobvPutAsync(string txId, Cobv cobv)
        {
            SetUrlReq("/cobv" + "/" + txId);

            var response = await SendRequestAsync(Method.Put, cobv, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cobv>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Revisar cobrança com vencimento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txId"></param>
        /// <param name="cobv"></param>
        /// <returns></returns>
        public async Task<Cobv> CobvPatchAsync(string txId, Cobv cobv)
        {
            SetUrlReq("/cobv" + "/" + txId);

            var response = await SendRequestAsync(Method.Patch, cobv, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cobv>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar cobrança com vencimento
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public async Task<Cobv> CobvGetAsync(string txId)
        {
            SetUrlReq("/cobv" + "/" + txId);

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Cobv>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar lista de cobranças com vencimento
        /// </summary>
        /// <returns></returns>
        public async Task<CobvList> CobvListGetAsync(Dictionary<string, string> parameters)
        {
            SetUrlReq("/cobv");

            if (Config.Parameters != null)
            {
                foreach (var kvp in Config.Parameters)
                {
                    parameters.Add(kvp.Key, kvp.Value);
                }
            }

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, parameters).ConfigureAwait(false);
            return await ProcessResponse<CobvList>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar lista de Pix recebidos
        /// </summary>
        /// <returns></returns>
        public async Task<PixList> PixListGetAsync(Dictionary<string, string> parameters)
        {
            SetUrlReq("/pix");

            if (Config.Parameters != null)
            {
                foreach (var kvp in Config.Parameters)
                {
                    parameters.Add(kvp.Key, kvp.Value);
                }
            }

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, parameters).ConfigureAwait(false);
            return await ProcessResponse<PixList>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar Pix através de um e2eid
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <returns></returns>
        public async Task<Pix> PixGetAsync(string endToEndId)
        {
            SetUrlReq("/pix/" + endToEndId);

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Pix>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Solicitar devolução
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Devolucao> PixDevolucaoPutAsync(string endToEndId, string id)
        {
            SetUrlReq("/pix/" + endToEndId + "/devolucao/" + id);

            var response = await SendRequestAsync(Method.Put, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Devolucao>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar devolução
        /// </summary>
        /// <param name="endToEndId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Devolucao> PixDevolucaoGetAsync(string endToEndId, string id)
        {
            SetUrlReq("/pix/" + endToEndId + "/devolucao/" + id);

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Devolucao>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Configurar o Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="webhook"></param>
        /// <returns></returns>
        public async Task<Webhook> WebhookPutAsync(string chave, Webhook webhook)
        {
            SetUrlReq("/webhook/" + chave);

            var response = await SendRequestAsync(Method.Put, webhook, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Webhook>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Exibir informações do Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public async Task<Webhook> WebhookGetAsync(string chave)
        {
            SetUrlReq("/webhook/" + chave);

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            return await ProcessResponse<Webhook>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Consultar Webhooks cadastrados
        /// </summary>
        /// <returns></returns>
        public async Task<WebhookList> WebhookListGetAsync(Dictionary<string, string> parameters)
        {
            SetUrlReq("/webhook");

            if (Config.Parameters != null)
            {
                foreach (var kvp in Config.Parameters)
                {
                    parameters.Add(kvp.Key, kvp.Value);
                }
            }

            var response = await SendRequestAsync(Method.Get, null, Config.Headers, parameters).ConfigureAwait(false);
            return await ProcessResponse<WebhookList>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Cancelar o Webhook Pix
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public async Task<bool> WebhookDeleteAsync(string chave)
        {
            SetUrlReq("/webhook/" + chave);

            var response = await SendRequestAsync(Method.Delete, null, Config.Headers, Config.Parameters).ConfigureAwait(false);
            var data = response.Content;

            if (response.IsSuccessful && string.IsNullOrEmpty(data))
            {
                return response.IsSuccessful;
            }

            throw new ArgumentException(response.ErrorException + " " + data);
        }
    }
}
