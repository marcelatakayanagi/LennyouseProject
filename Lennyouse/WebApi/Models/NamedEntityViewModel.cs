using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models
{
    public class NamedEntityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        //public NamedEntity ToNamedEntity()
        //{
        //    return new NamedEntity(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name);
        //}

        public static NamedEntityViewModel Parse(NamedEntity namedEntity)
        {
            return new NamedEntityViewModel()
            {
                Id = namedEntity.Id,
                Name = namedEntity.Name
            };
        }
    }
}
