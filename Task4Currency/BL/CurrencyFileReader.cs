using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task4Currency.Classes;

namespace Task4Currency.BL
{
    public class CurrencyFileReader
    {
        /// <summary>
        /// creates list of currencies by reading from file
        /// </summary>
        public List<Currency> GetCurrenciesListFromFile(string fileName)
        {
            List<Currency> currencies = new List<Currency>();
            var allData = File.ReadAllText(fileName).Split(',').ToList();
            allData.ForEach(x =>
            {
                Currency currency = new Currency();
                currency.Read(x);
                currencies.Add(currency);
            });
            return currencies;
        }
    }
}
