using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Excellerent.ResourceManagement.Domain.Entities;

using System.Collections;

namespace Excellerent.ResourceManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : AsyncRepository<Employee>, IEmployeeRepository
    {
        private readonly EPPContext _context;

        public EmployeeRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee emp)
        {
            await _context.Employees.AddAsync(emp);
            _context.SaveChanges();
            return emp;
        
        }

        public async  Task<List<Employee>> GetEmployeesAsync()
        {

            return await _context.Employees.Include(nationalities => nationalities.Nationality)
                .Include(personaladdress => personaladdress.EmployeeAddress).Include(emergencycontact => emergencycontact.EmergencyContact)
                .Include(familydetail => familydetail.FamilyDetails).Include(employeeorganization => employeeorganization.EmployeeOrganization)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeesByEmailAsync(string email)
        {
            var result =  await _context.Employees.Where(x => x.PersonalEmail == email).FirstOrDefaultAsync();
            if (result == null) 
            {
                result = await _context.Employees.Where(x => x.PersonalEmail2 == email).FirstOrDefaultAsync();
            }
            if (result == null) 
            {
                result = await _context.Employees.Where(x => x.PersonalEmail3 == email).FirstOrDefaultAsync();
            }
            return result;
        }

       

        public Task<IReadOnlyList<Employee>> GetEmployeesByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployee(Employee employeeEntity)
        {
            _context.Entry(employeeEntity).State = EntityState.Modified;
            _context.SaveChanges();
                      
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesDashboardAsync(Expression<Func<Employee, Boolean>> predicate, int pageIndex, int pageSize)
        {
            var employees = (predicate == null ?(await _context.Employees.Include(x => x.EmployeeOrganization).OrderByDescending(o => o.CreatedDate).ToListAsync())
                : (await _context.Employees.Include(x => x.EmployeeOrganization).Where(predicate).OrderByDescending(o => o.CreatedDate).ToListAsync()));

            var employeePaginatedList = employees.Skip(pageIndex * pageSize).Take(pageSize);
            List<EmployeeViewModel> employeeViewModelList = new List<EmployeeViewModel>();
            if (employeePaginatedList.Count() > 0)
            {
                foreach (Employee employee in employeePaginatedList)
                {
                    employeeViewModelList.Add(
                        new EmployeeViewModel()
                        {
                            EmployeeGUid = employee.Guid,
                            FullName = employee.FirstName + ' ' + employee.FatherName + ' ' + employee.GrandfatherName,
                            JobTitle = employee.EmployeeOrganization == null ? string.Empty : employee.EmployeeOrganization.JobTitle,
                            Status = employee.EmployeeOrganization ==  null? string.Empty : employee.EmployeeOrganization.Status,
                            Location = employee.EmployeeOrganization == null ? string.Empty : employee.EmployeeOrganization.Country,
                            JoiningDate = employee.EmployeeOrganization == null ? new DateTime() : employee.EmployeeOrganization.JoiningDate
                        }
                    );
                }
            }
            else
            {
                employeeViewModelList = null;
            }
            return employeeViewModelList;
        }


        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            string sample = (employee.Guid.ToString().Substring(0, employee.Guid.ToString().Length));
            var existingEmp = await _context.Employees.Where(e=>e.Guid==Guid.Parse(sample))
               .Include(ea=>ea.EmployeeAddress)
               .Include(fd=>fd.FamilyDetails)
               .Include(ec=>employee.EmergencyContact)
               //.ThenInclude(ea=>ea.Address)
               .Include(od=>od.EmployeeOrganization)
               .SingleOrDefaultAsync();

            if (existingEmp == null)
                return null;
            else
            {
                existingEmp.FirstName = employee.FirstName;
                existingEmp.FatherName = employee.FatherName;
                existingEmp.GrandfatherName = employee.GrandfatherName;

                existingEmp.MobilePhone = employee.MobilePhone;
                existingEmp.Phone1 = employee.Phone1;
                existingEmp.Phone2 = employee.Phone2;


                existingEmp.DateofBirth = employee.DateofBirth;
                existingEmp.Gender = employee.Gender;
                existingEmp.Nationality = employee.Nationality;
                existingEmp.PersonalEmail = employee.PersonalEmail;
                existingEmp.FirstName = employee.FirstName;

                existingEmp.PersonalEmail = employee.PersonalEmail;
                existingEmp.PersonalEmail2 = employee.PersonalEmail2;
                existingEmp.PersonalEmail3 = employee.PersonalEmail3;
                if (existingEmp.EmployeeAddress != null)
                {
                    for (int i = 0; i < existingEmp.EmployeeAddress.Count(); i++)
                    {
                        existingEmp.EmployeeAddress[i].Country = employee.EmployeeAddress[i].Country;
                        existingEmp.EmployeeAddress[i].City = employee.EmployeeAddress[i].City;
                        existingEmp.EmployeeAddress[i].HouseNumber = employee.EmployeeAddress[i].HouseNumber;
                        existingEmp.EmployeeAddress[i].PhoneNumber = employee.EmployeeAddress[i].PhoneNumber;
                        existingEmp.EmployeeAddress[i].PostalCode = employee.EmployeeAddress[i].PostalCode;
                        existingEmp.EmployeeAddress[i].StateRegionProvice = employee.EmployeeAddress[i].StateRegionProvice;
                        existingEmp.EmployeeAddress[i].SubCityZone = employee.EmployeeAddress[i].SubCityZone;
                        existingEmp.EmployeeAddress[i].Woreda = employee.EmployeeAddress[i].Woreda;


                    }
                }


                if (existingEmp.FamilyDetails != null)
                {
                    for (int i = 0; i < existingEmp.FamilyDetails.Count(); i++)
                    {
                        existingEmp.FamilyDetails[i].FullName = employee.FamilyDetails[i].FullName;
                        existingEmp.FamilyDetails[i].RelationshipId = employee.FamilyDetails[i].RelationshipId;
                        existingEmp.FamilyDetails[i].Gender = employee.FamilyDetails[i].Gender;
                        existingEmp.FamilyDetails[i].DoB = employee.FamilyDetails[i].DoB;
                        existingEmp.FamilyDetails[i].Remark = employee.FamilyDetails[i].Remark;

                    }
                }

                existingEmp.EmergencyContact = employee.EmergencyContact;

                if (existingEmp.EmployeeOrganization != null) {

                    existingEmp.EmployeeOrganization.Branch.CountryId = employee.EmployeeOrganization.Branch.CountryId;
                    existingEmp.EmployeeOrganization.CompaynEmail = employee.EmployeeOrganization.CompaynEmail;
                    existingEmp.EmployeeOrganization.Country = employee.EmployeeOrganization.Country;
                    existingEmp.EmployeeOrganization.BusinessUnit = employee.EmployeeOrganization.BusinessUnit;
                    existingEmp.EmployeeOrganization.Department = employee.EmployeeOrganization.Department;
                    existingEmp.EmployeeOrganization.DutyBranch = employee.EmployeeOrganization.DutyBranch;
                    existingEmp.EmployeeOrganization.JobTitle = employee.EmployeeOrganization.JobTitle;
                    existingEmp.EmployeeOrganization.JoiningDate = employee.EmployeeOrganization.JoiningDate;
                    existingEmp.EmployeeOrganization.ReportingManager = employee.EmployeeOrganization.ReportingManager;
                    existingEmp.EmployeeOrganization.Status = employee.EmployeeOrganization.Status;
                    existingEmp.EmployeeOrganization.TerminationDate = employee.EmployeeOrganization.TerminationDate;
                    existingEmp.EmployeeOrganization.PhoneNumber = employee.EmployeeOrganization.PhoneNumber;

                }

                await _context.SaveChangesAsync(true);
              
              return employee;
            }
        }
        public async Task<int> AllEmployeesDashboardCountAsync(Expression<Func<Employee, Boolean>> predicate)
        {
            var employeeList = (predicate == null ? (await _context.Employees.Include(x => x.EmployeeOrganization).OrderByDescending(o => o.CreatedDate).ToListAsync())
                : (await _context.Employees.Include(x => x.EmployeeOrganization).Where(predicate).OrderByDescending(o => o.CreatedDate).ToListAsync()));
            
            return employeeList.Count;
        }
        public Employee GetEmployeesById(Guid empId)
        {
            var result =  _context.Employees.Include(x=>x.EmployeeOrganization).Include(x=>x.FamilyDetails).Include(x=>x.Nationality).Include(x=>x.EmergencyContact).Include(x=>x.EmployeeAddress).Where(x => x.Guid == empId).FirstOrDefault();

            return result;

        }

        public bool UpdatePersonalInfoEmployee(Employee employeeEntity)
        {
            var existingEmp =  _context.Employees.Where(e => e.Guid == employeeEntity.Guid).FirstOrDefault();
            if (existingEmp == null)
                return false;
            else
            {
                existingEmp.FirstName = employeeEntity.FirstName;
                existingEmp.FatherName = employeeEntity.FatherName;
                existingEmp.GrandfatherName = employeeEntity.GrandfatherName;

                existingEmp.MobilePhone = employeeEntity.MobilePhone;
                existingEmp.Phone1 = employeeEntity.Phone1;
                existingEmp.Phone2 = employeeEntity.Phone2;


                existingEmp.DateofBirth = employeeEntity.DateofBirth;
                existingEmp.Gender = employeeEntity.Gender;
                existingEmp.Nationality = employeeEntity.Nationality;
                existingEmp.PersonalEmail = employeeEntity.PersonalEmail;
                existingEmp.FirstName = employeeEntity.FirstName;

                existingEmp.PersonalEmail = employeeEntity.PersonalEmail;
                existingEmp.PersonalEmail2 = employeeEntity.PersonalEmail2;
                existingEmp.PersonalEmail3 = employeeEntity.PersonalEmail3;

                 _context.SaveChanges(true);

            }
            return true;
        }
        public bool UpdatePersonalAddressEmployee(Employee employeeEntity)
        {
            var existingEmp = _context.Employees.Where(e => e.Guid == employeeEntity.Guid).Include(pa => pa.EmployeeAddress).FirstOrDefault();
            if (existingEmp == null)
                return false;
            else
            {
                existingEmp.EmployeeAddress = employeeEntity.EmployeeAddress;

                 _context.SaveChanges(true);
            }
            return true;
        }

        public bool UpdateOrgDetailEmployee(Employee employeeEntity)
        {
            var existingEmp = _context.Employees.Where(e => e.Guid == employeeEntity.Guid).Include(pa => pa.EmployeeOrganization).FirstOrDefault();
            if (existingEmp == null)
                return false;
            else
            {
                existingEmp.EmployeeOrganization = employeeEntity.EmployeeOrganization;

                 _context.SaveChanges(true);
            }
            return true;
        }

        public bool UpdateFamilyDetailEmployee(Employee employeeEntity)
        {
            var existingEmp = _context.Employees.Where(e => e.Guid == employeeEntity.Guid).Include(pa => pa.FamilyDetails).FirstOrDefault();
            if (existingEmp == null)
                return false ;
            else
            {
                existingEmp.FamilyDetails = employeeEntity.FamilyDetails;

                 _context.SaveChanges(true);
            }
            return true;
        }

        public bool UpdateContactEmployee(Employee employeeEntity)
        {
            var existingEmp = _context.Employees.Where(e => e.Guid == employeeEntity.Guid).Include(pa => pa.EmergencyContact).FirstOrDefault();
            if (existingEmp == null)
                return false;
            else
            {
                existingEmp.EmergencyContact = employeeEntity.EmergencyContact;

                 _context.SaveChanges(true);
            }
            return true;
        }
    }
}