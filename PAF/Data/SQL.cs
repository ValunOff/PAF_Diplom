using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System;

namespace PAF.Data
{
    class SQL
    {
        #region Employee
        public List<Employees> SelectEmployee()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Employees select e).ToList<Employees>();
            }
        }
        public void UpdateEmployee(List<Employees> employees)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(employees).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Client

        /// <summary>выводит список клиентов</summary>
        /// <returns>коллекция клиентов</returns>
        public List<Clients> SelectClient()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Clients select e).ToList<Clients>();
            }
        }

        public List<Sales> SelectSalay()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Sales select e).ToList();
            }
        }

        /// <summary>изменяет данные в таблице</summary>
        /// <param name="clients">коллекция данных</param>
        public void UpdateClient(List<Clients> clients)
        {
            using (var context = new MyDbContext())
            {
                foreach (var item in clients)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// добавляет данные в таблице
        /// </summary>
        /// <param name="client">строка данных</param>
        public void InsertClient(Clients client)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(client).State = EntityState.Added;
                context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// удаляет данные в таблице
        /// </summary>
        /// <param name="clients">коллекция данных</param>
        public void DeleteClient(List<Clients> clients)
        {
            using (var context = new MyDbContext())
            {
                Clients clientdb;

                foreach (var item in clients)
                {

                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChangesAsync();
            }
        }

        internal List<Supplies> SelectSupply()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Supplies select e).ToList();
            }
        }
        #endregion
        /// <summary>
        /// сделать позже запрос linq на конкретные столбцы а не на все
        /// </summary>
        /// <returns></returns>
        #region Component
        public List<Components> SelectComponent()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Components select e).ToList();
            }
        }

        internal List<SalesCompositions> SelectSalayComposition()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.SalesCompositions select e).ToList();
            }
        }

        public List<DeliveriesCompositions> SelectDeliveriesCompositions()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.DeliveriesCompositions select e).ToList();
            }
        }

        public void UpdateComponent(List<Components> components)
        {
            using (var context = new MyDbContext())
            {
                context.Components.RemoveRange(context.Components);
                context.Components.AddRange(components);
                context.SaveChanges();
            }
        }
        #endregion

        #region Type
        public List<Types> SelectType()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Types select e).ToList<Types>();
            }
        }
        public void UpdateType(List<Types> types)
        {
            using (var context = new MyDbContext())
            {
                context.Types.RemoveRange(context.Types);
                context.Types.AddRange(types);
                context.SaveChanges();
            }
        }
        #endregion

        #region dELIVERY

        public List<Deliveries> SelectDelivery()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Deliveries select e).ToList();
            }
        }

        #endregion


    }
}