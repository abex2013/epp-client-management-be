using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Interface.Service;
using Excellerent.SharedModules.DTO;
using System.Collections.Generic;

using System.Threading.Tasks;
using System;

namespace Excellerent.ResourceManagement.Domain.Interfaces.Services
{
    public interface IEmployeeService : ICRUD<EmployeeEntity, Employee>
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Employee GetEmployeesById(Guid empId);
        Task<Employee> GetEmployeesByEmailAsync(string email);
        Task<Employee> AddNewEmployeeEntry(Employee employee);
        Task UpdateEmployee(Employee employee);

        Task<bool> CheckIfEmailExists(string email);
        Task UpdateEmployee(EmployeeEntity employeeEntity);
        Task<PredicatedResponseDTO> GetAllEmployeesDashboardAsync(string searchKey, int pageindex, int pageSize);
    }
}
