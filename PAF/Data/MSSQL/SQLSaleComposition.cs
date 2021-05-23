using PAF.Data.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLSaleComposition
    {
        internal List<SaleComposition> SelectSalayComposition()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.SalesCompositions 
                        select new SaleComposition
                        {
                            //добавить присваивание
                        }).ToList();
            }
        }
    }
}
