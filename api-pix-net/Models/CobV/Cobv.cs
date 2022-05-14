using Newtonsoft.Json;
using api_pix_net.Models.Cobranca.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace api_pix_net.Models.CobV
{
    public  class Cobv : CobrancaBase
    {
        public Cobv(string _chave)
          : base(_chave)
        {
        }
    }
}
