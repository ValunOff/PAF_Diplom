using PAF.Data.Classes;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.MSSQL
{
    class SQLEmployee
    {        
        public List<Employee> SelectEmployee()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Employees
                        select new Employee
                        {
                            Id = e.Id,
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            Gender = e.Gender,
                            Salary = e.Salary
                        }).ToList();
            }
        }
        public void UpdateEmployee(List<Employee> employees)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(employees).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
