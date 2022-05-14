using api_pix_net.Models.Cobranca.Base;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace api_pix_net.Models.Cob
{
    public class Cob : CobrancaBase
    {
        public Cob(string _chave)
          : base(_chave)
        {
        }
    }
}
