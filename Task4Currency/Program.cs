using System;
using System.Collections.Generic;
using Task4Currency.BL;
using Task4Currency.Classes;
using Task4Currency.Enums;

namespace Task4Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyFileReader currencyFileReader = new CurrencyFileReader();
            CurrencyFileWriter currencyFileWriter = new CurrencyFileWriter();
            CurrencyTasks currencyTasks = new CurrencyTasks();

            List<Currency> currencies = currencyFileReader.GetCurrenciesListFromFile("Data\\currency.txt");
            currencyTasks.OutputGrivnas(currencies);
            Dictionary<Currencies, decimal> keyValuePairs = currencyTasks.CreateDictionaryFromList(currencies);
            currencyFileWriter.WriteCollectionToFile(keyValuePairs, "Data\\Result.txt");
            currencyFileWriter.WriteCollectionToFile(currencyTasks.ConvertToAllCurrencies(currencies), "Data\\ResultInOneCurrency.txt");
            Console.ReadLine();
        }
    }
}
