using System.Collections.Generic;
using System.Linq;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    public class CurrencyConverter
    {
        public List<Currency> Currencies { get; private set; }

        public  CurrencyRate CurrecyRate { get; set; }

        public CurrencyConverter()
        {
            Currencies = new List<Currency>();
            CurrecyRate = new CurrencyRate();
        }

        public CurrencyConverter(List<Currency> currencies, CurrencyRate currecyRate)
        {
            Currencies = currencies;
            CurrecyRate = currecyRate;
        }

        public Currency ConvertAllTo(Currencies currencyName)
        {
            Currency currency = new Currency {Amount = 0, CurrencyName = currencyName};

            currency.Amount = Currencies.Sum(convertedCurrency => CurrecyRate.Convert(currencyName, convertedCurrency));

            return currency;
        }
    }
}
