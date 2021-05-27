using PAF.Data.Classes;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Linq;

namespace PAF.Data.Clases
{
    class SQLSale
    {
        public List<SalesCompositions> SelectSalay()
        {
            using (var context = new MyDbContext())
            {
                return (from e in context.SalesCompositions 
                        select e).ToList();
            }
        }

        Client SetClient(Clients client)
        {
            return new Client
            {
                //Id=client.ClientsId,
                LastName = client.LastName,
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                Gender = client.Gender,
                Phone = client.Phone
            };
        }
    }
}
