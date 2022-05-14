using Newtonsoft.Json;
using api_pix_net.Contract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace api_pix_net.Services.Base
{
    public class RequestBase : RequestAuth
    {
        private string UrlPix;

        public RequestBase(ConfigPSP configPSP)
            : base(configPSP)
        {
        }

        /// <summary>
        /// Define a URL
        /// </summary>
        /// <returns></returns>
        internal void SetUrlReq(string _url)
        {
            UrlPix = Config.UrlPix + _url;
        }


        /// <summary>
        /// URL da Requisição
        /// </summary>
        /// <returns></returns>
        internal async Task<string> GetUrlAsync(Dictionary<string, string> parameters)
        {
            return UrlPix + await SetParametersAsync(parameters).ConfigureAwait(false);
        }


        /// <summary>
        /// Envia uma requisição
        /// </summary>
        /// <param name="type_token"></param>
        /// <param name="access_token"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal virtual async Task<RestResponse> SendRequestAsync(
            Method method,
            object data = null,
            Dictionary<string, string> headers = null,
            Dictionary<string, string> parameters = null)
        {
            await AuthAsync();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var options = new RestClientOptions()
            {
                ConfigureMessageHandler = handler => SetHandler(),
                CachePolicy = new CacheControlHeaderValue { NoCache = true },
            };

            using (client = new RestClient(options))
            {
                var request = new RestRequest(await GetUrlAsync(parameters), method);
                request.AddHeader("Authorization", TokenOauth.Type + " " + TokenOauth.AccessToken);

                await SetHeadersAsync(request, headers).ConfigureAwait(false);
                await SetContentAsync(request, data).ConfigureAwait(false);

                return await client.ExecuteAsync(request);
            }
        }

    }
}
