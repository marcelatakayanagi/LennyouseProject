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

        public virtual ICollection<Serving> Servings { get; set; }

        public Dish(Guid dietaryRestrictionsId, string name) : base(name)
        {
            DietaryRestrictionsId = dietaryRestrictionsId;
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, Guid dietaryRestrictionsId, string name) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            DietaryRestrictionsId = dietaryRestrictionsId;
        }
    }
}
