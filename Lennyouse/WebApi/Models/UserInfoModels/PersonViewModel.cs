using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public long VatNumber { get; set; }
        public Guid LennyouseUserId { get; set; }

        public Person ToPerson()
        {
            return new Person(Id, DateTime.UtcNow, DateTime.UtcNow, false, BirthDate, FirstName, LastName, PhoneNumber, VatNumber, LennyouseUserId);
        }

        public static PersonViewModel Parse(Person person)
        {
            return new PersonViewModel()
            {
                Id = person.Id,
                BirthDate = person.BirthDate,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                VatNumber = person.VatNumber,
                LennyouseUserId = person.LennyouseUserId
            };
        }
    }
}
