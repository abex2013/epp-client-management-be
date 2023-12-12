using Excellerent.ClientManagement.Domain.Models;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ClientManagement.Domain.Entities
{
    public class CompanyContactEntity : BaseEntity<CompanyContact>
    {
        public Guid EmployeeGuid { get; set; }
        public Employee Employee { get; set; }

        public CompanyContactEntity()
        {
        }

        public CompanyContactEntity(CompanyContact comany) : base(comany)
        {
            EmployeeGuid = comany.EmployeeGuid;
            Guid = comany.Guid;
        }

        public override CompanyContact MapToModel()
        {
            CompanyContact companyContact = new CompanyContact();

            companyContact.Guid = Guid;
            companyContact.EmployeeGuid = EmployeeGuid;
            return companyContact;
        }

        public override CompanyContact MapToModel(CompanyContact t)
        {
            CompanyContact company = t;
            company.Guid = Guid;

            return company;
        }
    }
}