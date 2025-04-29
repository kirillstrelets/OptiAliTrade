using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace OptiAliTrade
{
    public class CurrencyService
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Dictionary<string, decimal>> GetCurrenciesAsync(DateTime date)
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            if (date.Date != DateTime.Today.Date)
            {
                url += $"?date_req={date:dd/MM/yyyy}";
            }

            var currencies = new Dictionary<string, decimal>();

            try
            {
                var response = await client.GetStringAsync(url);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response);

                var nodes = xmlDoc.SelectNodes("//Valute");

                foreach (XmlNode node in nodes)
                {
                    string charCode = node["CharCode"]?.InnerText;
                    string valueStr = node["Value"]?.InnerText;

                    if (!string.IsNullOrEmpty(charCode) && !string.IsNullOrEmpty(valueStr))
                    {
                        if (decimal.TryParse(valueStr.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
                        {
                            currencies[charCode] = value;
                        }
                    }
                }
                currencies["RUB"] = 1m;
            }
            catch (Exception)
            {
                throw new Exception("Unable to get the current rate from the Central Bank of the Russian Federation website. Check your internet access and try again.");
            }
            return currencies;
        }
    }
}