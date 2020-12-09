using DAL.Context;
using DAL.Models;
using Services.Interfaces;
using Services.JoinClasses;
using Services.JoinTables;
using System.Collections.Generic;
using System.Linq;

namespace Services.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly IJoinTables _joinTables;

        public ClientRepository(ConstructionWasteDBContext context, IJoinTables joinTables) : base(context)
        {
            _joinTables = joinTables;
        }

        public IEnumerable<ClientJ> GetAllClient(string SearchTerm)
        {
            var clients = _joinTables.ClientJoinClientTipe();

            if (string.IsNullOrEmpty(SearchTerm))
                return clients;

            List<ClientJ> SearchedClient = new List<ClientJ>();

            foreach (var item in clients)
            {
                SearchedClient.Add(item);
            }

            return SearchedClient.Where(x => x.Name.Contains(SearchTerm)
                                        || x.Phone.Contains(SearchTerm)
                                        || x.TypeName.Contains(SearchTerm)
                                        || x.InsertTime.ToString().Contains(SearchTerm)
                                        || x.Representative.Contains(SearchTerm)
                                        || x.TypeName.Contains(SearchTerm)
                                        || x.Address.Contains(SearchTerm));
        }


        public Client GetClient(int Id)
        {
            return this.Context.Clients.Where(x => x.Id == Id).FirstOrDefault();

        }

        public IEnumerable<ClientType> GetClientTypes()
        {
            return Context.ClientTypes;

        }

        public int getId() =>
            Context.Clients.Max(x => x.Id) + 1;


    }
}
