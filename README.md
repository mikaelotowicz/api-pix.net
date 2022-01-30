<img src="https://www.bcb.gov.br/content/estabilidadefinanceira/piximg/logo_pix.png"> 

# api-pix.net
Biblioteca para geração de QR Code dinâmico do PIX (Sistema de pagamento instantâneo do Banco Central do Brasil)

* A implementação desta biblioteca tem como objetivo auxiliar na geração de QR Codes dinâmicos do Pix. O conjunto de funções disponibilizadas por essa biblioteca devem ser verificadas junto a documentação do PSP, já que alguns PSPs não implementaram algumas funções que está biblioteca contempla.


# Iniciando
  * As configurações podem variar de PSP para PSP, é necessário verificar a documentação do PSP utilizado.
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
        
        RestWS rest = new RestWS(PSP);
 ````
 # Cob
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
        
         var pix = await rest.CobPutAsync(txId: "000000000000000000100", cob: Cob);
````
 * Revisar Cobrança Imediata
```C#
        var revisar = await rest.CobPatchAsync(txId: "000000000000000000100", cob: Cob); 
````
 * Consultar Cobrança Imediata
```C#
        var consultar = await rest.CobGetAsync(txId: "000000000000000000100");
````
# CobV
* Criando Cobrança com Vencimento
```C#
       var Cobv = new Cobv(_chave: "7f6844d0-de89-47e5-9ef7-e0a35a681615")
       {
           Calendario = new Calendario
           {
               DataDeVencimento = "2022-02-20"),
               ValidadeAposVencimento = 10
           },
           Devedor = new Devedor
           {
               CPF = "12345678909",
               Nome = "Francisco da Silva",
               Logradouro = "AV",
               Cidade = "Erechim",
               UF = "RS",
               CEP = "99700424",
           },
           Valor = new Valor
           {
               Original = "1.00",

               Multa = new Multa
               {
                   Modalidade = 2,
                   ValorPerc = "15.00",
               },

               Juros = new Juros
               {
                   Modalidade = 2,
                   ValorPerc = "10.00",
               },

               Desconto = new Desconto
               {
                   Modalidade = 1,
                   DescontoDataFixa = new List<DescontoDataFixa>
                   {
                       new DescontoDataFixa
                       {
                           Data = "2022-02-10",
                           ValorPerc = "20.00",
                       }
                   }
               }
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

       var pixv = await rest.CobvPutAsync(txId: "00000000012", cobv: Cobv);
````
 * Revisar Cobrança com Vencimento
```C#
        var revisarv = await rest.CobvPatchAsync(txId: "00000000012", cobv: Cobv);
````
 * Consultar Cobrança com Vencimento
```C#
       var consultarv = await rest.CobvGetAsync(txId: "00000000012");
````
# Pix
* Consultar Pix
```C#
        var pix = await rest.PixGetAsync(endToEndId: "E9040088820210310181400008883206");
````
* Consultar Pix Recebidos
  * Parametros opcionais não utilizados para o filtro devem ser removidos 
```C#
        var recebidos = await rest.PixListGetAsync(new Dictionary<string, string>
         {
             ["inicio"] = "2020-04-01T00:00:00Z",
             ["fim"] = "2020-04-01T23:59:59Z",
             ["txid"] = "opcional",
             ["cpf"] = "opcional",
             ["cnpj"] = "opcional",
             ["paginacao.paginaAtual"] = "0",
             ["paginacao.itensPorPagina"] = "100"
         });
````
* Solicitar Devolução
```C#
        var dev = await rest.PixDevolucaoPutAsync(endToEndId: "E9040088820210310181400008883206", id: "1");
````
 * Consultar Devolução
```C#
        var dev = await rest.PixDevolucaoGetAsync(endToEndId: "E9040088820210310181400008883206", id: "1");
````
# Webhook
 * Configurar Webhook
```C#
        var web = await rest.WebhookPutAsync("7f6844d0-de89-47e5-9ef7-e0a35a681615", new Webhook
        {
            Chave = "https://pix.example.com/api/webhook/",
        });
```
* Consultar Webhook
```C#
        var web = await rest.WebhookGetAsync("7932ef9c-f0bc-4e41-ad4f-0866102b519f");
```
* Consultar Webhooks Cadastrados
```C#
        var weeblist = await rest.WebhookListGetAsync(new Dictionary<string, string>
        {
            ["inicio"] = "2020-04-01T00:00:00Z",
            ["fim"] = "2020-04-01T23:59:59Z",
            ["paginacao.paginaAtual"] = "0",
            ["paginacao.itensPorPagina"] = "100"
        });
```
* Deletar Webhook
```C#
        var retorno = await rest.WebhookDeleteAsync("7932ef9c-f0bc-4e41-ad4f-0866102b519f");
```

