using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Currency;
using Task4Currency.Enums;
using Task4Currency.BL;
using Task4Currency.Classes;
using Task4Currency.Interfaces;

namespace CurrencyRateUnitTest
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
    }
}
