using System.Collections;
using System.Collections.Generic;
using System.IO;
using Task4Currency.Enums;

namespace Task4Currency.BL
{
    /// <summary>
    /// Represents file writer.
    /// </summary>
    public class CurrencyFileWriter
    {
        /// <summary>
        /// Writes dictionary of currencies into the file.
        /// </summary>
        /// <param name="currencies">Collection of currencies to write in the file.</param>
        /// <param name="fileName">Name of the output file.</param>
        public void WriteCollectionToFile(IEnumerable currencies,string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(var currency in currencies)
                {
                    writer.WriteLine(currency);
                }

                writer.Close();
            }
        }
    }
}
