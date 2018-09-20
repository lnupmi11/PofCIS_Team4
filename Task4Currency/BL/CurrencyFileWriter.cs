using System;
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
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var currency in currencies)
                    {
                        writer.WriteLine(currency);
                    }

                    writer.Close();
                }
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine($"Exception occured: {exception.Message}");
                Console.WriteLine($"Some folder is missing at the current path: {fileName}. Please make sure that path is valid.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Oops! Something went wrong. Exception occured {exception.Message} at {exception.StackTrace}.");
            }
        }
    }
}
