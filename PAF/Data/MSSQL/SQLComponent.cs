using System.Collections.Generic;
using PAF.Data.Classes;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLComponent
    {
        #region Component
        public List<Component> SelectComponent()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Components 
                        select new Component
                        {
                            Id=e.Id,
                            Name=e.Name,
                            Amount=e.Amount,
                            //сделать вывод данных
                            //Type = e.Type,
                        }).ToList();
            }
        }

        public void UpdateComponent(List<Component> components)
        {
            using (var context = new MyDbContext())
            {
                //сделать обновление данных
                context.SaveChanges();
            }
        }
        #endregion
    }
}
