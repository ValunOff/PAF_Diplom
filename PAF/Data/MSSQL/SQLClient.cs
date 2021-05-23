using PAF.Data.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace PAF.Data.Clases
{
    /// <summary>
    /// класс для работы с таблицей клиенты
    /// </summary>
    class SQLClient
    {
        #region Client

        /// <summary>выводит список клиентов</summary>
        /// <returns>коллекция клиентов</returns>
        public ObservableCollection<Client> SelectClientToObservableCollection()
        {
            using (var context = new MyDbContext())
            {
                return new ObservableCollection<Client>(
                    from client in context.Clients
                    select new Client
                    {
                        Id = client.Id,
                        LastName = client.LastName,
                        FirstName = client.FirstName,
                        MiddleName = client.MiddleName,
                        Gender = client.Gender,
                        Phone = client.Phone
                    });
            }
        }
        public List<Client> SelectClientToList()
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
        public void UpdateClient(ObservableCollection<Client> clients)
        {
            var changedClients = from cc in clients
                                 where cc.Status == Status.Modified
                                 select cc;

            using (var context = new MyDbContext())
            {
                
                foreach (var item in changedClients)
                {
                    context.Entry(item).State = EntityState.Modified;
                    item.Status = Status.Unchanged;
                }
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
