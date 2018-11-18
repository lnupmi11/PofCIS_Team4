using BusinessLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class FinancialOperationsUnitTests
    {
        [Test]
        public void GetProfitFromSellingMedicament_IdDoesntExist_ThrowsNullReferenceException()
        {
            var medicaments = new List<MedicalEquipment>
            {
                new MedicalEquipment
                {
                    Id= 1
                },
                new MedicalEquipment
                {
                    Id= 2
                }
            };
            Assert.Throws<NullReferenceException>(() => FinancialOperations.GetProfitFromSellingMedicament(1000, medicaments));
        }

        [Test]
        public void GetProfitFromSellingMedicament_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FinancialOperations.GetProfitFromSellingMedicament(1000, null));
        }

        [Test]
        public void GetProfitFromSellingMedicament_ValidInput_ReturnsValidProfit()
        {
            var medicaments = new List<MedicalEquipment>
            {
                new MedicalEquipment
                {
                    Id= 1,
                    Code = "ab45s",
                    Price = 10.0,
                    AmountBought = 100,
                    AmountAvailable = 5
                }
            };
            Assert.AreEqual(FinancialOperations.GetProfitFromSellingMedicament(1, medicaments), 1000.0);
        }

        [Test]
        public void GetProfitFromDoctorConsultations_IdDoesntExist_ThrowsNullReferenceException()
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id= 1
                }
            };

            var apps = new List<Appointment>
            {
                new Appointment
                {
                    Id= 1
                }
            };


            Assert.Throws<NullReferenceException>(() => FinancialOperations.GetProfitFromDoctorConsultations(1000, apps, doctors));
        }

        [Test]
        public void GetProfitFromDoctorConsultations_ListsAreNull_ThrowsArgumentNullException()
        { 
            Assert.Throws<ArgumentNullException>(() => FinancialOperations.GetProfitFromDoctorConsultations(1000, null, null));
        }

        [Test]
        public void GetProfitFromDoctorConsultations_ValidInput_ReturnsValidProfit()
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id= 1,
                    PriceForConsultation = 10.0
                }
            };

            var apps = new List<Appointment>
            {
                new Appointment
                {
                    Id= 1,
                    DoctorId = 1,
                    PatientId = 1
                },
                new Appointment
                {
                    Id= 2,
                    DoctorId = 1,
                    PatientId = 2
                },
                new Appointment
                {
                    Id= 3,
                    DoctorId = 1,
                    PatientId = 3
                }
            };
            Assert.AreEqual(FinancialOperations.GetProfitFromDoctorConsultations(1, apps, doctors), 30.0);
        }

        [Test]
        public void GetMostProductiveDoctor_ValidInput_ReturnsValidMostProductiveDoctor()
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id= 1,
                    PriceForConsultation = 10.0,
                    FirstName = "Mary",
                    SecondName = "Novosad"
                },
                new Doctor
                {
                    Id= 2,
                    PriceForConsultation = 15.0,
                    FirstName = "Ivan",
                    SecondName = "Ivanovich"
                }
            };

            var apps = new List<Appointment>
            {
                new Appointment
                {
                    Id= 1,
                    DoctorId = 1,
                    PatientId = 1
                },
                new Appointment
                {
                    Id= 2,
                    DoctorId = 1,
                    PatientId = 2
                },
                new Appointment
                {
                    Id= 3,
                    DoctorId = 1,
                    PatientId = 3
                },

                new Appointment
                {
                    Id= 4,
                    DoctorId = 2,
                    PatientId = 1
                },
                new Appointment
                {
                    Id= 5,
                    DoctorId = 2,
                    PatientId = 2
                },
                new Appointment
                {
                    Id= 6,
                    DoctorId = 2,
                    PatientId = 3
                }
            };
            Assert.AreEqual(FinancialOperations.GetMostProductiveDoctor(doctors, apps), "Ivan Ivanovich");
        }
    }
}
