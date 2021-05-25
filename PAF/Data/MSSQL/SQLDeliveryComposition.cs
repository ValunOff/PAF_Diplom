using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLDeliveryComposition
    {
        public List<DeliveriesCompositions> Select()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.DeliveriesCompositions 
                        select e).ToList();
            }
        }

        public void Update(List<DeliveriesCompositions> deliveryComposition)
        {
            using(var context = new MyDbContext())
            {
                foreach (var item in context.DeliveriesCompositions)
                {
                    context.Entry(deliveryComposition).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void Add(DeliveriesCompositions deliveriesCompositions)
        {
            using(var context = new MyDbContext())
            {
                context.Entry(deliveriesCompositions).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(DeliveriesCompositions deliveriesCompositions)
        {
            using(var context = new MyDbContext())
            {
                context.Entry(deliveriesCompositions).State = EntityState.Deleted;
            }
        }
    }
}
