using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Entities
{
    public class EmployeeEntity : BaseEntity<Employee>
    {
        public EmployeeEntity()
        {

        }

        public string FirstName
        {
            get; set;
        }
        public string FatherName
        {
            get; set;
        }
        public string GrandfatherName
        {
            get; set;
        }
        public string MobilePhone
        {
            get; set;
        }
        public string Phone1
        {
            get; set;
        }
        public string Phone2
        {
            get; set;
        }
       

        public string PersonalEmail
        {
            get; set;
        }

        public string PersonalEmail2
        {
            get; set;
        }

        public string PersonalEmail3
        {
            get; set;
        }
        public DateTime DateofBirth
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
        public List<Nationality> Nationality { get; set; }
        public string Photo { get; set; }

        public EmergencyContactsEntity EmergencyContact { get; set; }
        public List<FamilyDetails> FamilyDetails { get; set; }
        public EmployeeOrganization EmployeeOrganization { get; set; }

        public List<PersonalAddress> EmployeeAddress { get; set; }

        public override Employee MapToModel()
        {
            Employee employee = new Employee();
            employee.FirstName = FirstName;
            employee.FatherName = FatherName;
            employee.GrandfatherName = GrandfatherName;
            employee.MobilePhone = MobilePhone;
            employee.Phone1 = Phone1;
            employee.Phone2 = Phone2;
            employee.PersonalEmail = PersonalEmail;
            employee.PersonalEmail2 = PersonalEmail2;
            employee.PersonalEmail3 = PersonalEmail3;
            employee.DateofBirth = DateofBirth;
            employee.Gender = Gender;
            employee.Nationality = Nationality;
            employee.Photo = Photo;
            employee.EmergencyContact = EmergencyContact.MapToModel();
            employee.FamilyDetails = FamilyDetails;
            employee.EmployeeOrganization = EmployeeOrganization;
            employee.EmployeeAddress = EmployeeAddress;

            return employee;
        }


        public override Employee MapToModel(Employee t)
        {
            Employee employee = new Employee();
            employee.Guid = t.Guid;
            employee.FirstName = t.FirstName;
            employee.FatherName = t.FatherName;
            employee.GrandfatherName = t.GrandfatherName;
            employee.MobilePhone = t.MobilePhone;
            employee.Phone1 = t.Phone1;
            employee.Phone2 = t.Phone2;
            employee.PersonalEmail = t.PersonalEmail;
            employee.PersonalEmail2 = t.PersonalEmail;
            employee.PersonalEmail3 = t.PersonalEmail;
            employee.DateofBirth = t.DateofBirth;
            employee.Gender = t.Gender;
            employee.Nationality =t.Nationality;
            employee.Photo =t.Photo;
            employee.EmergencyContact =t.EmergencyContact;
            employee.FamilyDetails =t.FamilyDetails;
            employee.EmployeeOrganization =t.EmployeeOrganization;
            employee.EmployeeAddress =t.EmployeeAddress;

            return employee;
        }

    }
}
