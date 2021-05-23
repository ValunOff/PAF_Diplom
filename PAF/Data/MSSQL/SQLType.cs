using PAF.Data.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.Data.MSSQL
{
    class SQLType
    {
        #region Type
        public List<Type> SelectType()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Types 
                        select new Type
                        {
                            //сделать присвоение
                        }
                        ).ToList();
            }
        }
        public void UpdateType(List<Type> types)
        {
            using (var context = new MyDbContext())
            {
                //Сделать обновление
                context.SaveChanges();
            }
        }
        #endregion
    }
}
