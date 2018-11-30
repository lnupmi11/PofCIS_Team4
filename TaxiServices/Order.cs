using System;

namespace TaxiServices
{
    public class Order : Identified
    {
        public uint Id { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public Client Client { get; set; }

        public Payment Payment { get; set; }

        public CarType CarType { get; set; }

        public double Price { get; set; }
    }
}
