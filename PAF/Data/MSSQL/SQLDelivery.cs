using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLDelivery
    {
        public List<Deliveries> Select()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Deliveries 
                        select e).ToList();
            }
        }

        public void Update(List<Deliveries> deliveries)
        {
            using(var context = new MyDbContext())
            {
                context.Entry(deliveries).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Add(Deliveries delivery)
        {
            using(var context = new MyDbContext())
            {
                context.Entry(delivery).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Deliveries delivery)
        {
            using(var context = new MyDbContext())
            {
                context.Entry(delivery).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
