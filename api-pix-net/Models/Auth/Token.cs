using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.Auth
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonIgnore]
        public DateTime TimeExpire => DateTime.Now.AddSeconds((ExpiresIn - 60));

        [JsonIgnore]
        public string Type => TokenType?.Replace("Token", "");

    }
}
