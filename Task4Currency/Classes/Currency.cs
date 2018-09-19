using System;
using Task4Currency.Enums;
using Task4Currency.Interfaces;

namespace Task4Currency.Classes
{
    public class Currency : IReadable
    {
        public Currencies CurrencyName { get; set; }

        public decimal Amount { get; set; }

        public void Read(string line)
        {
            var inputData = line.Split();

            if (!decimal.TryParse(inputData[0], out var amount) || !Enum.TryParse(inputData[1], out Currencies currencyName))
                return;

            CurrencyName = currencyName;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Amount:0.00} {CurrencyName}";
        }

    }
}
