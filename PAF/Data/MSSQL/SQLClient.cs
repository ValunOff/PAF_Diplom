using PAF.Data.Classes;
using PAF.Data.Entityies;
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
        public ObservableCollection<Clients> SelectClientToObservableCollection()
        {
            using (var context = new MyDbContext())
            {
                return new ObservableCollection<Clients>(
                    from client in context.Clients
                    select client);
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
        public void UpdateClient(ObservableCollection<Clients> clients)
        {
            //ObservableCollection<Clients> tempclients;
            using (var context = new MyDbContext())
            {
                foreach (var item in clients)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();
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
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// удаляет данные в таблице
        /// </summary>
        /// <param name="clients">коллекция данных которые нужно удалить</param>
        public void DeleteClient(Clients client)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        #endregion
    }
}
