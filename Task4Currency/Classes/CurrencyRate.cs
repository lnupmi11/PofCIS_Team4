using System;
using Task4Currency.Enums;

namespace Task4Currency.Classes
{
    /// <summary>
    /// Represents current currency rate.
    /// </summary>
    public class CurrencyRate
    {
        /// <summary>
        /// Rate USD to USD.
        /// </summary>
        public decimal UsdRate { get; set; } = 1m;

        /// <summary>
        /// Rate EUR to USD.
        /// </summary>
        public decimal EurRate { get; set; } = 0.86m;

        /// <summary>
        /// Rate UAH to USD.
        /// </summary>
        public decimal UahRate { get; set; } = 28.15m;

        /// <summary>
        /// Rate RUB to USD.
        /// </summary>
        public decimal RubRate { get; set; } = 67.75m;

        /// <summary>
        /// Converts amount of money in one currency to another.
        /// </summary>
        /// <param name="currencyToConvert">Name of the currency to convert.</param>
        /// <param name="currencyFromConvert">Amount of money that need to be converted.</param>
        /// <returns>Amount of converted currency.</returns>
        public decimal Convert(Currencies currencyToConvert, Currency currencyFromConvert)
        {
            decimal result;

            try
            {
                result = currencyFromConvert.Amount / ReturnRate(currencyFromConvert.CurrencyName) *
                         ReturnRate(currencyToConvert);

            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine($"Exception occured {exception.Message}. You can't convert sum of money that is equal to null.");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Oops! Something went wrong. Exception occured {exception.Message} at {exception.StackTrace}.");
                throw;
            }

            return result;
        }
        
        /// <summary>
        /// Returns rate of the choosed currency to USD.
        /// </summary>
        /// <param name="currency">Name of the currency.</param>
        /// <returns>Rate of the choosed currency to USD.</returns>
        public decimal ReturnRate(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.Usd:
                    return UsdRate;
                case Currencies.Eur:
                    return EurRate;
                case Currencies.Uah:
                    return UahRate;
                case Currencies.Rub:
                    return RubRate;
                default:
                    return 0;
            }
        }
    }
}
