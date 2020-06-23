using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class DietaryRestrictions : NamedEntity
    {
        public virtual ICollection<Dish> Dishes { get; set; }


        public DietaryRestrictions(string name) : base(name)
        {

        }

        public DietaryRestrictions(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}
