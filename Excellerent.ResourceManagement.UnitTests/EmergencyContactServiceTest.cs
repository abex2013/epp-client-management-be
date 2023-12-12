using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.ResourceManagement.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Excellerent.ResourceManagement.UnitTests
{
    public class EmergencyContactServiceTest
    {
        private readonly EmergencyContactService _econtactService;
        private readonly Mock<IEmergencyContactRepository> econtactServiceRepository = new Mock<IEmergencyContactRepository>();

        public EmergencyContactServiceTest()
        {
            _econtactService = new EmergencyContactService(econtactServiceRepository.Object);
        }


        [Fact]
        public async Task GetAll()
        {
            List<EmergencyContactsModel> eList = new List<EmergencyContactsModel>()
            {
                new EmergencyContactsModel
                {
                Guid = Guid.NewGuid(),
                IsActive = true,
                IsDeleted = true,
                CreatedDate = DateTime.Now,
                CreatedbyUserGuid = Guid.NewGuid(),
                FirstName = "Simbo",
                FatherName = "Temesgen",
                Relationship = "brorther",
                
                }
            };
            econtactServiceRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(eList);
            var getAll = await _econtactService.GetAll();
            Assert.Equal(eList, getAll);
        }
        [Fact]
        public async Task CreateEmergencyContact()
        {
            var contact = new EmergencyContactsEntity()
            {
                Guid = Guid.NewGuid(),
                IsActive = true,
                IsDeleted = true,
                CreatedDate = DateTime.Now,
                CreatedbyUserGuid = Guid.NewGuid(),
                FirstName = "Simbo",
                FatherName = "Temesgen",
                Relationship = "brorther",

            };


            var repo = econtactServiceRepository.Setup(x => x.AddAsync(contact.MapToModel())).ReturnsAsync(contact.MapToModel());
            var data = await _econtactService.Add(contact);
            Assert.Equal(contact, data.Data);


        }


    }
}
