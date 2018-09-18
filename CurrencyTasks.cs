using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Currency
{
    public class CurrencyTasks
    {
        /// <summary>
        /// outputs all grn amounts
        /// </summary>
        public void OutputGrivnas(List<Currency> currencies)
        {
            currencies.Where(x => x.CurrencyName.Equals("grn")).ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
        }

        /// <summary>
        /// creates dictionary from List where key is currency name and value is general sum this currency
        /// </summary>
        public Dictionary<string,double> CreateDictionaryFromList(List<Currency> currencies)
        {
            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
            currencies.ForEach(x =>
            {
                if (keyValuePairs.ContainsKey(x.CurrencyName))
                {
                    keyValuePairs[x.CurrencyName] += x.Amount;
                }
                else
                {
                    keyValuePairs.Add(x.CurrencyName, x.Amount);
                }
            });
            return keyValuePairs;
        }
    }
}
