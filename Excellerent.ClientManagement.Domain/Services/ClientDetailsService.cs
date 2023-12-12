using Excellerent.ClientManagement.Domain.Entities;
using Excellerent.ClientManagement.Domain.Interfaces.RepositoryInterface;
using Excellerent.ClientManagement.Domain.Interfaces.ServiceInterface;
using Excellerent.ClientManagement.Domain.Models;
using Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Services;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ClientManagement.Domain.Services
{
    public class ClientDetailsService : CRUD<ClientDetailsEntity, ClientDetails>, IClientDetailsService
    {
        private readonly IClientDetailsRepository _clientDetailsRepository;
        private readonly IEmployeeService _employeeService;

        public ClientDetailsService(IClientDetailsRepository clientDetailsRepository, IEmployeeService employeeService) : base(clientDetailsRepository)
        {
            _clientDetailsRepository = clientDetailsRepository;
            _employeeService = employeeService;
        }

        public async Task<ResponseDTO> AddNewClient(ClientDetailsEntity client)
        {
            try
            {
                return new ResponseDTO(ResponseStatus.Success, "Client Data Added successfully",
                    await _clientDetailsRepository.AddAsync(client.MapToModel()));
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, "Invalid Input", null);
            }
        }

        public async Task<IEnumerable<ClientDetailsEntity>> GetClientByName(string clientName)
        {
            var data = _clientDetailsRepository.GetClientByName(clientName);
            return (await data).Select(c => new ClientDetailsEntity(c));
        }

        public async Task<ResponseDTO> GetClientFullData()
        {
            List<ClientDetailsEntity> ClientEntity = new List<ClientDetailsEntity>();
            var clientData = (await _clientDetailsRepository.GetClientFullData()).Select(p => new ClientDetailsEntity(p)).ToList();
            foreach (var data in clientData)
            {
                try
                {
                    var salesPerson = _employeeService.GetEmployeeById(data.SalesPersonGuid)[0];
                    data.SalesPersonName = new Employee(salesPerson).Name;
                    data.SalesPerson = new Employee(salesPerson);
                    data.ClientStatusName = data.ClientStatus.StatusName;
                    data.OperatingAddressCountry = data.OperatingAddress[0].Country;
                    var contacts = data.CompanyContacts.ToList();
                    for (int count = 0; count < contacts.Count(); count++)
                    {
                        data.CompanyContacts[count].Employee = new Employee(_employeeService.GetEmployeeById(contacts[count].EmployeeGuid)[0]);
                    }
                }
                catch (Exception ex) { }

                ClientEntity.Add(data);
            }
            return new ResponseDTO
            {
                Data = ClientEntity,
                Message = "Client full data",
                Ex = null,
                ResponseStatus = ResponseStatus.Success
            };
        }

        public async Task<PredicatedResponseDTO> GetPaginatedClient(Guid? id, string searchKey, int? pageIndex, int? pageSize)
        {
            int itemPerPage = pageSize ?? 10;
            int PageIndex = pageIndex ?? 1;
            Employee employee;
            var predicate = PredicateBuilder.True<ClientDetails>();
            List<ClientDetailsEntity> clientDetailsEntities = new List<ClientDetailsEntity>();
            if (id != null)
                predicate = predicate.And(p => p.Guid == id);
            else
                predicate = string.IsNullOrEmpty(searchKey) ? null
                           : predicate.And
                            (
                                p => p.ClientName.ToLower().Contains(searchKey.ToLower())
                            );
            var clientData = (await _clientDetailsRepository.GetPaginatedClient(predicate, PageIndex, itemPerPage))
                    .Select(p => new ClientDetailsEntity(p)
                    ).ToList();
            foreach (var data in clientData)
            {
                try
                {
                    employee = _employeeService.GetEmployeeById(data.SalesPersonGuid)[0];
                    data.SalesPersonName = new Employee(employee).Name;
                    data.SalesPerson = new Employee(employee);
                    data.ClientStatusName = data.ClientStatus.StatusName;
                    data.OperatingAddressCountry = data.OperatingAddress[0].Country;
                    var contacts = data.CompanyContacts.ToList();
                    for (int count = 0; count < contacts.Count(); count++)
                    {
                        data.CompanyContacts[count].Employee = new Employee(_employeeService.GetEmployeeById(contacts[count].EmployeeGuid)[0]);
                    }
                }
                catch (Exception ex) { }

                clientDetailsEntities.Add(data);
            }
            int TotalRowCount = await _clientDetailsRepository.CountAsync();
            return new PredicatedResponseDTO
            {
                Data = clientData,
                TotalRecord = TotalRowCount,
                PageIndex = PageIndex,
                PageSize = itemPerPage,
                TotalPage = TotalRowCount % itemPerPage == 0 ? TotalRowCount / itemPerPage : TotalRowCount / itemPerPage + 1
            };
        }
    }
}