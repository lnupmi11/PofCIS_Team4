using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace СurrencyTests
{
    [TestClass]
    public class CurrencyRateUnitTests
    {
        [TestMethod]
        public void ReturnRateTestMethod()
        {
            //Arrange
            decimal testUah = 28.15m;
            CurrencyRate testCurrencyRate = new CurrencyRate();
            decimal actual = testCurrencyRate.ReturnRate(Currencies.Uah);
            Assert.AreEqual(testUah, actual);
        }

        [TestMethod]
        public void ConvertTestMethod()
        {
            //Arrange
            decimal testRub = 67.75m;
            CurrencyRate testCurrencyRate = new CurrencyRate();
            Currency testCurrency = new Currency { CurrencyName = Currencies.Usd, Amount = 1 };
            decimal actual = testCurrencyRate.Convert(Currencies.Rub , testCurrency);
            Assert.AreEqual(testRub, actual);
        }

    }
}
