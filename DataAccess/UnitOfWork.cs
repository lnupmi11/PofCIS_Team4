using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork
    {
        private string directory;
        private Repository<Doctor> doctors;
        private Repository<Patient> patients;
        private Repository<Appointment> appointments;
        private Repository<MedicalEquipment> medicalEquipments;

        public UnitOfWork(string directory = "")
        {
            this.directory = directory;
        }

        public Repository<Doctor> Doctors
        {
            get
            {
                if (this.doctors == null)
                {
                    this.doctors = new Repository<Doctor>(directory + "doctors.xml");
                }

                return this.doctors;                  
            }
        }
        public Repository<Patient> Patients
        {
            get
            {
                if (this.patients == null)
                {
                    this.patients = new Repository<Patient>(Path.Combine("patients.xml"));
                }

                return this.patients;
            }
        }

        public Repository<Appointment> Appointments
        {
            get
            {
                if (this.appointments == null)
                {
                    this.appointments = new Repository<Appointment>(Path.Combine("appointments.xml"));
                }

                return this.appointments;
            }
        }

        public Repository<MedicalEquipment> MedicalEquipments
        {
            get
            {
                if (this.medicalEquipments == null)
                {
                    this.medicalEquipments = new Repository<MedicalEquipment>(Path.Combine("medicalEquipments.xml"));
                }

                return this.medicalEquipments;
            }
        }
    }
}
