using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class FinancialOperations
    {
        public static double GetProfitFromSellingMedicament(int medicamentId, ICollection<MedicalEquipment> medicaments)
        {
            var medicament = medicaments.FirstOrDefault(m => m.Id == medicamentId);
            return medicament.AmountBought * medicament.Price;
        }

        public static double GetProfitFromDoctorConsultations(int doctorId, ICollection<Appointment> appointments, ICollection<Doctor> doctors)
        {
            return appointments.Where(a => a.DoctorId == doctorId).Count() * doctors.FirstOrDefault(d => d.Id == doctorId).PriceForConsultation;
        }

        public static string GetMostProductiveDoctor(ICollection<Doctor> doctors, ICollection<Appointment> appointments)
        {
            var mostProductiveDoctor = doctors.Aggregate((doctor1, doctor2) =>
                GetProfitFromDoctorConsultations(doctor1.Id, appointments, doctors) > GetProfitFromDoctorConsultations(doctor2.Id, appointments, doctors)
                ? doctor1 
                : doctor2);

            return String.Concat(mostProductiveDoctor.FirstName, " ", mostProductiveDoctor.SecondName);
        }
    }
}
