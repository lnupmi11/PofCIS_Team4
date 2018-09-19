using System;
using System.Collections.Generic;
using System.Linq;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    public class CurrencyTasks
    {
        /// <summary>
        /// Outputs all grn amounts.
        /// </summary>
        public void OutputGrivnas(List<Currency> currencies)
        {
            currencies.Where(x => x.CurrencyName.Equals(Currencies.Uah)).ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Creates dictionary from List where key is currency name and value is general sum this currency.
        /// </summary>
        public Dictionary<Currencies,decimal> CreateDictionaryFromList(List<Currency> currencies)
        {
            Dictionary<Currencies, decimal> keyValuePairs = new Dictionary<Currencies, decimal>();
            currencies.ForEach(x =>
            {
                if (keyValuePairs.ContainsKey(x.CurrencyName))
                {
                    keyValuePairs[x.CurrencyName] += x.Amount;
                }
                else
                {
                    keyValuePairs.Add(x.CurrencyName, x.Amount);
                }
            });
            return keyValuePairs;
        }

        public void OutputConvertedSumToGrivnas(List<Currency> currencies)
        {
            CurrencyConverter currencyConverter = new CurrencyConverter(currencies, new CurrencyRate());

            Console.WriteLine($"In grivnas sum is: {currencyConverter.ConvertAllTo(Currencies.Uah)}");
        }
    }
}
