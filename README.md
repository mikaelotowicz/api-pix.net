<img src="https://www.bcb.gov.br/content/estabilidadefinanceira/piximg/logo_pix.png"> 

# api-pix.net
Biblioteca para geração de QRCode dinâmico do PIX (Sistema de pagamento instantâneo do Banco Central do Brasil)

* Iniciando
 ```C#

        var PSP = new ConfigPSP
        {
            PSP = EPSP.Santander,
            ChavePix = "Chave pix",
            NomeMerchant = "Nome Comerciante",
            CidadeMerchant = "Cidade Comerciante",
            ClientId = "Cliente Id",
            ClientSecret = "Cliente Secret",
            UrlAuth = "https://pix.santander.com.br/sandbox/oauth/token",
            UrlPix = "https://pix.santander.com.br/api/v1/sandbox",
            Certificate = new X509Certificate2(@"C:\Certificados\Certificado.cer"),
            ParametersAuth = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            },
        };
        
 ````
 * Criando Cobrança Imediata
```C#
        var Cob = new Cob(_chave: "7f6844d0-de89-47e5-9ef7-e0a35a681615")
        {
            Calendario = new Calendario
            {
                Expiracao = 3600
            },
            Devedor = new Devedor
            {
                CPF = "12345678909",
                Nome = "Francisco da Silva"
            },
            Valor = new Valor
            {
                Original = "1.00"
            },
            SolicitacaoPagador = "Serviço Realizado",

            InfoAdicionais = new System.Collections.Generic.List<InfoAdicional>
            {
                new InfoAdicional
                {
                    Nome = "Campo 1",
                    Valor = "Informação Adicional1 do PSP-Recebedor"
                }
            },
        };
        
         RestWS rest = new RestWS(PSP);
         var pix = await rest.CobPutAsync(txId: "000000000000000000100", cob: Cob);
        
