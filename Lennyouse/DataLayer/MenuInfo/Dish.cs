using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Dish : NamedEntity
    {
        [ForeignKey("DietaryRestrictions")]
        public Guid DietaryRestrictionsId { get; set; }

        public virtual DietaryRestrictions DietaryRestrictions { get; set; }

        public ICollection<Serving> ServingDishes { get; set; }

        public Dish(Guid dietaryRestrictionsId, string name, string description, string position) : base(name)
        {
            DietaryRestrictionsId = dietaryRestrictionsId;
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string description, string position) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}
