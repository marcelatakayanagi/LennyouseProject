using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Dish : NamedEntity
    {
        [ForeignKey("Dietary Restriction")]
        public Guid DietaryRestrictionId { get; set; }

        public virtual DietaryRestriction DietaryRestrictions { get; set; }

        public virtual ICollection<Serving> Servings { get; set; }

        public Dish(string name, Guid dietaryRestrictionId) : base(name)
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, Guid dietaryRestrictionId) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            DietaryRestrictionId = dietaryRestrictionId;
        }
    }
}
