using api_pix_net.Enum;
using api_pix_net.Services.Base;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace api_pix_net
{
    public class ConfigPSP
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UrlAuth { get; set; }
        public string UrlPix { get; set; }
        public string NomeMerchant { get; set; }
        public string CidadeMerchant { get; set; }
        public X509Certificate2 Certificate { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public Dictionary<string, string> HeadersAuth { get; set; }
        public Dictionary<string, string> ParametersAuth { get; set; }
        public object ContentAuth { get; set; }

        public ConfigPSP()
        {
            ClientId = "";
            ClientSecret = "";
            UrlAuth = "";
            UrlPix = "";
            NomeMerchant = "";
            CidadeMerchant = "";
        }

        public ConfigPSP(string nomeMerchant, string cidadeMerchant,  string clientId, string clientSecret, string urlAuth, string urlPix, X509Certificate2 certificate = null)
        {
            this.NomeMerchant = nomeMerchant;
            this.CidadeMerchant = cidadeMerchant;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.UrlAuth = urlAuth;
            this.UrlPix = urlPix;
            this.Certificate = certificate;
            this.Headers = new Dictionary<string, string>();
            this.Parameters = new Dictionary<string, string>();
            this.HeadersAuth = new Dictionary<string, string>();
            this.ParametersAuth = new Dictionary<string, string>();
            this.ContentAuth = null;
        }
    }
}
