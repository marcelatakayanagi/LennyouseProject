using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Dish : NamedEntity
    {
        [ForeignKey("DietaryRestriction")]
        public Guid DietaryRestrictionId { get; set; }

        public virtual DietaryRestriction DietaryRestrictions { get; set; }

        public virtual ICollection<Serving> Servings { get; set; }

        public Dish(Guid dietaryRestrictionId, string name) : base(name)
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, Guid dietaryRestrictionId, string name) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }
    }
}
