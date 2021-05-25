using System.Collections.Generic;
using System.Linq;
using PAF.Data.Entityies;

namespace PAF.Data.Clases
{
    class SQLComponent
    {
        public List<Components> Select()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Components 
                        select e).ToList();
            }
        }
    }
}
