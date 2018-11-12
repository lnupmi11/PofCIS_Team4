using System;

namespace BusinessLogic
{
    public class Appointment: Identified
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
