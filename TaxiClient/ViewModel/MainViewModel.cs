using TaxiServices;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace TaxiClient.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private UnitOfWork unitOfWork;
        private double price;
        private Order currentOrder;

        private ObservableCollection<Order> orders;
        

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public Order CurrentOrder
        {
            get
            {
                return currentOrder;
            }
            set
            {
                currentOrder = value;
            }
        }

        public MainViewModel()
        {
            currentOrder = new Order();
            currentOrder.Client = new Client();
            unitOfWork = new UnitOfWork();
            orders = new ObservableCollection<Order>();
            MakeOrder = new RelayCommand(MakeOrderMethod);
        }

        public ICommand MakeOrder { get; set; }

        public void MakeOrderMethod()
        {
            Price = OrderService.CountPrice(currentOrder);
            currentOrder.Price = Price;
            orders.Add(currentOrder);
            unitOfWork.Orders.Create(currentOrder);
        }

        private void InitializeOrders()
        {
            orders = new ObservableCollection<Order>();
            foreach (var order in unitOfWork.Orders.ReadAll())
            {
                var newOrder = new Order()
                {
                    Id = order.Id,
                    Start = order.Start,
                    End = order.End,
                    Price = OrderService.CountPrice(currentOrder)
                };
            
            }
        }

    }
}

