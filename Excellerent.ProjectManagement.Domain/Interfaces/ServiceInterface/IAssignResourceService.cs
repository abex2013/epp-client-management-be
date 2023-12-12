using Excellerent.ProjectManagement.Domain.Entities;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Interface.Service;
using System;
using System.Threading.Tasks;

namespace Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface
{
    public interface IAssignResourceService : ICRUD<AssignResourceEntity, AssignResource>
    {
        public Task<AssignResource> GetOneAssignResource(Guid id);
    }
}
