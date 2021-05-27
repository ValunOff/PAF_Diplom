using PAF.Data.Entityies;
using System.Data.Entity;

namespace PAF.Data
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {

        }
        public DbSet<Clients> Clients { get; set; }
        //public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<DeliveriesCompositions> DeliveriesCompositions { get; set; }
        public DbSet<Employees> Employees { get; set; }
        //public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesCompositions> SalesCompositions { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<Supplies> Supplies { get; set; }
        public DbSet<Types> Types { get; set; }
    }
}