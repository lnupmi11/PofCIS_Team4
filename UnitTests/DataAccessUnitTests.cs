using BusinessLogic;
using DataAccess;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace UnitTests
{
    [TestFixture]
    public class DataAccessUnitTests
    {
        private string directory = "D:\\";
        private string filename = "doctors.xml";
        private UnitOfWork unitOfWork;
        private XmlSerializer serializer;

        [SetUp]
        public void SetUp()
        {
            serializer = new XmlSerializer(typeof(List<Doctor>));
            unitOfWork = new UnitOfWork(directory);
        }

        [TearDown]
        public void TearDown()
        {
            var doctors = unitOfWork.Doctors.ReadAll();
            for(int i = 0; i < doctors.Count; i++)
            {
                unitOfWork.Doctors.Delete(doctors[i].Id);
            }
        }

        [Test]
        public void RepositoryCreate_ValidData_WritesToFile()
        {
            var doc1 = new Doctor
            {
                Id = 1,
                PriceForConsultation = 100.5,
                FirstName = "Doctor",
                SecondName = "Watson",
                Specialization = Specialization.Oculist
            };

            unitOfWork.Doctors.Create(doc1);
            var res = unitOfWork.Doctors.Read(1);

            Assert.AreEqual(res.FirstName, "Doctor");
            Assert.AreEqual(res.SecondName, "Watson");
            Assert.AreEqual(res.Id, 1);
            Assert.AreEqual(res.PriceForConsultation, 100.5);
            Assert.AreEqual(res.Specialization, Specialization.Oculist);
        }

        [Test]
        public void RepositoryRead_IdDoesntExist_ReturnsNull()
        {
            Assert.IsNull(unitOfWork.Doctors.Read(2000));
        }

        [Test]
        public void RepositoryDelete_ValidInput_DoctorDeleted()
        {
            var doc1 = new Doctor
            {
                Id = 1,
                PriceForConsultation = 100.5,
                FirstName = "Doctor",
                SecondName = "Watson",
                Specialization = Specialization.Oculist
            };

            unitOfWork.Doctors.Create(doc1);
            unitOfWork.Doctors.Delete(2000);
            Assert.IsNull(unitOfWork.Doctors.Read(2000));
        }

        [Test]
        public void RepositoryUpdate_DoctorWithNewPrice_PriceOfDoctorUpdated()
        {
            var doc1 = new Doctor
            {
                Id = 1,
                PriceForConsultation = 100.5,
                FirstName = "Doctor",
                SecondName = "Watson",
                Specialization = Specialization.Oculist
            };

            var doc1Updated = new Doctor
            {
                Id = 1,
                PriceForConsultation = 200.5,
                FirstName = "Doctor",
                SecondName = "Watson",
                Specialization = Specialization.Oculist
            };



            unitOfWork.Doctors.Create(doc1);
            unitOfWork.Doctors.Update(doc1Updated.Id, doc1Updated);

            var res = unitOfWork.Doctors.Read(1);
            Assert.AreEqual(res.PriceForConsultation, 200.5);
            Assert.AreEqual(res.FirstName, "Doctor");
            Assert.AreEqual(res.SecondName, "Watson");
            Assert.AreEqual(res.Id, 1);
            Assert.AreEqual(res.Specialization, Specialization.Oculist);
        }
    }
}
