using BusinessLogic;
using DataAccess;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoctorsAppointments.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<DoctorWithProfitViewModel> doctors;
        private ObservableCollection<MedicalEquipmentWithProfitViewModel> medicaments;
        private UnitOfWork unitOfWork;
        private string nameOfBestDoctor;
        public string NameOfBestDoctor {
            get
            {
                return nameOfBestDoctor;
            }
             set
            {
                nameOfBestDoctor = value;
                RaisePropertyChanged("NameOfBestDoctor");
            }
        }

        public MainViewModel()
        {
            unitOfWork = new UnitOfWork();
            InitializeDoctors();
            InitializeMedicaments();
            ShowMostProdutiveDoctor = new RelayCommand(ShowMostProdutiveDoctorMethod);
        }

        public ICommand ShowMostProdutiveDoctor { get; private set; }

        public ObservableCollection<DoctorWithProfitViewModel> DoctorList
        {
            get
            {
                return doctors;
            }
        }

        public ObservableCollection<MedicalEquipmentWithProfitViewModel> MedicamentList
        {
            get
            {
                return medicaments;
            }
        }

        public void ShowMostProdutiveDoctorMethod()
        {
            NameOfBestDoctor = FinancialOperations.GetMostProductiveDoctor(unitOfWork.Doctors.ReadAll(), unitOfWork.Appointments.ReadAll());
        }

        private void InitializeMedicaments()
        {
            medicaments = new ObservableCollection<MedicalEquipmentWithProfitViewModel>();

            foreach (var medicament in unitOfWork.MedicalEquipments.ReadAll())
            {
                var medicamentWithProfit = new MedicalEquipmentWithProfitViewModel
                {
                    Id = medicament.Id,
                    Code = medicament.Code,
                    AmountBought = medicament.AmountBought,
                    Price = medicament.Price,
                    Profit = FinancialOperations.GetProfitFromSellingMedicament(medicament.Id, unitOfWork.MedicalEquipments.ReadAll())
                };

                medicaments.Add(medicamentWithProfit);
            }
        }

        private void InitializeDoctors()
        {
            doctors = new ObservableCollection<DoctorWithProfitViewModel>();

            foreach (var doctor in unitOfWork.Doctors.ReadAll())
            {
                var doctorWithProfit = new DoctorWithProfitViewModel
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    SecondName = doctor.SecondName,
                    PriceForConsultation = doctor.PriceForConsultation,
                    Profit = FinancialOperations.GetProfitFromDoctorConsultations(doctor.Id, unitOfWork.Appointments.ReadAll(), unitOfWork.Doctors.ReadAll())
                };

                doctors.Add(doctorWithProfit);
            }
        }
    }
}