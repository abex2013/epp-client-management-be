using Excellerent.ProjectManagement.Domain.Entities;
using Excellerent.ProjectManagement.Domain.Interfaces.RepositoryInterface;
using Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Services;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ProjectManagement.Domain.Services
{
    public class ProjectService : CRUD<ProjectEntity, Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeService _employeeService;

        public ProjectService(IProjectRepository ProjectRepository,IEmployeeService employeeService) : base(ProjectRepository)
        {
            _projectRepository = ProjectRepository;
            _employeeService = employeeService;
        }
        public async Task<IEnumerable<ProjectEntity>> GetProjectByName(string projectName)
        {
            var data = _projectRepository.GetProjectByName(projectName);
            return (await data).Select(p => new ProjectEntity(p));
        }
        public async Task<IEnumerable<ProjectEntity>> GetProjectFullData()
        {
            var data = _projectRepository.GetProjectFullData();
            return (await data).Select(p => new ProjectEntity(p));
        }

        public async Task<PredicatedResponseDTO> GetPaginatedProject(Guid? id, string searchKey, int? pageIndex, int? pageSize)
        {
            int itemPerPage = pageSize ?? 10;
            int PageIndex = pageIndex ?? 1;
            Employee employee;
            var predicate = PredicateBuilder.True<Project>();
            List<ProjectEntity> projectEntities = new List<ProjectEntity>();

            if (id != null)
                predicate = predicate.And(p => p.Guid == id);
            else
                predicate = string.IsNullOrEmpty(searchKey) ? null
                           : predicate.And
                            (
                                p => p.ProjectName.ToLower().Contains(searchKey.ToLower()) 
                            );
            var projectData = (await _projectRepository.GetPaginatedProject(predicate, PageIndex, itemPerPage))
                    .Select(p => new ProjectEntity(p)
                    ).ToList();
            foreach (var data in projectData) {
                try
                {
                    employee = _employeeService.GetEmployeeById(data.SupervisorGuid)[0];
                    data.Supervisor = new Employee(employee);
                }
                catch(Exception ex) { }
                
                projectEntities.Add(data);
            }
            int TotalRowCount =await _projectRepository.CountAsync();
            return new PredicatedResponseDTO
            {
                Data= projectEntities,
                TotalRecord=TotalRowCount,   //total row count
                PageIndex=PageIndex,
                PageSize=itemPerPage,  // itemPerPage,
                TotalPage= TotalRowCount % itemPerPage == 0 ? TotalRowCount / itemPerPage : TotalRowCount / itemPerPage + 1
                };

        }
    }
}
