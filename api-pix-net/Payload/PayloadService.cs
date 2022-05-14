using api_pix_net.Contract;
using api_pix_net.Payload;
using System;
using System.Collections.Generic;
using System.Text;
using api_pix_net.Payload.Models;
using api_pix_net.Enum;
using api_pix_net.Payload.Models.Base;

namespace api_pix_net.Payload
{
    /*
       * Este código foi modificado.
       * AUTOR Original: ALEXANDRE SANLIM
       * GitHub: https://github.com/alexandresanlim
    */

    /// <summary>
    /// Responsável pela Geração da String do QR Code
    /// </summary>
    public static class PayloadService
    {
        private static string GetIndicator()
        {
            return GetValue(PayloadId.PayloadFormatIndicator, "01");
        }

        private static string GetMerchantAccountInformation(this PayloadBase payload)
        {
            var gui = GetValue(PayloadId.MerchantAccountInfomationGui, "BR.GOV.BCB.PIX");

            var key = !string.IsNullOrEmpty(payload?.PixKey) ? GetValue(PayloadId.MerchantAccountInfomationKey, payload.PixKey) : "";

            var description = !string.IsNullOrEmpty(payload?.Description) ? GetValue(PayloadId.MerchantAccountInformationDescription, payload.Description) : "";

            //url do qrcode dinâmico
            var url = !string.IsNullOrEmpty(payload?.UrlPix) ? GetValue(PayloadId.MerchantAccountInformationUrl, payload.UrlPix) : "";

            return GetValue(PayloadId.MerchantAccountInfomation, gui + key + description + url);
        }

        private static string GetMerchantCategoryCode()
        {
            return GetValue(PayloadId.MerchantCategoryCode, "0000");
        }

        private static string GetTransationCurrency()
        {
            return GetValue(PayloadId.TransactionCurrency, "986");
        }

        private static string GetTransationAmount(this PayloadBase payload)
        {
            if (string.IsNullOrEmpty(payload?.Amount))
                return "";

            return GetValue(PayloadId.TransactionAmount, payload.Amount);
        }

        private static string GetCountryCode()
        {
            return GetValue(PayloadId.CountryCode, "BR");
        }

        private static string GetMerchantName(this PayloadBase payload)
        {
            return GetValue(PayloadId.MerchantName, payload.MerchantName);
        }

        private static string GetMerchantCity(this PayloadBase payload)
        {
            return GetValue(PayloadId.MerchantCity, payload.MerchantCity);
        }

        private static string GetAdditionalDataFieldTemplate(this PayloadBase payload)
        {
            var txidInfo = payload.TxId.Length > 25 ? payload.TxId.Substring(0, 25) : payload.TxId;

            var txid = GetValue(PayloadId.AdditionalFieldTemplateTxId, txidInfo);

            return GetValue(PayloadId.AdditionalFieldTemplate, txid);
        }

        private static string GetCrc16(string fullPaylod)
        {
            var paylodToCrc16 = fullPaylod + PayloadId.CRC16 + "04";

            var calc = Crc16.ComputeCRC(paylodToCrc16);

            return fullPaylod + GetValue(PayloadId.CRC16, calc);
        }

        private static string GetUniquePayment(this PayloadBase payload)
        {
            return payload.UniquePayment ? GetValue(PayloadId.PointOfInitiationMethod, "12") : "";
        }

        private static string GetValue(string id, string value)
        {
            var length = value.Length < 10 ? ("0" + value.Length.ToString()) : value.Length.ToString();

            var r = id + length + value;

            return r;
        }

        public static string StringQrCode(this PayloadBase payload)
        {
            var pgenerator =
               GetIndicator() +
               payload.GetUniquePayment() +
               payload.GetMerchantAccountInformation() +
               GetMerchantCategoryCode() +
               GetTransationCurrency() +
               payload.GetTransationAmount() +
               GetCountryCode() +
               payload.GetMerchantName() +
               payload.GetMerchantCity() +
               payload.GetAdditionalDataFieldTemplate();

            return GetCrc16(pgenerator);
        }
    }
}
