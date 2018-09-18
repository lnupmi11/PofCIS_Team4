using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Currency
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
