using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyFileReader currencyFileReader = new CurrencyFileReader();
            CurrencyFileWriter currencyFileWriter = new CurrencyFileWriter();
            CurrencyTasks currencyTasks = new CurrencyTasks();

            List<Currency> currencies = currencyFileReader.GetCurrenciesListFromFile("currency.txt");
            currencyTasks.OutputGrivnas(currencies);
            Dictionary<string, double> keyValuePairs = currencyTasks.CreateDictionaryFromList(currencies);
            currencyFileWriter.WriteDictionaryToFile(keyValuePairs, "result.txt");
            Console.ReadLine();
        }
    }
}
