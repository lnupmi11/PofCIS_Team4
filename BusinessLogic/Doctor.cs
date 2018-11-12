using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Doctor : Identified
    {
        public int Id { get ; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public Specialization Specialization { get; set; }

        public double PriceForConsultation { get; set; }
    }
}
