using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLSupply
    {
        internal List<Supply> SelectSupply()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Supplies
                        select new Supply
                        {
                            Id = e.Id,
                            Address=e.Address,
                            Component = SetComponent(e.Component),
                        }).ToList();
            }
        }

        List<Component> SetComponent(List<Components> components)
        {
            return null;
        }
    }
}
