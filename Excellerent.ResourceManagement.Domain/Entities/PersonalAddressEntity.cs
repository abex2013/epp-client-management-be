using Excellerent.ResourceManagement.Domain.Models;

namespace Excellerent.ResourceManagement.Domain.Entities
{
    public class PersonalAddressEntity : BaseAddressEntity<PersonalAddress>
    {
        public override PersonalAddress MapToModel()
        {
            PersonalAddress t = new PersonalAddress();

            t.Guid = Guid;
            t.PhoneNumber = PhoneNumber;
            t.Country = Country;
            t.StateRegionProvice = StateRegionProvice;
            t.City = City;
            t.SubCityZone = SubCityZone;
            t.Woreda = Woreda;
            t.HouseNumber = HouseNumber;
            t.PostalCode = PostalCode;
            t.IsActive = IsActive;
            t.IsDeleted = IsDeleted;
            t.CreatedDate = CreatedDate;
            t.CreatedbyUserGuid = CreatedbyUserGuid;

            return t;
        }

        public override PersonalAddress MapToModel(PersonalAddress t)
        {
            t.Guid = Guid;
            t.PhoneNumber = PhoneNumber;
            t.Country = Country;
            t.StateRegionProvice = StateRegionProvice;
            t.City = City;
            t.SubCityZone = SubCityZone;
            t.Woreda = Woreda;
            t.HouseNumber = HouseNumber;
            t.PostalCode = PostalCode;
            t.IsActive = IsActive;
            t.IsDeleted = IsDeleted;
            t.CreatedDate = CreatedDate;
            t.CreatedbyUserGuid = CreatedbyUserGuid;

            return t;
        }
    }
}
