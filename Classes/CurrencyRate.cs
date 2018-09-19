using Task4Currency.Enums;

namespace Task4Currency.Classes
{
    public class CurrencyRate
    {
        public decimal UsdRate { get; set; } = 1m;

        public decimal EurRate { get; set; } = 0.86m;

        public decimal UahRate { get; set; } = 28.15m;

        public decimal RubRate { get; set; } = 67.75m;

        public decimal Convert(Currencies currencyToConvert, Currency currencyFromConvert)
        {
            var result = currencyFromConvert.Amount / ReturnRate(currencyFromConvert.CurrencyName) *
                             ReturnRate(currencyToConvert);

            return result;
        }

        private decimal ReturnRate(Currencies currency)
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
