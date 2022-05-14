using Newtonsoft.Json;
using api_pix_net.Models.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace api_pix_net.Services.Base
{
    public abstract class RequestExtention : IDisposable
    {
        internal ConfigPSP Config;
        internal Token TokenOauth;
        internal RestClient client;
        internal JsonSerializerSettings JsonSettings;

        public RequestExtention(ConfigPSP configPSP)
        {
            Config = configPSP;
            TokenOauth = new Token();
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public void Dispose()
        {
            client.Dispose();
        }


        /// <summary>
        /// Processa o retorno da requisição
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        internal async Task<T> ProcessResponse<T>(RestResponse response)
        {
            var data = response.Content;

            if (response.IsSuccessful)
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }

            throw new ArgumentException(response.ErrorException + " " + data);
        }


        /// <summary>
        /// Conteúdo da Requisição
        /// </summary>
        /// <returns></returns>
        internal virtual async Task SetContentAsync(RestRequest request, object data = null)
        {
            if (data != null)
            {
                var content = await Task.FromResult(JsonConvert.SerializeObject(data, JsonSettings)).ConfigureAwait(false);
                request.AddBody(content, "application/json");
            }
        }


        /// <summary>
        ///  Manipulador de Mensagens
        /// </summary>
        /// <returns></returns>
        internal HttpClientHandler SetHandler()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(Config.Certificate);
            return handler;
        }


        /// <summary>
        /// Cabeçalho da Requisição
        /// </summary>
        /// <returns></returns>
        internal async Task SetHeadersAsync(RestRequest request, Dictionary<string, string> headers = null)
        {
            await Task.Run(() =>
            {
                if (headers != null)
                {
                    foreach (var i in headers)
                    {
                        request.AddHeader(i.Key, i.Value);
                    }
                }
            });
        }


        /// <summary>
        /// Parametros da Requisição
        /// </summary>
        /// <returns></returns>
        internal async Task<string> SetParametersAsync(Dictionary<string, string> parameters = null)
        {
            List<string> items = new List<string>();

            if (parameters != null)
            {
                foreach (var i in parameters)
                {
                    items.Add(String.Concat(i.Key, "=", i.Value));
                }
            }

            if (items.Count > 0)
                return await Task.FromResult("?" + String.Join("&", items.ToArray())).ConfigureAwait(false);
            else
                return "";
        }
    }
}
