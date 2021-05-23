using PAF.Data.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLDelivery
    {
        public List<Delivery> SelectDelivery()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Deliveries 
                        select new Delivery
                        {
                            //Сделать присвоение
                        }).ToList();
            }
        }
    }
}
