﻿using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class DietaryRestriction : NamedEntity
    {
        public virtual ICollection<Dish> Dishes { get; set; }


        public DietaryRestriction(string name) : base(name)
        {

        }

        public DietaryRestriction(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}
