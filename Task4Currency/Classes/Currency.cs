using System;
using Task4Currency.Enums;
using Task4Currency.Interfaces;

namespace Task4Currency.Classes
{
    /// <summary>
    /// Represents amount of different currencies.
    /// </summary>
    public class Currency : IReadable
    {
        /// <summary>
        /// Name of the currency.
        /// </summary>
        public Currencies CurrencyName { get; set; }

        /// <summary>
        /// Amount of money in some currency.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Currency()
        {
            
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="currency">Name of the currency.</param>
        /// <param name="amount">Amount of money in choosen currency.</param>
        public Currency(Currencies currency, decimal amount)
        {
            CurrencyName = currency;
            Amount = amount;
        }

        /// <summary>
        /// Reads the string line and converts it into the class data.
        /// </summary>
        /// <param name="line">Line to parse.</param>
        public void Read(string line)
        {
            var inputData = line.Split();

            if (!decimal.TryParse(inputData[0], out var amount) || !Enum.TryParse(inputData[1], out Currencies currencyName))
                return;

            CurrencyName = currencyName;
            Amount = amount;
        }

        /// <summary>
        /// Returns string representation of current object.
        /// </summary>
        /// <returns>String representation of current object.</returns>
        public override string ToString()
        {
            return $"{Amount:0.00} {CurrencyName}";
        }

    }
}
