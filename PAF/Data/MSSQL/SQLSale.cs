using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLSale
    {
        public List<Sale> SelectSalay()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.Sales 
                        select new Sale
                        { 
                            Id=e.Id,
                            Client= SetClient(e.Client),

                        }).ToList();
            }
        }

        Client SetClient(Clients client)
        {
            return new Client
            {
                Id=client.Id,
                LastName = client.LastName,
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                Gender = client.Gender,
                Phone = client.Phone
            };
        }
    }
}
