using System.Collections.Generic;
using System.Linq;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    /// <summary>
    /// Represents class that converts currencies.
    /// </summary>
    public class CurrencyConverter
    {
        /// <summary>
        /// List of currencies that will be converted.
        /// </summary>
        public List<Currency> Currencies { get; private set; }

        /// <summary>
        /// Current currency rate.
        /// </summary>
        public  CurrencyRate CurrecyRate { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public CurrencyConverter()
        {
            Currencies = new List<Currency>();
            CurrecyRate = new CurrencyRate();
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="currencies">List of currencies to convert.</param>
        /// <param name="currecyRate">Current currency rate.</param>
        public CurrencyConverter(List<Currency> currencies, CurrencyRate currecyRate)
        {
            Currencies = currencies;
            CurrecyRate = currecyRate;
        }

        /// <summary>
        /// Converts all currencies to the choosen one.
        /// </summary>
        /// <param name="currencyName">Currency in which all money are needed.</param>
        /// <returns>Amount of money in choosen currency.</returns>
        public Currency ConvertAllTo(Currencies currencyName)
        {
            var currency = new Currency(currencyName, Currencies.Sum(convertedCurrency => CurrecyRate.Convert(currencyName, convertedCurrency)));

            return currency;
        }
    }
}
