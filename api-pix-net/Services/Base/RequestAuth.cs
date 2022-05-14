using Newtonsoft.Json;
using api_pix_net.Models.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace api_pix_net.Services.Base
{
    public class RequestAuth : RequestExtention
    {

        public RequestAuth(ConfigPSP configPSP)
            : base(configPSP)
        {
        }

        /// <summary>
        /// Autenticação Oauth2
        /// </summary>
        /// <returns></returns>
        internal async Task AuthAsync()
        {
            if (!string.IsNullOrEmpty(TokenOauth.AccessToken))
                return;

            var response = await SendRequestAuthAsync().ConfigureAwait(false);
            TokenOauth = await ProcessResponse<Token>(response).ConfigureAwait(false);
        }


        /// <summary>
        /// Define a URL Auth
        /// </summary>
        /// <returns></returns>
        private string SetUrlReq()
        {
            return Config.UrlAuth;
        }


        /// <summary>
        /// URL da Requisição Auth
        /// </summary>
        /// <returns></returns>
        private async Task<string> SetUrlAuthAsync()
        {
            return SetUrlReq() + await SetParametersAsync(Config.ParametersAuth).ConfigureAwait(false);
        }


        /// <summary>
        /// Define o Basic Token do Auth
        /// </summary>
        /// <returns></returns>
        private async Task<string> SetBasicTokenAuthAsync()
        {
            var byteArray = new UTF8Encoding().GetBytes(Config.ClientId + ":" + Config.ClientSecret);
            return await Task.FromResult(Convert.ToBase64String(byteArray));
        }


        /// <summary>
        /// Envia uma requisição do Auth
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private async Task<RestResponse> SendRequestAuthAsync()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            using (client = new RestClient(SetHandler()))
            {
                var request = new RestRequest(await SetUrlAuthAsync(), Method.Post);
                request.AddHeader("Authorization", "Basic" + " " + await SetBasicTokenAuthAsync());

                await SetHeadersAsync(request).ConfigureAwait(false);
                await SetContentAsync(request, Config.ContentAuth).ConfigureAwait(false);

                return await client.ExecuteAsync(request).ConfigureAwait(false);
            }
        }




    }
}
