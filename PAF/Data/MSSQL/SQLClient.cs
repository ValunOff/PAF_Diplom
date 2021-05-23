using PAF.Data.Classes;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.MSSQL
{
    /// <summary>
    /// класс для работы с таблицей клиенты
    /// </summary>
    class SQLClient
    {
        #region Client

        /// <summary>выводит список клиентов</summary>
        /// <returns>коллекция клиентов</returns>
        public List<Client> SelectClient()
        {
            using (var context = new MyDbContext())
            {
                return (from client in context.Clients
                        select new Client
                        {
                            Id = client.Id,
                            LastName = client.LastName,
                            FirstName = client.FirstName,
                            MiddleName = client.MiddleName,
                            Gender = client.Gender,
                            Phone = client.Phone
                        }).ToList();
            }
        }

        /// <summary>изменяет данные в таблице</summary>
        /// <param name="clients">коллекция данных</param>
        public void UpdateClient(List<Client> clients)
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
        public void InsertClient(Client client)
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
        /// <param name="clients">коллекция данных которые нужно удалить</param>
        public void DeleteClient(List<Client> clients)
        {
            using (var context = new MyDbContext())
            {
                foreach (var item in clients)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
