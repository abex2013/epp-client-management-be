using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ProjectManagement.Domain.Entities
{
    public class AssignResourceEntity : BaseEntity<AssignResource>
    {
        public Guid ProjectGuid { get; set; }
        public virtual Project Project { get; set; }
        public Guid EmployeeGuid { get; set; }
        //public virtual Employee Empolyee { get; set; }
        public DateTime AssignDate { get; set; }
        public AssignResourceEntity()
        {
            this.IsActive = true;
        }

        public AssignResourceEntity(AssignResource assignResource) : base(assignResource)
        {
            IsActive = assignResource.IsActive;
            IsDeleted = assignResource.IsDeleted;
            Guid = assignResource.Guid;
            ProjectGuid = assignResource.ProjectGuid;
            Project = assignResource.Project;
            EmployeeGuid = assignResource.EmployeeGuid;
            //Empolyee = assignResource.Empolyee;
            AssignDate = assignResource.AssignDate;


        }
        public override AssignResource MapToModel()
        {
            AssignResource assignResource = new AssignResource();
            assignResource.Guid = Guid;
            assignResource.ProjectGuid = ProjectGuid;
            assignResource.Project = Project;
            assignResource.EmployeeGuid = EmployeeGuid;
           // assignResource.Empolyee = Empolyee;
            assignResource.IsActive = IsActive;
            assignResource.IsDeleted = IsDeleted;
            assignResource.AssignDate = AssignDate;
            return assignResource;
        }

        public override AssignResource MapToModel(AssignResource t)
        {
            AssignResource assignResource = t;
            assignResource.ProjectGuid = ProjectGuid;
            assignResource.Project = Project;
            assignResource.EmployeeGuid = EmployeeGuid;
            //assignResource.Empolyee = Empolyee;
            assignResource.IsActive = IsActive;
            assignResource.IsDeleted = IsDeleted;
            assignResource.AssignDate = AssignDate;

            return assignResource;

        }
    }
}
