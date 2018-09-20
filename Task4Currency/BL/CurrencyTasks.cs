using System;
using System.Collections.Generic;
using System.Linq;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    /// <summary>
    /// Represents all requiered tasks for currency converting.
    /// </summary>
    public class CurrencyTasks
    {
        /// <summary>
        /// Outputs all grn amounts.
        /// </summary>
        /// <param name="currencies">List of currencies.</param>
        public void OutputGrivnas(List<Currency> currencies)
        {
            currencies.Where(x => x.CurrencyName.Equals(Currencies.Uah)).ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Creates dictionary from List where key is currency name and value is general sum this currency.
        /// </summary>
        /// <param name="currencies">List of currencies.</param>
        /// <returns>Dictionary of currencies.</returns>
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

        /// <summary>
        /// Outputs sum in choosen currency.
        /// </summary>
        /// <param name="currencies">List of currencies.</param>
        /// <param name="currencyName">Name of the currency that all money will be converted to.</param>
        /// <returns>Sum of money in one currency.</returns>
        public Currency ConvertSumTo(List<Currency> currencies, Currencies currencyName)
        {
            CurrencyConverter currencyConverter = new CurrencyConverter(currencies, new CurrencyRate());

            var convertedCurrency = currencyConverter.ConvertAllTo(currencyName);

            return convertedCurrency;
        }

        /// <summary>
        /// Converts all money into all available currencies.
        /// </summary>
        /// <param name="currencies">Money in different currencies.</param>
        /// <returns>Return a list of money in different currencies.</returns>
        public List<Currency> ConvertToAllCurrencies(List<Currency> currencies)
        {
            if (currencies == null)
                return null;
            
            List<Currency> convertedCurrencies = new List<Currency>();
            var currenciesNames = Enum.GetValues(typeof(Currencies));

            foreach (var currencyName in currenciesNames)
            {
                convertedCurrencies.Add(ConvertSumTo(currencies, (Currencies)currencyName));
            }

            return convertedCurrencies;
        }
    }
}
