using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaxiServices;

namespace DataAccess
{
    public class AppDBContext: DbContext
    {
        public AppDBContext()
            : base("TaxiClientService")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
