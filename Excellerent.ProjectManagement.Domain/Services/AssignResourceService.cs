using Excellerent.ProjectManagement.Domain.Entities;
using Excellerent.ProjectManagement.Domain.Interfaces.RepositoryInterface;
using Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Services;
using System;
using System.Threading.Tasks;

namespace Excellerent.ProjectManagement.Domain.Services
{
    public class AssignResourceService : CRUD<AssignResourceEntity, AssignResource>, IAssignResourceService
    {
        private readonly IAssignResourceRepository _repository;
        public AssignResourceService(IAssignResourceRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public Task<AssignResource> GetOneAssignResource(Guid id)
        {
            return _repository.GetByGuidAsync(id);
        }
    }
}
