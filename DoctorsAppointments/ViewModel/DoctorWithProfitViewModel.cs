using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoctorsAppointments.ViewModel
{
    public class DoctorWithProfitViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public double PriceForConsultation { get; set; }

        public double Profit { get; set; }
    }
}
