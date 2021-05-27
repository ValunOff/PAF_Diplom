using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLSupply
    {
        internal List<Supplies> SelectSupply()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Supplies
                        select e).ToList();
            }
        }

        List<Component> SetComponent(List<Components> components)
        {
            return null;
        }
    }
}
