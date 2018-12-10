using TaxiServices;

namespace DataAccess
{
    public class UnitOfWork
    {

        AppDBContext context;

        private Repository<Client> clients;
        private Repository<Order> orders;

        public UnitOfWork()
        {
            context = new AppDBContext();
        }

        public Repository<Client> Clients
        {
            get
            {
                if (this.clients == null)
                {
                    this.clients = new Repository<Client>(context);
                }

                return this.clients;
            }
        }

        public Repository<Order> Orders
        {
            get
            {
                if (this.orders == null)
                {
                    this.orders = new Repository<Order>(context);
                }

                return this.orders;
            }
        }
    }
}
