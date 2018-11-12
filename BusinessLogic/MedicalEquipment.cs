using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MedicalEquipment : Identified
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int AmountAvailable { get; set; }
        public int AmountBought { get; set; }
    }
}
