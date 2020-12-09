using DAL.Models;
using Services.JoinClasses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {

        IEnumerable<ClientJ> GetAllClient(string SearchTerm);

        Client GetClient(int Id);

        IEnumerable<ClientType> GetClientTypes();

        int getId();
    }
}
