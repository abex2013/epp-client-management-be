using Excellerent.ClientManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Excellerent.ClientManagement.Domain.Interfaces.RepositoryInterface
{
    public interface IClientDetailsRepository : IAsyncRepository<ClientDetails>
    {
        Task<IEnumerable<ClientDetails>> GetClientByName(string clientName);

        Task<IEnumerable<ClientDetails>> GetClientFullData();

        Task<IEnumerable<ClientDetails>> GetPaginatedClient(Expression<Func<ClientDetails, Boolean>> predicate, int pageIndex, int pageSize);
    }
}