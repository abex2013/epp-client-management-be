using Excellerent.ProjectManagement.Domain.Interfaces.RepositoryInterface;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;

namespace Excellerent.ProjectManagement.Infrastructure.Repositories
{
    public class AssignResourceRepository : AsyncRepository<AssignResource>, IAssignResourceRepository
    {
        private readonly EPPContext _context;
        public AssignResourceRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

    }
}
