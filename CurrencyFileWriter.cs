using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Currency
{
    public class CurrencyFileWriter
    {
        public void WriteDictionaryToFile(Dictionary<string, double> currencies,string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("General Sum Of Every Amount");
                foreach(KeyValuePair<string,double> currency in currencies)
                {
                    writer.WriteLine(currency.Key + " - " + currency.Value);
                }

                writer.Close();
            }
        }
    }
}
