using api_pix_net.Models;
using api_pix_net.Models.Cob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api_pix_net.Contract
{
    public static class Validator
    {

        public static Task Cob(string txId, Cob cob)
        {
            if (cob.Calendario?.Expiracao <= 0)
                throw new Exception("Campo Cob.Calendario.Expiracao deve ser informado");

            if (string.IsNullOrEmpty(cob.Devedor?.CNPJ) && string.IsNullOrEmpty(cob.Devedor ?.CPF))
                throw new Exception("Campo Cob.Devedor.CNPJ ou Cob.Devedor.CPF deve ser informado");

            if (cob.Devedor?.CNPJ?.Length != 14 && cob.Devedor?.CPF?.Length != 11)
                throw new Exception("Campo Cob.Devedor.CNPJ ou Cob.Devedor.CPF inválido");

            if (string.IsNullOrEmpty(cob.Devedor?.Nome))
                throw new Exception("Campo Cob.Devedor.Nome deve ser informado");

            if (string.IsNullOrEmpty(cob.Chave))
                throw new Exception("Campo Cob.Chave deve ser informado");

            if (cob.SolicitacaoPagador?.Length > 140)
                throw new Exception("Campo Cob.SolicitacaoPagador deve ter no máximo 140 caracteres");

            return Task.CompletedTask;
        }



    }
}
