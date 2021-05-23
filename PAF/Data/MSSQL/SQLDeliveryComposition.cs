using PAF.Data.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLDeliveryComposition
    {
        public List<DeliveryComposition> SelectDeliveriesCompositions()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.DeliveriesCompositions 
                        select new DeliveryComposition
                        {
                            //сделать присваивание
                        }).ToList();
            }
        }
    }
}
