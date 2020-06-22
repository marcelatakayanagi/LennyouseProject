using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class DietaryRestrictions : NamedEntity
    {
        public ICollection<Dish> DishesDietarityResctrictions { get; set; }


        public DietaryRestrictions(string name, string description, string position) : base(name)
        {

        }

        public DietaryRestrictions(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string description, string position) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}
