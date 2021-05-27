using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLEmployee
    {        
        public List<Employees> SelectEmployee()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Employees
                        select e).ToList();
            }
        }
        public void UpdateEmployee(List<Employees> employees)
        {
            using (var context = new MyDbContext())
            {
                foreach (var item in employees)
                {
                    try
                    {
                        context.Entry(employees).State = EntityState.Modified;
                    }
                    catch
                    {

                        
                    }
                    
                }
                
                context.SaveChanges();
            }
        }
        public void DeleteEmployee(Employees employees)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(employees).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void InsertEmployee(Employees employee)
        {
            using (var context = new MyDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
    }
}
