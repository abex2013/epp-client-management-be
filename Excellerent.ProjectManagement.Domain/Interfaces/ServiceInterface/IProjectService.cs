using Excellerent.ProjectManagement.Domain.Entities;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface
{
    public interface IProjectService : ICRUD<ProjectEntity, Project>
    {
        Task<IEnumerable<ProjectEntity>> GetProjectByName(string projectName);
        Task<IEnumerable<ProjectEntity>> GetProjectFullData();
        Task<PredicatedResponseDTO> GetPaginatedProject(Guid? id, string searchKey, int? pageIndex, int? pageSize);
    }
}
