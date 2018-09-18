using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4Currency
{
    
    public class Currency : IReadable
    {
        public string CurrencyName { get; set; }

        public double Amount { get; set; }

        public void Read(StreamReader sr)
        {
            var inputData = sr.ReadLine().Split();
            int amount, temp;

            if (Int32.TryParse(inputData[0], out amount) && !Int32.TryParse(inputData[1],out temp))
            {
                CurrencyName = inputData[1];

                Amount = amount;
            }

        }

        public override string ToString()
        {
            return $"{Amount} {CurrencyName}";
        }

    }
}
