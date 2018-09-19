using System.Collections.Generic;
using System.IO;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    public class CurrencyFileWriter
    {
        public void WriteDictionaryToFile(Dictionary<Currencies, decimal> currencies,string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("General Sum Of Every Amount");
                foreach(KeyValuePair<Currencies,decimal> currency in currencies)
                {
                    writer.WriteLine(currency.Key + " - " + currency.Value);
                }

                writer.Close();
            }
        }
    }
}
